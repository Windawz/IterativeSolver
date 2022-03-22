using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables.PrecisionCheckers;
internal interface IPrecisionChecker<TMagnifiable> : IPrecisionChecker
    where TMagnifiable : IMagnifiable {
    bool IsPrecise(TMagnifiable magnifiable, Given given);
    bool IPrecisionChecker.IsPrecise(IMagnifiable magnifiable, Given given) =>
        IsPrecise((TMagnifiable)magnifiable, given);
}
