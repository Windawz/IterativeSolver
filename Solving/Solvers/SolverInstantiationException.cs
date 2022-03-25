using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class SolverInstantiationException : Exception {
    public SolverInstantiationException() { }
    public SolverInstantiationException(string? message) : base(message) { }
    public SolverInstantiationException(string? message, Exception? innerException) : base(message, innerException) { }
}
