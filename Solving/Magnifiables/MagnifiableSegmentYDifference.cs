
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal class MagnifiableSegmentYDifference : Magnifiable<Segment> {
    public MagnifiableSegmentYDifference(Segment value, Function function) : base(value) {
        _function = function;
    }

    private readonly Function _function;

    public override double GetAbsolute(Segment value) =>
        Math.Abs(_function(value.Left) - _function(value.Right));
}
