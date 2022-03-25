
using IterativeSolver.Solving.Magnifiables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Solvers;
internal class IterationsMethodSolverState : State<Magnifiable<double>> {
    public IterationsMethodSolverState(Given given, Magnifiable<double> initialValue) : base(given, initialValue) { }

    public Function? Psi { get; set; } = null;
}
