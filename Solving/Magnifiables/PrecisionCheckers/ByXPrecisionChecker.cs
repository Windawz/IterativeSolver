using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal class ByXPrecisionChecker : PrecisionChecker {
    public override bool IsPrecise(IMagnifiable magnifiable, Given given) {
        double x = magnifiable.Absolute;
        double xlast = magnifiable.LastAbsolute ?? 0.0;
        return Math.Abs(x - xlast) <= given.Precision.Value;
    }
}
