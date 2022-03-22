using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Utils.Collections;

namespace IterativeSolver.Reporting;

internal partial class Table {
    public Table(Cell[][] columns) {
        if (!ColumnsHaveSameLength(columns)) {
            throw new ArgumentException("Columns must have the same length", nameof(columns));
        }

        _columns = (Cell[][])columns.Clone();
    }

    private readonly Cell[][] _columns;

    public IArray<Cell>[] Columns => Array.ConvertAll(_columns, c => c.Wrap());
    public IArray<Cell>[] Rows {
        get {
            int rowCount = _columns.Length > 0 ? _columns[0].Length : 0;
            IArray<Cell>[] rows = new Row[rowCount];
            for (int i = 0; i < rowCount; i++) {
                rows[i] = new Row(_columns, i);
            }

            return rows;
        }
    }

    private static bool ColumnsHaveSameLength(Cell[][] columns) {
        foreach (var c in columns) {
            if (c.Length != columns[0].Length) {
                return false;
            }
        }

        return true;
    }
}
