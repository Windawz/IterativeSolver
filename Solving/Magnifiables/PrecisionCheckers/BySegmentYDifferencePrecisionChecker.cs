using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal class BySegmentYDifferencePrecisionChecker : PrecisionChecker<IMagnifiable<Segment>> {
    public BySegmentYDifferencePrecisionChecker(IMagnifiable<Segment> magnifiable) : base(magnifiable) { }

    public override bool IsPrecise(Given given) {
        var f = given.Equation.Function;
        var s = Magnifiable.Value;
        return Math.Abs(f(s.Left) - f(s.Right)) <= (double)given.Precision.Value;
    }
}
