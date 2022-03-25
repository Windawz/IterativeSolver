using IterativeSolver.Solving;
using IterativeSolver.Solving.PrecisionCheckers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;
internal record Given(Equation Equation, Segment Segment, IPrecisionChecker PrecisionChecker, int MaxSteps);