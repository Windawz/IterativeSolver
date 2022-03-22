using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Utils;

internal class Variant<T1, T2> {

    public Variant(T1 value) {
        _value = EnsureNotNull(value)!;
    }
    public Variant(T2 value) {
        _value = EnsureNotNull(value)!;
    }

    private readonly object _value;

    public object Value => _value!;
    public T1 Value1 => Get<T1>();
    public T2 Value2 => Get<T2>();

    public static explicit operator T1(Variant<T1, T2> variant) => variant.Get<T1>();
    public static explicit operator T2(Variant<T1, T2> variant) => variant.Get<T2>();
    public static implicit operator Variant<T1, T2>(T1 value) => new Variant<T1, T2>(value);
    public static implicit operator Variant<T1, T2>(T2 value) => new Variant<T1, T2>(value);
    public T Get<T>() {
        if (TryGet<T>(out var output)) {
            return output!;
        } else {
            throw new InvalidOperationException($"No value of type {typeof(T)} is being stored in {nameof(Variant<T1, T2>)}");
        }
    }
    public bool TryGet<T>(out T output) {
        if (_value is T value) {
            output = value;
            return true;
        } else {
            output = default!;
            return false;
        }
    }
    public bool Is<T>() {
        return _value is T;
    }
    private static T EnsureNotNull<T>(T value) {
        if (value is not object) {
            throw new ArgumentNullException(nameof(value), $"{nameof(value)} may not be null");
        }

        return value;
    }
}
