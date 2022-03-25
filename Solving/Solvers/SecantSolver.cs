
using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;

using TState = State<Magnifiable<Segment>>;

internal class SecantSolver : PrecisionSolver<TState> {
    public SecantSolver(Precision precision) : base(new AbsoluteChecker(precision)) { }

    protected override IAbsolute? Absolute { get; set; }

    protected override void ReactToGiven(Given given) { 
        base.ReactToGiven(given);

        Absolute = new SegmentFunctionalDifferenceAbsolute(given.Equation.Function);
    }
    protected override TState GetInitialState(Given given) =>
        new(given, new Magnifiable<Segment>(given.Segment));
    protected override void Step(TState state) {
        Segment s = state.Magnifiable.Value;
        state.Magnifiable.Value = Magnify(s, state.Given.Equation.Function);
    }
    protected override Solution GetSolution(TState state) =>
        new(state.Magnifiable.Value.Right, state.Steps);
    private static Segment Magnify(Segment s, Function f) {
        double x0 = s.Left;
        double x1 = s.Right;
        double fx0 = f(x0);
        double fx1 = f(x1);

        double x2 = x1 - fx1 * ((x1 - x0) / (fx1 - fx0));

        return (x1, x2);
    }
}
