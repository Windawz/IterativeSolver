using IterativeSolver.Solving;
using IterativeSolver.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal abstract class StateSolver<TState> : ISolver
    where TState : IState {

    public Variant<Solution, Failure> Solve(Given given) {
        ReactToGiven(given);

        var state = GetInitialState(given);

        while (!ShouldStop(state)) {
            IterateAndFailOnException(state);
        }

        return ToSolutionOrFailure(state);
    }

    protected virtual void ReactToGiven(Given given) { }
    protected abstract TState GetInitialState(Given given);
    protected virtual void PreStep(TState state) { }
    protected abstract void Step(TState state);
    protected virtual void PostStep(TState state) { }
    protected abstract bool MatchesStopConditions(TState state);
    protected abstract Solution GetSolution(TState state);

    private static void SetFailureOnStepsExceeded(TState state) {
        if (HasExceededMaxSteps(state)) {
            state.Failure = new Failure("Exceeded max steps");
        }
    }
    private static bool HasExceededMaxSteps(TState state) =>
        state.Steps > state.Given.MaxSteps;
    private static void IncrementSteps(TState state) =>
        state.Steps++;
    private void IterateAndFailOnException(TState state) {
        try {
            Iterate(state);
        } catch (Exception ex) {
            state.Failure = new Failure(ex.Message, ex);
        }
    }
    private void Iterate(TState state) {
        IncrementSteps(state);
        SetFailureOnStepsExceeded(state);
        PreStep(state);
        Step(state);
        PostStep(state);
    }
    private bool ShouldStop(TState state) =>
        state.Failure is not null 
        || MatchesStopConditions(state);
    private Variant<Solution, Failure> ToSolutionOrFailure(TState state) =>
        state.Failure is null ? GetSolution(state) : state.Failure;
}
