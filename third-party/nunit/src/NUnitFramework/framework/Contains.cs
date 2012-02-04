// ***********************************************************************
// Copyright (c) 2009 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
    /// <summary>
    /// Static helper class used in the constraint-based syntax
    /// </summary>
    public class Contains
    {
        /// <summary>
        /// Creates a new SubstringConstraint
        /// </summary>
        /// <param name="substring">The value of the substring</param>
        /// <returns>A SubstringConstraint</returns>
        public static SubstringConstraint Substring(string substring)
        {
            return new SubstringConstraint(substring);
        }

        /// <summary>
        /// Creates a new CollectionContainsConstraint.
        /// </summary>
        /// <param name="item">The item that should be found.</param>
        /// <returns>A new CollectionContainsConstraint</returns>
        public static CollectionContainsConstraint Item(object item)
        {
            return new CollectionContainsConstraint(item);
        }
    }
}
