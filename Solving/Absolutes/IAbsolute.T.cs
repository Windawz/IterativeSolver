using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Absolutes;
internal interface IAbsolute<T> : IAbsolute
    where T : notnull {

    double GetAbsolute(T value);
    double IAbsolute.GetAbsolute(object value) =>
        GetAbsolute((T)value);
}
