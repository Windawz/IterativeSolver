
using IterativeSolver.Solving.Magnifiables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class IterationsMethodSolverState : State<MagnifiablePoint> {
    public IterationsMethodSolverState(Given given, MagnifiablePoint initialValue) : base(given, initialValue) { }

    public Function? Psi { get; set; } = null;
}
