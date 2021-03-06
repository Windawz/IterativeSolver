using IterativeSolver.Solving.Magnifiables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class SimplifiedNewtonSolverState : State<Magnifiable<double>> {
    public SimplifiedNewtonSolverState(Given given, Magnifiable<double> initialValue) : base(given, initialValue) {
        CachedDerivative = given.Equation.Function.GetDerivative()(Magnifiable.Value);
    }

    public double CachedDerivative { get; }
}
