using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Utils;

internal static class LinqExtensions {
    public static IEnumerable<(T1, T2)> CartesianProduct<T1, T2>(this IEnumerable<T1> first,
                                                                 IEnumerable<T2> second) =>
        first.SelectMany(_ => second, (f, s) => (f, s));
    public static IEnumerable<(T1, T2, T3)> CartesianProduct<T1, T2, T3>(this IEnumerable<T1> first,
                                                                         IEnumerable<T2> second,
                                                                         IEnumerable<T3> third) =>
        first.CartesianProduct(second)
        .SelectMany(_ => third, (tuple, elem) => (tuple.Item1, tuple.Item2, elem));
    public static IEnumerable<(T1, T2, T3, T4)> CartesianProduct<T1, T2, T3, T4>(this IEnumerable<T1> first,
                                                                                 IEnumerable<T2> second,
                                                                                 IEnumerable<T3> third,
                                                                                 IEnumerable<T4> fourth) =>
        first.CartesianProduct(second, third)
        .SelectMany(_ => fourth, (tuple, elem) => (tuple.Item1, tuple.Item2, tuple.Item3, elem));
    public static IEnumerable<(T1, T2, T3, T4, T5)> CartesianProduct<T1, T2, T3, T4, T5>(this IEnumerable<T1> first,
                                                                                 IEnumerable<T2> second,
                                                                                 IEnumerable<T3> third,
                                                                                 IEnumerable<T4> fourth,
                                                                                 IEnumerable<T5> fifth) =>
        first.CartesianProduct(second, third, fourth)
        .SelectMany(_ => fifth, (tuple, elem) => (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, elem));
    public static IEnumerable<(T1, T2, T3, T4, T5, T6)> CartesianProduct<T1, T2, T3, T4, T5, T6>(this IEnumerable<T1> first,
                                                                                 IEnumerable<T2> second,
                                                                                 IEnumerable<T3> third,
                                                                                 IEnumerable<T4> fourth,
                                                                                 IEnumerable<T5> fifth,
                                                                                 IEnumerable<T6> sixth) =>
        first.CartesianProduct(second, third, fourth, fifth)
        .SelectMany(_ => sixth, (tuple, elem) => (tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, elem));
}
