using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Absolutes;
internal class SegmentRightAbsolute : IAbsolute<Segment> {
    public double GetAbsolute(Segment value) =>
        value.Right;
}
