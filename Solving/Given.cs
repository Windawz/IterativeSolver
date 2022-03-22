using IterativeSolver.Solving;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;
internal record Given(Equation Equation, Segment Segment, Precision Precision, int MaxSteps);