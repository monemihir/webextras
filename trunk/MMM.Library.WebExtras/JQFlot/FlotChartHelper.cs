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
using System.Collections.Generic;
using System.Linq;

namespace MMM.Library.WebExtras.JQFlot
{
  /// <summary>
  /// A helper used to supply data to flot charts.
  /// Chart data is specifically formatted as json point arrays [[x,y],...] providing the
  /// series data for the flot charts (http://code.google.com/p/flot/)
  /// x values are represented as javascript date numbers (total ms since 1970)
  /// http://people.iola.dk/olau/flot/API.txt
  /// </summary>
  public static class FlotChartHelper
  {
    /// <summary>
    /// converts a flotDateTime object into a flot javascript date number (total ms since 1970-1-1 UTC)
    /// The date is converted to local time for this operation.
    /// NOTE: This method is specific to FLOT due to the way it expects dates, for general javascript dates use the JavascriptHelper.ToJSDate() method.
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
    public static double ToLocalJSDate(DateTime dt)
    {
      TimeSpan ts = dt.ToLocalTime() - JavascriptHelper.DateTime1970Utc; // difference between localtime and 1970utc gives us the date in local time
      return ts.TotalMilliseconds;
    }

    /// <summary>
    /// converts a flot javascript date number (total ms since 1970-1-1 UTC) into a DateTime object in UTC
    /// NOTE: This method is specific to FLOT due to the way it expects dates, for general javascript dates use the JavascriptHelper.ToUtcDate() method.
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
    public static DateTime ToUtcDate(double jsDate)
    {
      return (JavascriptHelper.DateTime1970Utc + TimeSpan.FromMilliseconds(jsDate)).ToUniversalTime();
    }

    /// <summary>
    /// Converts an array of doubles into a javascript array string in format: [x,y,..]
    /// </summary>
    /// <param name="dataSet">Array of values to convert</param>
    /// <returns>A Javascript array string of values in format: [x,y..]</returns>
    public static string ToJSArray(IEnumerable<double> dataSet)
    {
      string jsarray = string.Join(",", dataSet.Select(f => string.Format("[{0:0.00}]", f)).ToArray());
      return "[" + jsarray + "]";
    }

    /// <summary>
    /// converts an array of double[2] x,y values into a javascript dictionary string in format: {x:y,..}
    /// </summary>
    /// <param name="dataSet">the array of double[2] x,y values to convert</param>
    /// <returns>a javascript dictionary string of points in format: {x:y,..}</returns>
    public static string ToJSArray(IEnumerable<double[]> dataSet)
    {
      IEnumerable<string> items = dataSet
        .Where(f => f == null || !double.IsNaN(f[1]))
        .Select(f => f != null ? string.Format("[{0:0.##},{1:0.##}]", f[0], f[1]) : "null");
      string jsarray = string.Join(",", items.ToArray());
      return "[" + jsarray + "]";
    }

    /// <summary>
    /// converts an array of double/string pairs into a javascript dictionary string in format: {d:'s',..}
    /// </summary>
    /// <param name="dataSet">the array of KeyValuePair pairs to convert</param>
    /// <returns>a javascript dictionary string of pairs in format: {d:'s',..}</returns>
    public static string ToJSDict(IEnumerable<KeyValuePair<double, string>> dataSet)
    {
      return "{" + string.Join(",", dataSet.Select(f => string.Format("{0:0.##}:'{1}'", f.Key, f.Value)).ToArray()) + "}";
    }

    /// <summary>
    /// returns a string of markings between two dates in the flot format: {xaxis: { from: x1, to: x2, color: "rgba(128,128,128,0.5)", ...}
    /// http://people.iola.dk/olau/flot/API.txt
    /// </summary>
    /// <param name="x1">left point of the marking</param>
    /// <param name="x2">right point of the marking</param>
    /// <param name="color">color of the marking area</param>
    /// <returns>flot markings string</returns>
    public static string ToMarkings(DateTime x1, DateTime x2, string color)
    {
      return string.Format(
        "{{xaxis: {{ from: {0:0.##}, to: {1:0.##} }}, color: \"{2}\" }}",
        ToLocalJSDate(x1),
        ToLocalJSDate(x2),
        color);
    }

    /// <summary>
    /// returns a string of markings between two dates in the flot format: {xaxis: { from: x1, to: x2, color: "rgba(128,128,128,0.5)", ...}
    /// http://people.iola.dk/olau/flot/API.txt
    /// </summary>
    /// <param name="x1">left point of the marking</param>
    /// <param name="x2">right point of the marking</param>
    /// <param name="color">color of the marking area</param>
    /// <returns>flot markings string</returns>
    public static string ToMarkings(double x1, double x2, string color)
    {
      return string.Format(
        "{{xaxis: {{ from: {0:0.##}, to: {1:0.##} }}, color: \"{2}\" }}",
        x1,
        x2,
        color);
    }
  }
}