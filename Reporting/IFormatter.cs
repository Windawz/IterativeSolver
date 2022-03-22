using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;
internal interface IFormatter<T> {
    string Format(T value);
}
