
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Utils.Collections;
internal interface IReadOnlyArray<T> : IEnumerable<T> {
    int Length { get; }

    T this[int index] { get; }
}
