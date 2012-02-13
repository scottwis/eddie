// =================================================================
// ImmutableList.cs
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

namespace Eddie.Runtime.Collections
{
    /// <summary>
    /// Defines a dynamically typed interface for an ImmutableList.
    /// All list types in Eddie implement this interface. It is
    /// primarily inteded to be used by pattern matching.
    /// </summary>
    [Pure]
    public interface ImmutableList
    {
        object Head { get; }
        ImmutableList Tail { get; }
    }

    /// <summary>
    /// Defines a covariant immutable list interface. It is used as the runtime representation
    /// for list values ([T]) in Eddie code.
    /// </summary>
    /// <remarks>Note: This type is defined as an interface to enable use of the built-in generic variance
    /// support in the CLR. It is not intended to be implemented by user code. Incorrect implementations of this interface are
    /// dangerous and may break any Eddie code that uses them The Eddie Compiler will not allow
    /// custom implemetnations of this interface in Eddie source files, and will reject references to any assembly other than
    /// the Eddie Runtime Library that contains custom implementations of it. </remarks>
    [Pure]
    public interface ImmutableList<out T> : ImmutableList
    {
    	new T Head { get; }
		new ImmutableList<T> Tail {get; }
    }
}

