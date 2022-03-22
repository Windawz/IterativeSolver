using IterativeSolver.Solving.Magnifiables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal class ByYPrecisionChecker : PrecisionChecker {
    public override bool IsPrecise(IMagnifiable magnifiable, Given given) {
        double x = magnifiable.Absolute;
        double y = given.Equation.Function(x);
        return Math.Abs(y) <= given.Precision.Value;
    }
}
