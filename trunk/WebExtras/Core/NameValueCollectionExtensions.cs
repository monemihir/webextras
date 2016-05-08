// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace WebExtras.Core
{
  /// <summary>
  ///   Name value collection extensions
  /// </summary>
  public static class NameValueCollectionExtensions
  {
    /// <summary>
    ///   Converts the current name-value collection a dictionary
    /// </summary>
    /// <param name="collection">Current name-value collection</param>
    /// <returns>A dictionary of the current name-value collection</returns>
    public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
    {
      if (collection == null)
        throw new ArgumentException("Collection cannot be null");

      return collection.Cast<string>().ToDictionary(k => k, v => collection[v]);
    }

    /// <summary>
    ///   Check whether the current name-value collection contains given key
    /// </summary>
    /// <param name="collection">Current name-value collection</param>
    /// <param name="key">Key to be checked</param>
    /// <param name="ignoreCase">[Optional] When checking for existence whether to ignore case of keys. Defaults to false</param>
    /// <returns>True if key found, else False</returns>
    public static bool ContainsKey(this NameValueCollection collection, string key, bool ignoreCase = false)
    {
      return collection.Get(key) != null ||
             collection.Keys.Cast<string>()
               .Contains(key, ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
    }
  }
}