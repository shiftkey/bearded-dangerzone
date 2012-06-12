﻿// This software is part of the Autofac IoC container
// Copyright © 2011 Autofac Contributors
// http://autofac.org
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autofac.Core.Activators.Reflection
{
    /// <summary>
    /// Finds constructors based on their binding flags.
    /// </summary>
    public class BindingFlagsConstructorFinder : IConstructorFinder
    {
        readonly BindingFlags _bindingFlags;

        /// <summary>
        /// Create an instance matching constructors with the supplied binding flags.
        /// </summary>
        /// <param name="bindingFlags">Binding flags to match.</param>
        public BindingFlagsConstructorFinder(BindingFlags bindingFlags)
        {
            _bindingFlags = bindingFlags;
        }

        /// <summary>
        /// Finds suitable constructors on the target type.
        /// </summary>
        /// <param name="targetType">Type to search for constructors.</param>
        /// <returns>Suitable constructors.</returns>
        public ConstructorInfo[] FindConstructors(Type targetType)
        {
            return targetType.GetConstructors(BindingFlags.Instance | _bindingFlags);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format(BindingFlagsConstructorFinderResources.HasBindingFlags, _bindingFlags);
        }
    }
}
