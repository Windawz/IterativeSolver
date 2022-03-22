
using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal class MagnifiedSegmentRight : Magnifiable<Segment> {
    public MagnifiedSegmentRight(Segment value) : base(value) { }

    public override double GetAbsolute(Segment value) => throw new NotImplementedException();
    public override IPrecisionChecker GetPrecisionChecker() =>
        new ByYPrecisionChecker(this);
}
