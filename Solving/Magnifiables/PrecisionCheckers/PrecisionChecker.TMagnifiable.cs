using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal abstract class PrecisionChecker<TMagnifiable> : IPrecisionChecker<TMagnifiable>
    where TMagnifiable : IMagnifiable {

    public abstract bool IsPrecise(TMagnifiable magnifiable, Given given);
}
