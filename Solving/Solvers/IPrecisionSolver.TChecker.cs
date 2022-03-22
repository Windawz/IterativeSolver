using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal interface IPrecisionSolver<TChecker> : IPrecisionSolver 
    where TChecker : IPrecisionChecker {
    new TChecker PrecisionChecker { get; }
}
