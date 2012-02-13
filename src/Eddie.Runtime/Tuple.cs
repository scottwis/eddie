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
    [Pure]
    public interface Tuple
    {
        int Count { get; }
        object Item(int index);
    }

    [Pure]
    public interface Tuple<out T1, out T2> : Tuple
    {
        T1 Item1 { get;}
        T2 Item2 { get;}
    }

    [Pure]
    public interface Tuple<out T1, out T2, out T3> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
    }

    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
    }

    [Pure]
    public interface Tuple<out T1, out T2, out T3, out T4, out T5> : Tuple
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
        T3 Item3 { get; }
        T4 Item4 { get; }
        T5 Item5 { get;}
    }

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
}

