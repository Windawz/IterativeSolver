using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Solvers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.PrecisionCheckers;
internal interface IPrecisionChecker {
    public Precision Precision { get; }

    public bool IsPrecise(IState state, IAbsolute absolute);
}
