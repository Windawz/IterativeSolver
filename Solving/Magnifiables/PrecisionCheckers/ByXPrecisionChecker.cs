using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal class ByXPrecisionChecker : PrecisionChecker {
    public ByXPrecisionChecker(IMagnifiable magnifiable) : base(magnifiable) { }

    public override bool IsPrecise(Given given) {
        double x = Magnifiable.Absolute;
        double xlast = Magnifiable.LastAbsolute ?? 0.0;
        return Math.Abs(x - xlast) <= given.Precision.Value;
    }
}
