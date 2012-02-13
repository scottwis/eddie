// =================================================================
// Tuple.cs
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

namespace Eddie.Runtime
{
    /// <summary>
    /// Defines a dynamically typed interface that serves as a base
    /// for all tuple types.
    /// </summary>
    [Pure]
    public interface Tuple
    {
        int Count { get; }
        object Item(int index);
    }

    /// <summary>
    /// Defines a covariant interface for a 2 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2> : Tuple
    {
        T1 Item1 { get;}
        T2 Item2 { get;}
    }

    /// <summary>
    /// Defines a covariant interface for a 3 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 4 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 5 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get;}
    }

    /// <summary>
    /// Defines a covariant interface for a 6 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 7 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 8 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 9 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 10 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
        T10 Item10 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for an 11 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
        T10 Item10 { get; }
        T11 Item11 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 12 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
        T10 Item10 { get; }
        T11 Item11 { get; }
        T12 Item12 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 13 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
        T10 Item10 { get; }
        T11 Item11 { get; }
        T12 Item12 { get; }
        T13 Item13 { get; }
    }

    /// <summary>
    /// Defines a covariant interface for a 14 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
        T10 Item10 { get; }
        T11 Item11 { get; }
        T12 Item12 { get; }
        T13 Item13 { get; }
        T14 Item14 { get;}
    }

    /// <summary>
    /// Defines a covariant interface for a 15 element tuple.
    /// </summary>
    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get; }
        T6 Item6 { get; }
        T7 Item7 { get; }
        T8 Item8 { get; }
        T9 Item9 { get; }
        T10 Item10 { get; }
        T11 Item11 { get; }
        T12 Item12 { get; }
        T13 Item13 { get; }
        T14 Item14 { get; }
        T15 Item15 { get; }
    }
}

