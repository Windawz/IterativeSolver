
using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal class MagnifiablePoint : Magnifiable<double> {
    public MagnifiablePoint(double value) : base(value) { }

    public override double GetAbsolute(double value) => value;
    public override IPrecisionChecker GetPrecisionChecker() => 
        new ByYPrecisionChecker(this);
}
