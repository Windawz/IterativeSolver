
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal class Magnifiable<T> : IMagnifiable<T>
    where T : notnull {

    public Magnifiable(T value) {
        _value = value;
    }

    private T _value;

    public T Value {
        get => _value;
        set {
            LastValue = _value;
            _value = value;
        }
    }
    public T? LastValue { get; private set; }
}
