using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Utils;

namespace IterativeSolver.Solving.Solvers;

internal interface ISolver {
    string Name => GetType().Name;

    Variant<Solution, Failure> Solve(Given given);
    string? ToString() => Name;
}
