using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;
internal static class FunctionExtensions {
    private static readonly double _derivativeDifference = 10.0e-6;

    public static Function GetNthDerivative(this Function f, int n) {
        if (n < 0) {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        Function newFunc = f;
        for (int i = 0; i < n; i++) {
            newFunc = newFunc.GetDerivative();
        }

        return newFunc;
    }
    public static Function GetDerivative(this Function f) {
        double h = _derivativeDifference;
        double h2 = h * 2;

        return x => (f(x - h2) - 8 * f(x - h) + 8 * f(x + h) - f(x + h2)) / (h2 * 6);
    }
}
