using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Solving.Solvers;
using IterativeSolver.Utils;

namespace IterativeSolver.Solving;

internal static class PremadeGoals {
    public static IEnumerable<Equation> Equations = new Equation[] {
        Equation.GetCubic(1.0, 0.0, 3.0, 1.0),
    };

    public static IEnumerable<Segment> Segments = new Segment[] {
        (-1.0, 1.0),
    };

    public static IEnumerable<Precision> Precisions { get; } = new Precision[] {
        new(0.001),
    };

    public static IEnumerable<ISolver> Solvers = new ISolver[] {
        new BisectionSolver(),
        new SecantSolver(),
        new NewtonSolver(),
        new SimplifiedNewtonSolver(),
        new CombinedSolver(),
        new IterationsMethodSolver(),
    };

    public static IEnumerable<int> MaxSteps = new int[] {
        2500,
    };

    public static IEnumerable<Given> Givens { get; } = Equations
        .CartesianProduct(Segments, Precisions, MaxSteps)
        .Select(tuple => new Given(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));

    public static IEnumerable<Goal> Goals { get; } = Solvers
        .CartesianProduct(Givens)
        .Select(tuple => new Goal(tuple.Item1, tuple.Item2));
}
