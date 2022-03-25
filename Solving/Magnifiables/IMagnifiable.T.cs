
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Solving.Magnifiables;
internal interface IMagnifiable<T> : IMagnifiable
    where T : notnull {
    new T Value { get; set; }
    new T? LastValue { get; }
    object IMagnifiable.Value {
        get => Value;
        set {
            Type inputType = value.GetType();
            Type expectedType = typeof(T);
            if (inputType != expectedType) {
                throw new ArgumentException(
                    $"Type mismatch (input type: {inputType}, should be {expectedType})",
                    nameof(value));
            }
            Value = (T)value;
        }
    }
    object? IMagnifiable.LastValue {
        get => LastValue;
    }
}
