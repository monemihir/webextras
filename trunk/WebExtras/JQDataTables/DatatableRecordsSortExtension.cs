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
using System.Text.RegularExpressions;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Extension for sorting the DatatableRecords.aaData collection
  /// </summary>
  public static class DatatableRecordsSortExtension
  {
    /// <summary>
    /// A list of predefined HTML currency syntax
    /// </summary>
    private static readonly IEnumerable<string> m_currencies = new string[] { "&euro;", "&yen;", "$", "&pound;", "rs." };

    /// <summary>
    /// Sort DatatableRecords.aaData based on the given column number and sort direction
    /// </summary>
    /// <param name="aaData">DatatableRecords table data to be sorted</param>
    /// <param name="columnNumber">Column to sort on</param>
    /// <param name="type">Sort direction</param>
    public static IEnumerable<IEnumerable<string>> Sort(this IEnumerable<IEnumerable<string>> aaData, int columnNumber, SortType type)
    {
      if (aaData != null && aaData.Count() > 1)
      {
        if (type == SortType.Ascending)
          aaData = SortAscending(aaData, columnNumber);
        else
          aaData = SortDescending(aaData, columnNumber);
      }

      return aaData;
    }

    /// <summary>
    /// Sort DatatableRecords.aaData ascending by given column number
    /// </summary>
    /// <param name="aaData">DatatableRecords table data to be sorted</param>
    /// <param name="columnNumber">Column to sort on</param>
    private static IEnumerable<IEnumerable<string>> SortAscending(IEnumerable<IEnumerable<string>> aaData, int columnNumber)
    {
      string[][] data = aaData.Select(f => f.ToArray()).ToArray();
      string parseStr = SanitiseString(data[0][columnNumber]);

      DateTime dt = DateTime.MinValue;
      bool success = DateTime.TryParse(parseStr, out dt);
      if (success)
        aaData = data.OrderBy(f => DateTime.Parse(SanitiseString(f[columnNumber])));
      else
      {
        double dbl = double.NaN;
        success = double.TryParse(parseStr, out dbl);
        if (success)
          aaData = data.OrderBy(f => double.Parse(SanitiseString(f[columnNumber])));
        else
          aaData = data.OrderBy(f => SanitiseString(f[columnNumber]));
      }

      return aaData;
    }

    /// <summary>
    /// Sort DatatableRecords.aaData descending based on given column number
    /// </summary>
    /// <param name="aaData">DatatableRecords table data to be sorted</param>
    /// <param name="columnNumber">Column number to sort on</param>
    private static IEnumerable<IEnumerable<string>> SortDescending(IEnumerable<IEnumerable<string>> aaData, int columnNumber)
    {
      string[][] data = aaData.Select(f => f.ToArray()).ToArray();
      string parseStr = SanitiseString(data[0][columnNumber]);
      DateTime dt = DateTime.MinValue;

      bool success = DateTime.TryParse(parseStr, out dt);

      if (success)
        aaData = data.OrderByDescending(f => DateTime.Parse(SanitiseString(f[columnNumber])));
      else
      {
        double dbl = double.NaN;

        success = double.TryParse(parseStr, out dbl);

        if (success)
          aaData = data.OrderByDescending(f => double.Parse(SanitiseString(f[columnNumber])));
        else
          aaData = data.OrderByDescending(f => SanitiseString(f[columnNumber]));
      }

      return aaData;
    }

    /// <summary>
    /// Sanitises given string by stripping any HTML tags and HTML currency tags
    /// from the given string
    /// </summary>
    /// <param name="str">String to be sanitized</param>
    /// <returns>Sanitised string</returns>
    private static string SanitiseString(string str)
    {
      Regex.Replace(str, "<.*?>", string.Empty);

      foreach (string currency in m_currencies)
        str = str.ToLowerInvariant().Replace(currency.ToLowerInvariant(), "").Trim();

      return str;
    }
  }
}
