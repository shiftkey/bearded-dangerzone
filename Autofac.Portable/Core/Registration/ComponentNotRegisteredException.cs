// This software is part of the Autofac IoC container
// Copyright � 2011 Autofac Contributors
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
using System.Globalization;
using System.Runtime.Serialization;
using Autofac.Util;

namespace Autofac.Core.Registration
{
	/// <summary>
	/// A service was requested that cannot be provided by the container. To avoid this exception, either register a component
	/// to provide the required service, check for service registration using IsRegistered(), or use the ResolveOptional()
	/// method to resolve an optional dependency.
	/// </summary>
	/// <remarks>This exception is fatal. See <see cref="DependencyResolutionException"/> for more information.</remarks>
#if !PORTABLE
    [Serializable]
#endif
    public class ComponentNotRegisteredException : DependencyResolutionException
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotRegisteredException"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ComponentNotRegisteredException(Service service)
            : base(string.Format(CultureInfo.CurrentCulture,
            ComponentNotRegisteredExceptionResources.Message, 
            Enforce.ArgumentNotNull(service, "service")))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotRegisteredException"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="innerException">The inner exception.</param>
        public ComponentNotRegisteredException(Service service, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture,
            ComponentNotRegisteredExceptionResources.Message, 
            Enforce.ArgumentNotNull(service, "service")),
            innerException)
        {
        }
#if !(SILVERLIGHT || PORTABLE)
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotRegisteredException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected ComponentNotRegisteredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
