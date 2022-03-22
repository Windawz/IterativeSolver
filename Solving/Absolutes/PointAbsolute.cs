using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Absolutes;
internal class PointAbsolute : IAbsolute<double> {
    public double GetAbsolute(double value) => 
        value;
}
