using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;

internal class Failure {
    public Failure(string message) {
        Message = message;
    }
    public Failure(string message, Exception exception) : this(message) {
        Exception = exception;
    }

    public string Message { get; }
    public Exception? Exception { get; } = null;
}
