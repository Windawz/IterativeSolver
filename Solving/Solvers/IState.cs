using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal interface IState {
    Given Given { get; }
    int Steps { get; set; }
    Failure? Failure { get; set; }
    IMagnifiable Magnifiable { get; }

    Variant<Solution, Failure> ToSolutionOrFailure() => Failure is null ?
         new(new Solution(Magnifiable.Absolute, Steps)) : new(Failure);
}
