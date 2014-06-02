/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Runtime.Serialization;
using System.Web;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// Thrown when cookies are not supported or not enabled.
  /// </summary>
  [Serializable]
  public class CookiesNotEnabledException : HttpException
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public CookiesNotEnabledException() { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that holds the contextual information about the source or destination.</param>
    protected CookiesNotEnabledException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">The error message displayed to the client when the exception is thrown. </param>
    public CookiesNotEnabledException(string message) : base(message) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">The error message displayed to the client when the exception is thrown. </param>
    /// <param name="innerException">The <see cref="P:System.Exception.InnerException"/>, if any, that threw the current exception. </param>
    public CookiesNotEnabledException(string message, Exception innerException) : base(message, innerException) { }
  }
}
