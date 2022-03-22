using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Solving;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Utils;

namespace IterativeSolver.Solving.Solvers;
internal interface IState<TMagnifiable> : IState
    where TMagnifiable : IMagnifiable {

    new TMagnifiable Magnifiable { get; }

    IMagnifiable IState.Magnifiable => Magnifiable;
}
