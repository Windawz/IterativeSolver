using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.Solvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal class FXChecker : BasicPrecisionChecker {
    public FXChecker(Precision precision) : base(precision) { }

    public override bool IsPrecise(IState state, IAbsolute absolute) {
        Function f = state.Given.Equation.Function;
        double x = absolute.GetAbsolute(state.Magnifiable.Value);
        double y = f(x);
        return Math.Abs(y) <= Precision.Value;
    }
}
