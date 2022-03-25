using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class InvalidSolverConstructorArgsException : SolverInstantiationException {
    public InvalidSolverConstructorArgsException(object[] args) : this(null, args) { }
    public InvalidSolverConstructorArgsException(string? message, object[] args) : this(message, args, null) { }
    public InvalidSolverConstructorArgsException(
        string? message,
        object[] args,
        Exception? innerException) : base(message, innerException) {
        
        ConstructorArgs = args;
    }

    public IEnumerable<object> ConstructorArgs { get; }
}
