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
  /// Double extensions
  /// </summary>
  public static class DoubleExtensions
  {
    /// <summary>
    /// static date of 1970-01-01 to use when converting DateTimes into javascript date objects (total ms since 1970-01-01 00:00:00 UTC)
    /// </summary>
    private static readonly DateTime DateTime1970Utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970-01-01 00:00:00 UTC

    /// <summary>
    /// Converts given JavaScript ticks to a .NET date
    /// </summary>
    /// <param name="jsDate">A javascript date number (total ms since 1970-1-1 UTC) to covert</param>
    /// <returns>DateTime object</returns>
    public static DateTime ToDateTime(this double jsDate)
    {
      return (DateTime1970Utc + TimeSpan.FromMilliseconds(jsDate));
    }
  }
}
