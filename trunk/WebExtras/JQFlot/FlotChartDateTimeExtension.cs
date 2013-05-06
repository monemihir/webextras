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
using System.Collections.Generic;
using System.Linq;

namespace WebExtras.JQFlot
{
  /// <summary>
  /// An extension helper to handle conversion of C# date times to Flot date times  
  /// </summary>
  public static class FlotChartDateTimeExtension
  {
    /// <summary>
    /// static date of 1970-01-01 to use when converting DateTimes into javascript date objects (total ms since 1970-01-01 00:00:00 UTC)
    /// </summary>
    public static DateTime DateTime1970Utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // 1970-01-01 00:00:00 UTC

    /// <summary>    
    /// Converts a C# date time objects to it's equivalent Flot date time object.
    ///
    /// From the FLOT API:
    /// "Normally you want the timestamps to be displayed according to a
    /// certain time zone, usually the time zone in which the data has been
    /// produced. However, Flot always displays timestamps according to UTC.
    /// It has to as the only alternative with core Javascript is to interpret
    /// the timestamps according to the time zone that the visitor is in,
    /// which means that the ticks will shift unpredictably with the time zone
    /// and daylight savings of each visitor.
    ///
    /// So given that there's no good support for custom time zones in
    /// Javascript, you'll have to take care of this server-side.
    /// The easiest way to think about it is to pretend that the data
    /// production time zone is UTC, even if it isn't. So if you have a
    /// datapoint at 2002-02-20 08:00, you can generate a timestamp for eight
    /// o'clock UTC even if it really happened eight o'clock UTC+0200."
    /// </summary>
    /// <param name="dt">The DateTime (used as local time) to convert</param>
    /// <returns>a javascript date number (total ms since 1970-1-1 UTC)</returns>
    public static double ToJavaScriptDate(this DateTime dt)
    {
      TimeSpan ts = dt - DateTime1970Utc; // difference between localtime and 1970utc gives us the date in local time
      return ts.TotalMilliseconds;
    }

    /// <summary>
    /// Converts a Flot date time object to a C# date time object.
    ///
    /// From the FLOT API:
    /// "Normally you want the timestamps to be displayed according to a
    /// certain time zone, usually the time zone in which the data has been
    /// produced. However, Flot always displays timestamps according to UTC.
    /// It has to as the only alternative with core Javascript is to interpret
    /// the timestamps according to the time zone that the visitor is in,
    /// which means that the ticks will shift unpredictably with the time zone
    /// and daylight savings of each visitor.
    ///
    /// So given that there's no good support for custom time zones in
    /// Javascript, you'll have to take care of this server-side.
    /// The easiest way to think about it is to pretend that the data
    /// production time zone is UTC, even if it isn't. So if you have a
    /// datapoint at 2002-02-20 08:00, you can generate a timestamp for eight
    /// o'clock UTC even if it really happened eight o'clock UTC+0200."    /// </summary>
    /// <param name="jsDate">a javascript date number (total ms since 1970-1-1 UTC) to covert</param>
    /// <returns>DateTime object in UTC</returns>
    public static DateTime ToUtcCSDate(this double jsDate)
    {
      return (DateTime1970Utc + TimeSpan.FromMilliseconds(jsDate)).ToUniversalTime();
    }
  }
}