
using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal interface IMagnifiable {
    object Value { get; set; }
    double Absolute => GetAbsolute(Value);
    object? LastValue { get; }
    double? LastAbsolute => LastValue is null ? null : GetAbsolute(LastValue);

    double GetAbsolute(object value);
    IPrecisionChecker GetPrecisionChecker();
}
