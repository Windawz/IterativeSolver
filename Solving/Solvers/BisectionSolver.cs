
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

internal class BisectionSolver : PrecisionSolver<TState> {
    public BisectionSolver(IPrecisionChecker precisionChecker) : base(precisionChecker) { }

    protected override void ReactToGiven(Given given) {
        ThrowIfSameSignOnBothEnds(given);
        base.ReactToGiven(given);
    }

    protected override IAbsolute? Absolute { get; set; } = new SegmentMiddleAbsolute();

    protected override TState GetInitialState(Given given) =>
        new(given, new Magnifiable<Segment>(given.Segment));
    protected override void Step(TState state) {
        Segment s = state.Magnifiable.Value;
        var f = state.Given.Equation.Function;
        state.Magnifiable.Value = Magnify(f, s);
    }

    private static void ThrowIfSameSignOnBothEnds(Given given) {
        if (!HasOppositeSigns(given.Equation.Function, given.Segment)) {
            throw new ArgumentException("Segment has same sign on both ends", nameof(given));
        }
    }
    private static bool HasOppositeSigns(Function f, Segment s) {
        double left = f(s.Left);
        double right = f(s.Right);

        return left < 0 && right > 0 || left > 0 && right < 0;
    }
    private static Segment Magnify(Function f, Segment s) {
        double x = s.Middle;
        double y = f(x);

        if (y > 0.0) {
            return (s.Left, x);
        } else if (y < 0.0) {
            return (x, s.Right);
        } else {
            return (x, x);
        }
    }

    
}
