
using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal abstract class Magnifiable<T> : IMagnifiable<T>
    where T : notnull {

    protected Magnifiable(T value) {
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

    public abstract double GetAbsolute(T value);
}
