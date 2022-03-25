using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class InvalidSolverTypeException : SolverInstantiationException {
    public InvalidSolverTypeException(Type solverType) : this(null, solverType) { }
    public InvalidSolverTypeException(string? message, Type solverType) : this(message, solverType, null) { }
    public InvalidSolverTypeException(
        string? message,
        Type solverType,
        Exception? innerException) : base(message, innerException) {

        SolverType = solverType;
    }

    public Type SolverType { get; }
}
