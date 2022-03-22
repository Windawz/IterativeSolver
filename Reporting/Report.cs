using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Solving;
using IterativeSolver.Solving.Solvers;
using IterativeSolver.Utils;

namespace IterativeSolver.Reporting;

internal class Report {
    public Report(Goal goal, Variant<Solution, Failure> solution) {
        Goal = goal;
        Solution = solution;
    }

    public Goal Goal { get; }
    public Variant<Solution, Failure> Solution { get; }

    public override string ToString() => ToString(new ReportFormatter());
    public string ToString(ReportFormatter formatter) {
        return formatter.Format(this);
    }
}
