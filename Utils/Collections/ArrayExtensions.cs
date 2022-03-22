
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Utils.Collections;

internal static class ArrayExtensions {
    public static IArray<T> Wrap<T>(this T[] array) => new ArrayWrapper<T>(array);
    public static IArray<T> Clone<T>(this IArray<T> array) => ((IEnumerable<T>)array).ToArray().Wrap();
    public static bool IndexInBounds<T>(this T[] array, int index) => array.Wrap().IndexInBounds(index);
    public static bool IndexInBounds<T>(this IArray<T> array, int index) => 0 <= index && index < array.Length;
    public static bool PointInBounds<T>(this T[][] array, Point point) =>
        0 <= point.X && point.X < array.GetLength(1)
        && 0 <= point.Y && point.Y < array.GetLength(0);
    public static void PerpendicularCopyTo<T>(this T[][] source, Point sourcePoint, T[][] dest,
                                              Point destPoint, int count) {

        if (!source.PointInBounds(sourcePoint)) {
            throw new ArgumentOutOfRangeException(nameof(sourcePoint));
        }
        if (!dest.PointInBounds(destPoint)) {
            throw new ArgumentOutOfRangeException(nameof(destPoint));
        }
        if (sourcePoint.X + count >= source.GetLength(1) || destPoint.Y + count >= dest.GetLength(0)) {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        for (int i = sourcePoint.X, j = destPoint.Y; i < sourcePoint.X + count; i++, j++) {
            T elem = source[sourcePoint.Y][i];
            dest[j][destPoint.X] = elem;
        }
    }

    private readonly struct ArrayWrapper<T> : IArray<T> {
        public ArrayWrapper(T[] array) {
            _array = array;
        }

        private readonly T[] _array;

        public T this[int index] {
            get => _array[index];
            set => _array[index] = value;
        }

        public int Length => _array.Length;

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_array).GetEnumerator();
        public T[] ToArray() => _array;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
