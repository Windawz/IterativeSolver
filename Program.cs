using System.Linq;

using IterativeSolver.Solving;
using IterativeSolver.Solving.Solvers;
using IterativeSolver.Reporting;

namespace IterativeSolver;

class Program {
    static void Main() {
        var solver = new BisectionSolver();

        var reports = PremadeGoals.Goals
        .OrderBy(g => g.Solver.Name)
        .ThenBy(g => g.Given.Equation.Text) // then order that list of Givens
        .ThenBy(g => g.Given.Segment.Left)
        .ThenByDescending(g => g.Given.Precision)
        .Select(g => new Report(g, g.Solver.Solve(g.Given))); // solve and project into reports

        foreach (var report in reports) {
            Console.WriteLine(report);
        }
    }
}