using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;
internal interface IMultilineFormatter<T> : IFormatter<T> {
    char[][] MultilineFormat(T value);
}
