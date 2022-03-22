using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal abstract class PrecisionChecker : IPrecisionChecker {
    public abstract bool IsPrecise(IMagnifiable magnifiable, Given given);
}
