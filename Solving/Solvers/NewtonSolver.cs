
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class NewtonSolver : PrecisionSolver<State<MagnifiablePoint>, ByYPrecisionChecker> {
    public override ByYPrecisionChecker PrecisionChecker =>
        new();

    protected override State<MagnifiablePoint> GetInitialState(Given given) =>
        new(given, new MagnifiablePoint(given.Segment.Right));
    protected override void Step(State<MagnifiablePoint> state) {
        double x = state.Magnifiable.Value;
        var f = state.Given.Equation.Function;
        state.Magnifiable.Value = Magnify(f, x);
    }
    private static double Magnify(Function f, double x) =>
        x - f(x) / f.GetDerivative()(x);
}
