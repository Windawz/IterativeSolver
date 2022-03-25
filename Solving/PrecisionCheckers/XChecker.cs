using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.Solvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal class XChecker : BasicPrecisionChecker {
    public XChecker(Precision precision) : base(precision) { }

    public override bool IsPrecise(IState state, IAbsolute absolute) {
        IMagnifiable magnifiable = state.Magnifiable;

        double x = absolute.GetAbsolute(magnifiable.Value);

        object? lastValue = magnifiable.LastValue;
        double xlast = lastValue is not null ?
            absolute.GetAbsolute(lastValue) : 0.0;

        return Math.Abs(x - xlast) <= Precision.Value;
    }
}
