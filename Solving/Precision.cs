
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;
internal class Precision {
    public Precision(double value) {
        Value = value;
    }

    public double Value { get; }

    public static implicit operator Precision(double value) =>
        new(value);
}
