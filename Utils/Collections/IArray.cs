
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Utils.Collections;
internal interface IArray<T> : IReadOnlyArray<T> {
    new T this[int index] { get; set; }

    T IReadOnlyArray<T>.this[int index] => this[index];

    T[] ToArray() => Enumerable.ToArray(this);
}
