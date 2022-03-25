
using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;

using TState = IterationsMethodSolverState;

internal class IterationsMethodSolver : PrecisionSolver<TState> {
    public IterationsMethodSolver(IPrecisionChecker precisionChecker) : base(precisionChecker) { }

    protected override IAbsolute? Absolute { get; set; } = new PointAbsolute();

    protected override TState GetInitialState(Given given) =>
        new(given, new Magnifiable<double>(given.Segment.Right));
    protected override void Step(TState state) {
        TrySetPsiOrFail(state);
        if (state.Psi is null) {
            return;
        }

        state.Magnifiable.Value = state.Psi(state.Magnifiable.Value);
    }
    private static void TrySetPsiOrFail(TState state) {
        state.Psi = TryGetPsi(state.Magnifiable.Value, state.Given.Equation.Function, state.Given.Segment);
        if (state.Psi is null) {
            state.Failure = new("Failed to get a suitable psi function");
        }
    }
    private static Function? TryGetPsi(double x, Function f, Segment s) {
        double? k = TryGetMatchingK(x, f, s);
        if (k is null) {
            return null;
        }

        return x => x - f(x) / (double)k;
    }
    private static double? TryGetMatchingK(double x, Function f, Segment s) {
        double q = s.DivideInto(0.01).ToPoints().Max(p => f(p));
        double ffx = f.GetDerivative()(x);
        double k = GetKFromQ(q);
        if (Math.Sign(k) == Math.Sign(ffx)) {
            return q;
        } else {
            return null;
        }
    }
    private static double GetKFromQ(double q) => q switch {
        _ when q / 2 < 0 => Math.Abs(q),
        _ => Math.Abs(q) + 1.0,
    };
}
