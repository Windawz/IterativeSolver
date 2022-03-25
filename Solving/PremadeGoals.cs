using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Solving.PrecisionCheckers;
using IterativeSolver.Solving.Solvers;
using IterativeSolver.Utils;

namespace IterativeSolver.Solving;

internal static class PremadeGoals {
    public static IEnumerable<Equation> Equations = new Equation[] {
        Equation.GetCubic(1.0, 0.0, 3.0, 1.0),
    };
    public static IEnumerable<Segment> Segments = new Segment[] {
        (-1.0, 1.0),
    };
    public static IEnumerable<IPrecisionChecker> PrecisionCheckers { get; } = new IPrecisionChecker[] {
        new FXChecker(0.001),
    };
    public static IEnumerable<Type> SolverTypes = new Type[] {
        typeof(BisectionSolver),
        typeof(SecantSolver),
        typeof(NewtonSolver),
        typeof(SimplifiedNewtonSolver),
        typeof(CombinedSolver),
        typeof(IterationsMethodSolver),
    };
    public static IEnumerable<int> MaxSteps = new int[] {
        2500,
    };
    public static IEnumerable<IPrecisionSolver> Solvers = SolverTypes
        .CartesianProduct(PrecisionCheckers)
        .Select(tuple => SolverInstantiator.InstantiatePrecisionSolver(tuple.Item1, tuple.Item2));
    public static IEnumerable<Given> Givens { get; } = Equations
        .CartesianProduct(Segments, PrecisionCheckers, MaxSteps)
        .Select(tuple => new Given(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
    public static IEnumerable<Goal> Goals { get; } = Solvers
        .CartesianProduct(Givens)
        .Select(tuple => new Goal(tuple.Item1, tuple.Item2));

    
}
