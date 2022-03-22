using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;

internal class ReportFormatInfo {
    public int LeftWidth { get; set; } = 24;
    public int RightWidth { get; set; } = 72;
    public bool DrawFrame { get; set; } = true;
    public char FrameChar { get; set; } = '=';
}
