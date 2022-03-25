using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Solvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal class AbsoluteChecker : BasicPrecisionChecker {
    public AbsoluteChecker(Precision precision) : base(precision) { }

    public override bool IsPrecise(IState state, IAbsolute absolute) =>
        absolute.GetAbsolute(state.Magnifiable.Value) <= Precision.Value;
}
