﻿
using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal class MagnifiableSegmentMiddle : Magnifiable<Segment> {
    public MagnifiableSegmentMiddle(Segment value) : base(value) { }

    public override double GetAbsolute(Segment value) => value.Middle;
    public override IPrecisionChecker GetPrecisionChecker() =>
        new ByYPrecisionChecker(this);
}
