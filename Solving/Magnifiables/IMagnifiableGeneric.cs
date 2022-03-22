
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal interface IMagnifiable<T> : IMagnifiable
    where T : notnull {
    new T Value { get; set; }
    new double Absolute => ((IMagnifiable)this).Absolute;
    new T? LastValue { get; }
    new double? LastAbsolute => ((IMagnifiable)this).LastAbsolute;
    object IMagnifiable.Value {
        get => Value;
        set {
            Type inputType = value.GetType();
            Type expectedType = typeof(T);
            if (inputType != expectedType) {
                throw new ArgumentException(nameof(value),
                    $"Type mismatch (input type: {inputType}, should be {expectedType})");
            }
            Value = (T)value;
        }
    }
    object? IMagnifiable.LastValue {
        get => LastValue;
    }

    double GetAbsolute(T value);
    double IMagnifiable.GetAbsolute(object value) => GetAbsolute((T)value);
}
