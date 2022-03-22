using IterativeSolver.Solving;
using IterativeSolver.Solving.Magnifiables;
using IterativeSolver.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class State<TMagnifiable> : IState<TMagnifiable>
    where TMagnifiable : IMagnifiable {

    public State(Given given, TMagnifiable magnifiable) {
        Given = given;
        Magnifiable = magnifiable;
    }

    public Given Given { get; }
    public int Steps { get; set; } = 0;
    public TMagnifiable Magnifiable { get; }
    public Failure? Failure { get; set; } = null;
}
