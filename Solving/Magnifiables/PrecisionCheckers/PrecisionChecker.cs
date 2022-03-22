using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal abstract class PrecisionChecker : IPrecisionChecker {
    protected PrecisionChecker(IMagnifiable magnifiable) {
        Magnifiable = magnifiable;
    }

    protected IMagnifiable Magnifiable { get; }

    public abstract bool IsPrecise(Given given);
}
