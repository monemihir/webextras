// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Datatables helper methods
  /// </summary>
  public static class DatatablesHelper
  {
    /// <summary>
    ///   Convert a given object to a dictionary using reflection
    /// </summary>
    /// <param name="o">Object to convert</param>
    /// <param name="nullValues">Handling of null fields/properties</param>
    /// <param name="includeProperties">[Optional] Whether to include public properties. Defaults to true</param>
    /// <param name="includeFields">[Optional] Whether to include public fields. Defaults to true</param>
    /// <returns>A dictionary representing the object</returns>
    public static IDictionary<string, object> ToDictionary(object o, NullValueHandling nullValues,
      bool includeProperties = true, bool includeFields = true)
    {
      Type[] converters = null;

      IDictionary<string, object> dict = ToDictionary(o, nullValues, out converters, includeProperties, includeFields);

      return dict;
    }

    /// <summary>
    ///   Convert a given object to a dictionary using reflection
    /// </summary>
    /// <param name="o">Object to convert</param>
    /// <param name="nullValues">Handling of null fields/properties</param>
    /// <param name="jsonConverterTypes">
    ///   Types specified by any custom <see cref="JsonConverterAttribute" /> attached to
    ///   fields/properties
    /// </param>
    /// <param name="includeProperties">[Optional] Whether to include public properties. Defaults to true</param>
    /// <param name="includeFields">[Optional] Whether to include public fields. Defaults to true</param>
    /// <returns>A dictionary representing the object</returns>
    public static IDictionary<string, object> ToDictionary(object o, NullValueHandling nullValues,
      out Type[] jsonConverterTypes, bool includeProperties = true, bool includeFields = true)
    {
      List<Type> converters = new List<Type>();

      IDictionary<string, object> dict = new Dictionary<string, object>();

      Type t = o.GetType();

      FieldInfo[] fields = t.GetFields();

      foreach (FieldInfo f in fields)
      {
        var ignore = f.GetCustomAttribute<JsonIgnoreAttribute>();

        if (ignore != null)
          continue;

        var convert = f.GetCustomAttribute<JsonConverterAttribute>();

        if (convert != null)
          converters.Add(convert.ConverterType);

        object val = f.GetValue(o);

        if (val == null)
        {
          if (nullValues == NullValueHandling.Include)
            dict[f.Name] = null;
        }
        else
          dict[f.Name] = val;
      }

      PropertyInfo[] properties = t.GetProperties();

      foreach (PropertyInfo p in properties)
      {
        var ignore = p.GetCustomAttribute<JsonIgnoreAttribute>();

        if (ignore != null)
          continue;

        var convert = p.GetCustomAttribute<JsonConverterAttribute>();

        if (convert != null)
          converters.Add(convert.ConverterType);

        object val = p.GetValue(o);

        if (val == null)
        {
          if (nullValues == NullValueHandling.Include)
            dict[p.Name] = null;
        }
        else
          dict[p.Name] = val;
      }

      jsonConverterTypes = converters.ToArray();
      return dict;
    }
  }
}