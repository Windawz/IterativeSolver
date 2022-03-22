using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving;

internal record Equation(string Text, Function Function) {
    public override string ToString() => Text;
    public static Equation GetCubic(double a, double b, double c, double d) {
        if (a == 0.0) {
            throw new ArgumentOutOfRangeException(nameof(a), $"Leading term may not be zero");
        }

        string text =
            $"{(a < 0.0 ? SignToString(a) : "")}{(Math.Abs(a) == 1 ? Math.Abs(a) : "")}x^3" +
            $" {SignToString(b)} {Math.Abs(b)}x^2" +
            $" {SignToString(c)} {Math.Abs(c)}x" +
            $" {SignToString(d)} {Math.Abs(d)}";

        Function function = x =>
            a * Math.Pow(x, 3.0) +
            b * Math.Pow(x, 2.0) +
            c * x +
            d;

        return new Equation(text, function);
    }

    private static string SignToString(double number) {
        switch (Math.Sign(number)) {
            default:
            case 0:
                goto case 1;
            case 1:
                return "+";
            case -1:
                return "-";
        }
    }
}