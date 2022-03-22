using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;
internal static class SegmentExtensions {
    public static IEnumerable<Segment> Subdivide(this Segment segment) {
        yield return (segment.Left, segment.Middle);
        yield return (segment.Middle, segment.Right);
    }
    public static IEnumerable<Segment> Subdivide(this Segment segment, int subdivisionCount) => subdivisionCount switch {
        1 => Subdivide(segment),
        var c when c > 0 => Subdivide(segment).SelectMany(s => s.Subdivide(c - 1)),
        _ => throw new ArgumentOutOfRangeException(nameof(subdivisionCount)),
    };
    public static IEnumerable<Segment> DivideInto(this Segment segment, int count) {
        if (count <= 0) {
            throw new ArgumentOutOfRangeException(nameof(count));
        }
        if (count == 1) {
            yield return segment;
        }

        double length = segment.Length;
        double step = length / count;
        double end = length - step;
        for (double left = 0.0; left < end; left += step) {
            yield return (left, left + step);
        }
    }
    public static IEnumerable<Segment> DivideInto(this Segment segment, double size) => size switch {
        _ when size > 0 => segment.DivideInto((int)(segment.Length / size)),
        _ => throw new ArgumentOutOfRangeException(nameof(size)),
    };
    public static IEnumerable<double> ToPoints(this Segment segment) {
        yield return segment.Left;
        yield return segment.Right;
    }
    public static IEnumerable<double> ToPoints(this IEnumerable<Segment> segments) =>
        segments.SelectMany(s => s.ToPoints()).Distinct();
}
