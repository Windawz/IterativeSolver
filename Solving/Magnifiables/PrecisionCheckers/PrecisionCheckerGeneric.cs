using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal abstract class PrecisionChecker<TMagnifiable> : IPrecisionChecker
    where TMagnifiable : IMagnifiable {

    protected PrecisionChecker(TMagnifiable magnifiable) {
        Magnifiable = magnifiable;
    }

    protected TMagnifiable Magnifiable { get; }

    public abstract bool IsPrecise(Given given);
}
