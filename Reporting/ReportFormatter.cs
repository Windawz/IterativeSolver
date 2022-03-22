using IterativeSolver.Solving;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.Solvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;

internal class ReportFormatter : IFormatter<Report> {
    public ReportFormatter() : this(new ReportFormatInfo()) { }
    public ReportFormatter(ReportFormatInfo formatInfo) {
        FormatInfo = formatInfo;
    }

    public ReportFormatInfo FormatInfo { get; set; }

    public string Format(Report report) {
        var builder = new StringBuilder();

        AppendFrame(builder);
        builder.AppendLine();

        builder
            .AppendLine(FormatKeyValue("Equation", report.Goal.Given.Equation.Text))
            .AppendLine(FormatKeyValue("Solver", report.Goal.Solver.Name))
            .AppendLine(FormatKeyValue("Segment", report.Goal.Given.Segment));

        if (report.Goal.Solver is IStateSolver stateSolver) {
            Type magnifiableType = stateSolver.StateType.GetProperty(nameof(IState.Magnifiable))!.GetType();
            Type precisionCheckerType = magnifiableType.GetRuntimeMethod(nameof(IMagnifiable.GetPrecisionChecker))!.ReturnType;
            string precisionCheckerName = precisionCheckerType.Name;
            builder.AppendLine(FormatKeyValue("Precision checker", precisionCheckerName));
        }

        builder
            .AppendLine(FormatKeyValue("Maximum step amount", report.Goal.Given.MaxSteps));

        if (report.Solution.Is<Solution>()) {
            var solution = report.Solution.Get<Solution>();
            builder
                .AppendLine(FormatKeyValue("Root", solution.Root))
                .AppendLine(FormatKeyValue("Value", report.Goal.Given.Equation.Function(solution.Root)))
                .AppendLine(FormatKeyValue("Steps", solution.Steps));
        } else {
            var failure = report.Solution.Get<Failure>();
            builder.AppendLine(FormatKeyValue("Failure", failure.Message));
        }

        AppendFrame(builder);

        return builder.ToString();
    }
    private string GetFrame() {
        int frameLength = string.Format(GetPropertyFormat(), " ", " ").Length;
        return new string(FormatInfo.FrameChar, frameLength);
    }
    private void AppendFrame(StringBuilder builder) {
        if (!FormatInfo.DrawFrame) {
            return;
        }
        builder.Append(GetFrame());
    }
    private string FormatKeyValue(string key, object value) {
        string valueString = FormatValue(value);

        string format = GetPropertyFormat();
        return string.Format(format, key, valueString);
    }
    
    private string FormatValue(object value) => value switch {
        double d => d.ToString("e"),
        Precision precision => FormatValue(precision.Value),
        _ => value.ToString()!,
    };
    private string GetPropertyFormat() {
        return $"{{0,{-FormatInfo.LeftWidth}}} : {{1,{-FormatInfo.RightWidth}}}";
    }
}
