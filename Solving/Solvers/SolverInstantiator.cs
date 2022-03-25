using IterativeSolver.Solving.PrecisionCheckers;
using IterativeSolver.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal static class SolverInstantiator {
    public static TSolver Instantiate<TSolver>(params object[] args)
        where TSolver : ISolver => (TSolver)Instantiate(typeof(TSolver), args);
    public static ISolver Instantiate(Type solverType, params object[] args) {
        Exception? ex = GetExceptionIfInvalid(solverType);
        if (ex is not null) {
            throw ex;
        }
        return InstantiateOrThrowCustomException(solverType, args);
    }
    public static IPrecisionSolver InstantiatePrecisionSolver(Type solverType, IPrecisionChecker precisionChecker) {
        object[][] possibleArgsList = GetPossiblePrecisionSolverArgsList(precisionChecker);
        ThrowOnPossibleArgsListEmpty(possibleArgsList);

        Variant<IPrecisionSolver, SolverInstantiationException> result =
            InstantiateSolverWithBestMatchingArgs(solverType, possibleArgsList);

        if (result.Is<IPrecisionSolver>()) {
            return result.Get<IPrecisionSolver>();
        } else {
            throw new InvalidOperationException(
                "Solver instantiation failed, see inner exception",
                result.Get<SolverInstantiationException>());
        }
    }
    private static Variant<IPrecisionSolver, SolverInstantiationException> InstantiateSolverWithBestMatchingArgs(
        Type solverType,
        object[][] possibleArgsList) {

        Variant<IPrecisionSolver, SolverInstantiationException> result = null!;
        foreach (object[] args in possibleArgsList) {
            result = MakeSolverOrGetException(solverType, args);
            if (result.Is<IPrecisionSolver>()) {
                break;
            }
        }

        return result;
    }
    private static void ThrowOnPossibleArgsListEmpty(object[][] possibleArgsList) {
        if (possibleArgsList.Any()) {
            return;
        }
        throw new InvalidOperationException("Possible solver ctor args list is empty");
    }
    private static object[][] GetPossiblePrecisionSolverArgsList(IPrecisionChecker precisionChecker) =>
        new object[][] {
            new object[] { precisionChecker },
            new object[] { precisionChecker.Precision },
        };
    private static Variant<IPrecisionSolver, SolverInstantiationException> MakeSolverOrGetException(
        Type solverType,
        object[] ctorArgs) {

        IPrecisionSolver solver;
        try {
            solver = (IPrecisionSolver)Instantiate(solverType, ctorArgs);
        } catch (SolverInstantiationException ex) {
            return ex;
        }
        return new(solver);
    }
    private static ISolver InstantiateOrThrowCustomException(Type solverType, params object[] args) {
        ISolver solver;

        try {
            solver = InstantiateUnhandled(solverType, args);
        } catch (Exception ex) {
            throw WrapIntoCustomException(ex, solverType, args);
        }

        return solver;
    }
    private static Exception WrapIntoCustomException(Exception activatorException, Type solverType, params object[] args) => 
        activatorException switch {
            MethodAccessException methodAccessEx => 
                new InvalidSolverTypeException(
                    $"Desired constructor of {solverType} is inaccessible",
                    solverType),
            MissingMemberException missingMethodEx =>
                new InvalidSolverConstructorArgsException(
                    $"No ctor matching args found for {solverType}",
                    args,
                    activatorException),
            _ => 
                // Some unknown error happened. To bring attention to it, throw
                // an exception that doesn't inherit from SolverInstantiationException
                new InvalidOperationException(
                    $"Instantiation of {solverType} instantiation has failed, see inner exception", 
                    activatorException),
        };
    private static ISolver InstantiateUnhandled(Type solverType, params object[] args) {
        object solver = Activator.CreateInstance(solverType, args)!;
        return (ISolver)solver;
    }
    private static Exception? GetExceptionIfInvalid(Type solverType) =>
        solverType switch {
            var _ when !IsSolverType(solverType) => 
                new InvalidSolverTypeException($"{solverType} is not a solver type", solverType),
            var _ when !IsTypeConcrete(solverType) => 
                new InvalidSolverTypeException($"{solverType} is not concrete and cannot be instantiated", solverType),
            var _ when !IsTypeClosedGeneric(solverType) => 
                new InvalidSolverTypeException($"{solverType} is generic and not closed", solverType),
            _ => null,
        };
    private static bool IsSolverType(Type type) =>
        type.IsSubclassOf(typeof(ISolver))
        || type.IsAssignableTo(typeof(ISolver));
    private static bool IsTypeConcrete(Type type) =>
        !type.IsInterface
        && !type.IsAbstract;
    private static bool IsTypeClosedGeneric(Type type) =>
        !type.IsGenericType
        || type.IsConstructedGenericType;
}
