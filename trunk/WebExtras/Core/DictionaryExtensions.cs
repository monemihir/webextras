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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WebExtras.Core
{
  /// <summary>
  /// IDictionary extensions
  /// </summary>
  public static class DictionaryExtensions
  {
    /// <summary>
    /// Merge two dictionaries
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    /// <param name="current">Current dictionary</param>
    /// <param name="dictionary">Dictionary to be merged in</param>
    /// <param name="overwrite">[Optional] Whether to overwrite existing values. Defaults to false</param>
    /// <param name="mergeNullValues">[Optional] Whether to merge NULL values from new dictionary. Defaults to false</param>
    /// <returns>Merged dictionary</returns>
    public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> current,
      IDictionary<TKey, TValue> dictionary,
      bool overwrite = false,
      bool mergeNullValues = false)
    {
      IDictionary<TKey, TValue> merged = new Dictionary<TKey, TValue>(current);

      if (dictionary != null && dictionary.Count > 0)
        foreach (TKey key in dictionary.Keys)
          if ((!current.ContainsKey(key)) || (current.ContainsKey(key) && overwrite))
            if ((dictionary[key] != null && !mergeNullValues) || (dictionary[key] == null && mergeNullValues))
              merged[key] = dictionary[key];

      return merged;
    }
  }
}
