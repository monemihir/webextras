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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebExtras.Core
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
    /// <param name="allWords">[Optional] Flag indicating whether to title case each 
    /// individual word. Defaults to false</param>
    /// <returns>Titlecase converted string</returns>
    public static string ToTitleCase(this string str, bool allWords = false)
    {
      if (allWords)
      {
        IEnumerable<string> parsed = str.Split(' ').Select(f => ToTitleCase(f));

        return string.Join(" ", parsed);
      }

      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLowerInvariant());
    }

    /// <summary> 
    /// Converts a given string to camel case
    /// </summary>
    /// <param name="str">String to be converted to camel case</param>
    /// <param name="allWords">[Optional] Flag indicating whether to camel case each 
    /// individual word. Defaults to false</param>
    /// <returns>Camelcase converted string</returns>
    public static string ToCamelCase(this string str, bool allWords = false)
    {
      string[] buff = str.Split(' ');
      List<string> converted = new List<string>();

      foreach (char[] sBuff in buff.Select(s => s.ToCharArray()))
      {
        char[] newBuff = new char[sBuff.Length];
        Array.Copy(sBuff, newBuff, sBuff.Length);

        newBuff[0] = sBuff[0].ToString(CultureInfo.InvariantCulture).ToLowerInvariant()[0];

        string camelCased = new string(newBuff);

        converted.Add(camelCased);

        if (allWords)
          continue;

        converted.AddRange(buff.Skip(1));
        break;
      }

      return string.Join(" ", converted);
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

    /// <summary>
    /// Removes all occurences of the given string from parent
    /// </summary>
    /// <param name="str">String parent</param>
    /// <param name="removeStr">String to be removed from parent</param>
    /// <returns>Sanitised string with given string patterns removed from parent string</returns>
    public static string Remove(this string str, string removeStr)
    {
      return str.Replace(removeStr, "").Trim();
    }
  }
}