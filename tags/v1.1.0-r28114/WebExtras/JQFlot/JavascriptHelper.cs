/*
* This file is part of - Code Library
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

namespace WebExtras.JQFlot
{
  /// <summary>
  /// Class to contain Javascript helpers.
  /// </summary>
  public static class JavascriptHelper
  {
    /// <summary>
    /// static date of 1970-01-01 to use when converting DateTimes into javascript date objects (total ms since 1970-01-01 00:00:00 UTC)
    /// </summary>
    public static DateTime DateTime1970Utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970-01-01 00:00:00 UTC

    /// <summary>
    /// converts a DateTime object into a javascript date number (total ms since 1970-1-1 UTC).
    /// The date is converted to Utc for this operation.
    /// Note: this is different to the FlotChartHelper.ToLocalJSDate() method as flot uses local time due to the way flot uses dates
    /// (see comments on this method for more information).
    /// </summary>
    /// <param name="dt">The DateTime to convert</param>
    /// <returns>a javascript date number (total ms since 1970-1-1 UTC)</returns>
    public static double ToUtcJSDate(DateTime dt)
    {
      TimeSpan ts = dt.ToUniversalTime() - DateTime1970Utc;
      return ts.TotalMilliseconds;
    }

    /// <summary>
    /// converts a javascript date number (total ms since 1970-1-1 UTC) into a DateTime object in UTC
    /// Note: this is different to the FlotChartHelper.ToUtcDate() method as flot uses local time due to the way flot uses dates
    /// (see comments on this method for more information).
    /// </summary>
    /// <param name="jsDate">a javascript date number (total ms since 1970-1-1 UTC) to covert</param>
    /// <returns>DateTime object in UTC</returns>
    public static DateTime FromUtcJSDate(double jsDate)
    {
      return (DateTime1970Utc + TimeSpan.FromMilliseconds(jsDate));
    }
  }
}