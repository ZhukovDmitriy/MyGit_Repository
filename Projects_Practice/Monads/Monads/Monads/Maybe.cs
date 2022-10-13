using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Monads
{
    public class Maybe<T>
    {
        public T _val { get; set; }
        public bool _isInitialized { get; set; }

        private Maybe(T val, bool isInitialized) =>
            (_val, _isInitialized) = (val, isInitialized);

        public static Maybe<T> None() =>
            new Maybe<T>(default, false);

        public static Maybe<T> Just([NotNull] T val) =>
             new Maybe<T>(val ?? throw new ArgumentNullException(nameof(val)), true);

        public Maybe<TRes> Select<TRes>(Func<T, TRes> mapper) =>
            _isInitialized ? Maybe<TRes>.Just(mapper(_val)) : Maybe<TRes>.None();

        public TRes Match<TRes>(Func<T, TRes> onSome, Func<TRes> onEmpty) =>
            _isInitialized ? onSome(_val) : onEmpty(); 
    }
}
