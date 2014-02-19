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

namespace WebExtras.Core
{
  /// <summary>
  /// Date time extensions
  /// </summary>
  public static class DateTimeExtensions
  {
    /// <summary>
    /// static date of 1970-01-01 to use when converting DateTimes into javascript date objects (total ms since 1970-01-01 00:00:00 UTC)
    /// </summary>
    private static readonly DateTime DateTime1970Utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970-01-01 00:00:00 UTC

    /// <summary>    
    /// Converts a .NET date to JavaScript ticks
    /// </summary>
    /// <param name="dt">The DateTime (used as local time) to convert</param>
    /// <returns>A javascript date number (total ms since 1970-1-1 UTC)</returns>
    public static double ToJavaScriptDate(this DateTime dt)
    {
      TimeSpan ts = dt - DateTime1970Utc; // difference between localtime and 1970utc gives us the date in local time
      return ts.TotalMilliseconds;
    }

    /// <summary>
    /// Returns current date time as a local date time
    /// </summary>
    /// <param name="dt">DateTime to be updated</param>
    /// <returns>Updated date time</returns>
    public static DateTime AsLocal(this DateTime dt)
    {
      return new DateTime(dt.Ticks, DateTimeKind.Local);
    }

    /// <summary>
    /// Returns current date time as a UTC date time
    /// </summary>
    /// <param name="dt">DateTime to be updated</param>
    /// <returns>Updated date time</returns>
    public static DateTime AsUtc(this DateTime dt)
    {
      return new DateTime(dt.Ticks, DateTimeKind.Utc);
    }
  }
}
