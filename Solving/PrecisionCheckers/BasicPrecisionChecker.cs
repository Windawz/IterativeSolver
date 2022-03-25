using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Solvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal abstract class BasicPrecisionChecker : IPrecisionChecker {
    public BasicPrecisionChecker(Precision precision) {
        Precision = precision;
    }

    public Precision Precision { get; set; }

    public abstract bool IsPrecise(IState state, IAbsolute absolute);
}
