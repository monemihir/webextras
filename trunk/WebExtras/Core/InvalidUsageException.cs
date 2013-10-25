/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
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

namespace WebExtras.Core
{
  /// <summary>
  /// Invalid usage exception
  /// </summary>
  public class InvalidUsageException : Exception
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public InvalidUsageException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">Inner exception</param>
    public InvalidUsageException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
