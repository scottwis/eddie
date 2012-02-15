// =================================================================
// Pattern.cs
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
using Eddie.Runtime.Collections;
using Eddie.Runtime.CompilerServices;

namespace Eddie.Runtime
{
    [Pure]
    public static class Pattern
    {
        public static Lazy<R> Match<T,R>(
            Lazy<T> value, //value :: T
            Lazy<ImmutableList<Tuple<Func<Lazy<T>, Lazy<bool>>, Func<Lazy<T>, Lazy<R>>>>> patterns //patterns :: [(T->bool, T->R)]
        )
        {
            return Match(value, patterns, x=>x.ToLazy());
        }

        public static Lazy<R> MatchReference<T,R>(
            Lazy<T> value, //T value
            Lazy<ImmutableList<Tuple<Func<Lazy<T>, Lazy<bool>>, Func<Lazy<T>, Lazy<R>>>>> patterns //patterns :: [(T->bool, T->R)]
        ) where R : class
        {
            return Match(value, patterns, x=>x.ToLazyReference());
        }

        private static Lazy<R> Match<T, R>(
            Lazy<T> value, //value :: T
            Lazy<ImmutableList<Tuple<Func<Lazy<T>, Lazy<bool>>, Func<Lazy<T>, Lazy<R>>>>> patterns, //patterns :: [(T->bool, T->R)]
            Func<Func<R>, Lazy<R>> createLazy //createLazy :: (val (void->R))->R
        )
        {
            if (value == null) {
                throw new ArgumentNullException("value");
            }

            if (patterns == null) {
                throw new ArgumentNullException("patterns");
            }

            while (patterns.Value != null) {
                var tuple = patterns.Value.Head;

                if (tuple == null || tuple.Value == null || tuple.Value.Item1 == null || tuple.Value.Item1.Value == null) {
                    throw new ArgumentException("Invalid pattern value", "patterns");
                }

                if (tuple.Value.Item1.Value(value).Value) {
                    Func<R> f = ()=>tuple.Value.Item2.Value(value).Value;
                    return createLazy(f);
                }

                patterns = patterns.Value.Tail;
            }

            throw new InvalidOperationException("Unable to match the provided value to a pattern.");
        }
    }
}

