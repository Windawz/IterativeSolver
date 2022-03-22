using IterativeSolver.Solving.Magnifiables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class SimplifiedNewtonSolver : PrecisionSolver<SimplifiedNewtonSolverState> {
    protected override SimplifiedNewtonSolverState GetInitialState(Given given) =>
        new(given, new MagnifiablePoint(given.Segment.Right));
    protected override void Step(SimplifiedNewtonSolverState state) {
        double x = state.Magnifiable.Value;
        var f = state.Given.Equation.Function;
        state.Magnifiable.Value = x - f(x) / state.CachedDerivative;
    }
}
