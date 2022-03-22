
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class SecantSolver : PrecisionSolver<State<MagnifiableSegmentYDifference>, BySegmentYDifferencePrecisionChecker> {
    public override BySegmentYDifferencePrecisionChecker PrecisionChecker =>
        new();

    protected override State<MagnifiableSegmentYDifference> GetInitialState(Given given) =>
        new State<MagnifiableSegmentYDifference>(given, new(given.Segment, given.Equation.Function));
    protected override void Step(State<MagnifiableSegmentYDifference> state) {
        Segment s = state.Magnifiable.Value;
        state.Magnifiable.Value = Magnify(s, state.Given.Equation.Function);
    }
    private static Segment Magnify(Segment s, Function f) {
        double x0 = s.Left;
        double x1 = s.Right;
        double fx0 = f(x0);
        double fx1 = f(x1);

        double x2 = x1 - fx1 * ((x1 - x0) / (fx1 - fx0));

        return (x1, x2);
    }
}
