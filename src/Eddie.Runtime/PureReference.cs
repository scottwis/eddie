// =================================================================
// PureReference.cs
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
using System.Threading;

namespace Eddie.Runtime
{
    sealed class PureReference<T> : Lazy<T> where T : class
    {
        private readonly Func<T> m_func;
        private T m_cached;
        private bool m_executed;

        public PureReference(Func<T> func)
        {
            m_func = func.ArgNotNull("func");
        }

        public T Value
        {
            get
            {
                if (!m_executed) {
                    T value = m_func();
                    Interlocked.CompareExchange(ref m_cached, value, null);
                    m_executed = true;
                }
                return m_cached;
            }
        }

    }
}

