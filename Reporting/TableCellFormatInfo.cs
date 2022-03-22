using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;
internal class TableCellFormatInfo {
    public int HorizontalCellPadding { get; set; } = 1;
    public int VerticalCellPadding { get; set; } = 1;
    public int MaxCellWidth { get; set; } = 48;
    public int MaxCellHeight { get; set; } = 4;
    public string TruncationMark { get; set; } = "...";
}
