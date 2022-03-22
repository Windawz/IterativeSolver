
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal abstract class PrecisionSolver<TState, TChecker> : Solver<TState>, IPrecisionSolver<TChecker>
    where TState : IState 
    where TChecker : IPrecisionChecker {

    public abstract TChecker PrecisionChecker { get; }

    protected override bool MatchesStopConditions(TState state) { 
        Given given = state.Given;
        IMagnifiable magnifiable = state.Magnifiable;
        IPrecisionChecker checker = PrecisionChecker;
        return checker.IsPrecise(magnifiable, given);
    }
}
