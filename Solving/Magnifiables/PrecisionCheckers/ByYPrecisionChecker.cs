using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal class ByYPrecisionChecker : PrecisionChecker {
    public ByYPrecisionChecker(IMagnifiable magnifiable) : base(magnifiable) { }

    public override bool IsPrecise(Given given) {
        double x = Magnifiable.Absolute;
        double y = given.Equation.Function(x);
        return Math.Abs(y) <= given.Precision.Value;
    }
}
