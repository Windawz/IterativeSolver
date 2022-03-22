
using IterativeSolver.Solving.Magnifiables.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal abstract class PrecisionSolver<TState> : Solver<TState>
    where TState : IState {

    protected override bool MatchesStopConditions(TState state) { 
        Given given = state.Given;
        IPrecisionChecker checker = state.Magnifiable.GetPrecisionChecker();
        return checker.IsPrecise(given);
    }
}
