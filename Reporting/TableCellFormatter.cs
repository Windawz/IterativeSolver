using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;
internal class TableCellFormatter : IMultilineFormatter<Table.Cell> {
    public TableCellFormatter() : this(new TableCellFormatInfo()) { }
    public TableCellFormatter(TableCellFormatInfo formatInfo) {
        FormatInfo = formatInfo;
        _wordWrapper = new WordWrapper(FormatInfo.MaxCellWidth, " ");
    }

    private WordWrapper _wordWrapper;

    public TableCellFormatInfo FormatInfo { get; set; }

    public string Format(Table.Cell value) {
        char[][] cell = MultilineFormat(value);
        return CharMatrixToString(cell);
    }
    public char[][] MultilineFormat(Table.Cell value) {
        var lines = new List<string>(_wordWrapper.Wrap(value.Text));
        TruncateLines(lines);
        lines[^1] = AddTruncationMark(lines[^1]);

        int width = GetMaxLineWidth(lines);
        int height = lines.Count;

        char[][] cell = GetPaddedCell(width, height);
        FillPaddedCell(cell, lines);

        return cell;
    }
    private string CharMatrixToString(char[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) {
            return "";
        }

        var sb = new StringBuilder(matrix.Length * matrix[0].Length);

        for (int i = 0; i < matrix.Length; i++) {
            var str = new string(matrix[i]);
            if (i != matrix.Length - 1) {
                sb.AppendLine(str);
            } else {
                sb.Append(str);
            }
        }

        return sb.ToString();
    }
    private void FillPaddedCell(char[][] cell, List<string> lines) {
        if (cell.Length == lines.Count && cell.Length == 0) {
            return;
        }
        if (cell.Length != lines.Count || cell[0].Length < lines[0].Length) {
            throw new ArgumentException("Cell dimensions don't match with lines");
        }

        for (int i = 0; i < lines.Count; i++) {
            string line = lines[i];
            int rowIndex = i + FormatInfo.VerticalCellPadding;
            int colIndex = FormatInfo.HorizontalCellPadding;
            char[] row = cell[rowIndex];
            line.CopyTo(0, row, colIndex, line.Length);
        }
    }
    private char[][] GetPaddedCell(int width, int height) {
        int paddedWidth = width + FormatInfo.HorizontalCellPadding * 2;
        int paddedHeight = height + FormatInfo.VerticalCellPadding * 2;

        var arrays = new char[paddedHeight][];

        for (int i = 0; i < arrays.Length; i++) {
            arrays[i] = new char[paddedWidth];
        }

        return arrays;
    }
    private int GetMaxLineWidth(IEnumerable<string> lines) =>
        lines.Max(s => s.Length);
    private void TruncateLines(List<string> lines) {
        if (lines.Count == 0) {
            return;
        }

        int maxHeight = FormatInfo.MaxCellHeight;
        if (lines.Count > maxHeight) {
            lines.RemoveRange(maxHeight, lines.Count - maxHeight);
        }
    }
    private string AddTruncationMark(string lastLine) {
        var sb = new StringBuilder(lastLine);
        string mark = FormatInfo.TruncationMark;
        sb.Remove(sb.Length - mark.Length, mark.Length);
        sb.Insert(sb.Length, mark);
        return sb.ToString();
    }
}
