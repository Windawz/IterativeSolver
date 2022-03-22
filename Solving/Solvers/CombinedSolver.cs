
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class CombinedSolver : PrecisionSolver<State<MagnifiableSegmentMiddle>, ByYPrecisionChecker> {
    public override ByYPrecisionChecker PrecisionChecker =>
        new();

    protected override State<MagnifiableSegmentMiddle> GetInitialState(Given given) =>
        new(given, new MagnifiableSegmentMiddle(given.Segment));
    protected override void Step(State<MagnifiableSegmentMiddle> state) {
        var f = state.Given.Equation.Function;
        var value = state.Magnifiable.Value;
        state.Magnifiable.Value = Magnify(f, value);
    }
    private static Segment Magnify(Function f, Segment s) {
        double product = GetDerivativeProduct(f, s.Right);
        return CalculateNewSegment(f, s, product);
    }
    private static Segment CalculateNewSegment(Function f, Segment s, double derivativeProduct) {
        if (derivativeProduct > 0) {
            return (FormulaB(s.Left, s.Right, f), FormulaA(s.Right, f));
        } else {
            return (FormulaA(s.Left, f), FormulaC(s.Left, s.Right, f));
        }
    }
    private static double FormulaA(double a, Function f) => 
        a - f(a) / f.GetDerivative()(a);
    private static double FormulaB(double a, double b, Function f) {
        double fa = f(a);
        double fb = f(b);
        return a - (b - a) / (fb - fa) * fa;
    }
    private static double FormulaC(double a, double b, Function f) {
        double fa = f(a);
        double fb = f(b);
        return b - (b - a) / (fb - fa) * fb;
    }

    private static double GetDerivativeProduct(Function f, double x) =>
        f.GetDerivative()(x) * f.GetNthDerivative(2)(x);
}
