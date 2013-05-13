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
using System.Reflection;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Server postback item to be posted for server side processing
  /// </summary>
  [Serializable]
  public class PostbackItem
  {
    /// <summary>
    /// Name of the postback object
    /// </summary>
    public string name { get; private set; }

    /// <summary>
    /// Value for the postback object
    /// </summary>
    public object value { get; private set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public PostbackItem() { }

    /// <summary>
    /// Constructor to initialize values
    /// </summary>
    /// <param name="objName">Name of the postback object</param>
    /// <param name="objValue">Value for the postback object</param>
    public PostbackItem(string objName, object objValue)
    {
      name = objName;
      value = objValue;
    }

    /// <summary>
    /// Generate Datatables Postback items from the attributes/value
    /// pairs of the given object
    /// </summary>
    /// <param name="o">Object to generate Postback items from</param>
    /// <returns>Generated Postback items</returns>
    public static List<PostbackItem> FromObject(object o)
    {
      List<PostbackItem> postbacks = new List<PostbackItem>();
      PropertyInfo[] props = o
        .GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance);

      foreach(PropertyInfo p in props)
      {
        object val = p.GetValue(o, null);

        if (val != null)
          postbacks.Add(new PostbackItem(p.Name, val));
      }

      return postbacks;
    }
  }
}