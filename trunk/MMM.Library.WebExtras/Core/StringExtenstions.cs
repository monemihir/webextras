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

using System.Globalization;

namespace MMM.Library.WebExtras.Core
{
  /// <summary>
  /// String extension functions
  /// </summary>
  public static class StringExtenstions
  {
    /// <summary>
    /// Converts a given string to title case
    /// </summary>
    /// <param name="str">String to be converted to titlecase</param>
    /// <returns>Titlecase converted string</returns>
    public static string ToTitleCase(this string str)
    {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
    }

    /// <summary>
    /// Returns a value indicating whether the specified System.String object occurs
    /// within this string ignoring case.
    /// </summary>
    /// <param name="str">String to be checked</param>
    /// <param name="value">The string to seek</param>
    /// <returns>True if string to be seeked is found in this string, else False</returns>
    public static bool ContainsIgnoreCase(this string str, string value)
    {
      return str.ToLowerInvariant().Contains(value.ToLowerInvariant());
    }
  }
}