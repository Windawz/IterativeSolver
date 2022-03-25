
using IterativeSolver.Solving.Absolutes;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal abstract class PrecisionSolver<TState> : StateSolver<TState>, IPrecisionSolver
    where TState : IState {

    protected PrecisionSolver(IPrecisionChecker precisionChecker) {
        PrecisionChecker = precisionChecker;
    }

    public IPrecisionChecker PrecisionChecker { get; }
    protected abstract IAbsolute? Absolute { get; set; }

    protected override bool MatchesStopConditions(TState state) { 
        if (Absolute is null) {
            throw new InvalidOperationException($"{nameof(Absolute)} has not been set");
        }
        return PrecisionChecker.IsPrecise(state, Absolute);
    }
    protected override Solution GetSolution(TState state) => Absolute is not null ?
        new Solution(Absolute.GetAbsolute(state.Magnifiable.Value), state.Steps)
        : throw new InvalidOperationException($"{nameof(Absolute)} is null");
}
