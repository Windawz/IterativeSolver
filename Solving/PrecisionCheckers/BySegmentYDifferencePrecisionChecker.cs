using IterativeSolver.Solving.Magnifiables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal class BySegmentYDifferencePrecisionChecker : PrecisionChecker<IMagnifiable<Segment>> {
    public override bool IsPrecise(IMagnifiable<Segment> magnifiable, Given given) {
        var f = given.Equation.Function;
        var s = magnifiable.Value;
        return Math.Abs(f(s.Left) - f(s.Right)) <= (double)given.Precision.Value;
    }
}
