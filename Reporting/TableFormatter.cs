using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IterativeSolver.Utils.Collections;

namespace IterativeSolver.Reporting;

internal class TableFormatter : IMultilineFormatter<Table> {
    public TableFormatter() : this(new TableFormatInfo()) { }
    public TableFormatter(TableFormatInfo formatInfo) : this(
        formatInfo,
        new TableCellFormatter(new TableCellFormatInfo())) { }
    public TableFormatter(TableFormatInfo tableFormatInfo, IMultilineFormatter<Table.Cell> cellFormatter) {
        FormatInfo = tableFormatInfo;
        CellFormatter = cellFormatter;
    }

    public TableFormatInfo FormatInfo { get; set; }
    public IMultilineFormatter<Table.Cell> CellFormatter { get; set; }

    public string Format(Table value) {
        throw new NotImplementedException();
    }
    public char[][] MultilineFormat(Table value) {
        /*
        foreach (var column in value.Columns) {
            char[][][] cells = column.Select(c => CellFormatter.MultilineFormat(c)).ToArray();
            string framePart = GetFramePart(cells, FramePartDirection.Vertical);

        }
        */
        throw new NotImplementedException();
    }
    private string GetFramePart(IEnumerable<char[][]> cells, FramePartDirection direction) {
#pragma warning disable CS8524

        if (!Enum.IsDefined(direction)) {
            throw new ArgumentOutOfRangeException(nameof(direction));
        }

        char frameChar = direction switch {
            FramePartDirection.Horizontal => FormatInfo.HorizontalLineChar,
            FramePartDirection.Vertical => FormatInfo.VerticalLineChar,
        };
        char intersectionChar = FormatInfo.IntersectionChar;

        bool isFirst = true;
        var sb = new StringBuilder();
        foreach (var cell in cells) {
            if (isFirst) {
                sb.Append(intersectionChar);
            }
            isFirst = false;

            int count = direction switch {
                FramePartDirection.Horizontal => cell[0].Count(),
                FramePartDirection.Vertical => cell.Count(),
            };

            sb.Append(new string(frameChar, count))
                .Append(intersectionChar);
        }

        return sb.ToString();

#pragma warning restore CS8524
    }
    private int GetTotalWidth(IEnumerable<char[][]> cellRow) {
        int totalCellWidth = cellRow.Aggregate(0, (w, c) => w + GetCellWidth(c));
        int intersections = cellRow.Count() + 1;
        return totalCellWidth + intersections;
    }
    private int GetTotalHeight(IEnumerable<char[][]> cellColumn) {
        int totalCellHeight = cellColumn.Aggregate(0, (h, c) => h + GetCellHeight(c));
        int intersections = cellColumn.Count() + 1;
        return totalCellHeight + intersections;
    }
    private int GetCellWidth(char[][] cell) =>
        cell[0].Length;
    private int GetCellHeight(char[][] cell) =>
        cell.Length;

    private enum FramePartDirection {
        Horizontal,
        Vertical,
    }
}
