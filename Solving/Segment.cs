using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;

internal readonly struct Segment {
    public Segment(double left, double right) {
        Left = left;
        Right = right;
    }

    public double Left { get; }
    public double Right { get; }
    public double Middle => (Left + Right) / 2;
    public double Length => Math.Abs(Right - Left);

    public static implicit operator Segment((double, double) tuple) =>
        new Segment(tuple.Item1, tuple.Item2);
    public override string ToString() => $"{{ {Left}, {Right} }}";
    public void Deconstruct(out double left, out double right) {
        left = Left;
        right = Right;
    }
}
