using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Absolutes;
internal class SegmentFunctionalDifferenceAbsolute : IAbsolute<Segment> {
    public SegmentFunctionalDifferenceAbsolute(Function function) {
        Function = function;
    }

    public Function Function { get; set; }

    public double GetAbsolute(Segment value) =>
        Math.Abs(Function(value.Left) - Function(value.Right));
}
