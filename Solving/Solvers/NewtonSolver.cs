
using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;

using TState = State<Magnifiable<double>>;

internal class NewtonSolver : PrecisionSolver<TState> {
    public NewtonSolver(IPrecisionChecker precisionChecker) : base(precisionChecker) { }

    protected override IAbsolute? Absolute { get; set; } = new PointAbsolute();

    protected override TState GetInitialState(Given given) =>
        new(given, new Magnifiable<double>(given.Segment.Right));
    protected override void Step(TState state) {
        double x = state.Magnifiable.Value;
        var f = state.Given.Equation.Function;
        state.Magnifiable.Value = Magnify(f, x);
    }
    private static double Magnify(Function f, double x) =>
        x - f(x) / f.GetDerivative()(x);
}
