// =================================================================
// Lazy.cs
//  
// Author:
//       Scott Wisniewski <scott@scottdw2.com>
// 
// Copyright (c) 2012 Scott Wisniewski
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// =================================================================
using System;
using Eddie.Runtime.CompilerServices;

namespace Eddie.Runtime
{
    /// <summary>
    /// Defines an interface for lazy evaluation. It is used as the run-time representation of pure values in Eddie Source code.
    /// All Eddie storage locations not marked with "val" or wrapped in the IO monad will use an instance of this type.
    /// </summary>
    [Pure]
    public interface Lazy<out T>
    {
        T Value { get; }
    }

    [Pure]
    public static class Lazy
    {
        /// <summary>
        /// Creates a Lazy&lt;T&gt; from a cached value.
        /// </summary>
        public static Lazy<T> ToLazy<T>(this T value)
        {
            return new CachedValue<T>(value);
        }

        /// <summary>
        /// Creates a Lazy&lt;T&gt; from a delegate for a T know to be a reference type.
        /// </summary>
        /// <remarks>
        /// This method should be preferred over <see cref="ToLazy"/> where possible.
        /// It uses a more efficent compare-and-swap operation to ensure idempotency,
        /// where as the ToLazy method must use a mutex.
        /// </remarks>
        public static Lazy<T> ToLazyReference<T>(this Func<T> func) where T : class
        {
            return new PureReference<T>(func);
        }

        /// <summary>
        /// Create's a Lazy&lt;T&gt; from a delegate for a T not known to be a reference type.
        /// </summary>
        public static Lazy<T> ToLazy<T>(this Func<T> f)
        {
            return new Pure<T>(f);
        }
    }
}

