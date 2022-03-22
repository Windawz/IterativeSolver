using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal interface IPrecisionSolver : ISolver {
    IPrecisionChecker PrecisionChecker { get; }
}
