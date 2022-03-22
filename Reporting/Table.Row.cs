using System.Collections;

using IterativeSolver.Utils.Collections;

namespace IterativeSolver.Reporting;

internal partial class Table {
    private class Row : IArray<Cell> {
        public Row(Cell[][] columns, int rowIndex) {
            if (columns.Length == 0 || columns[0].Length == 0) {
                throw new ArgumentException("Must have at least one cell to create a row", nameof(columns));
            }
            if (0 > rowIndex || rowIndex >= columns[0].Length) {
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            }

            _columns = columns;
            _rowIndex = rowIndex;
        }

        private readonly Cell[][] _columns;
        private readonly int _rowIndex;

        public Cell this[int index] {
            get => _columns[index][_rowIndex];
            set => _columns[index][_rowIndex] = value;
        }

        public int Length => _columns.Length;

        public IEnumerator<Cell> GetEnumerator() => GetEnumerable().GetEnumerator();

        private IEnumerable<Cell> GetEnumerable() {
            for (int i = 0; i < Length; i++) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerable().GetEnumerator();
    }
}
