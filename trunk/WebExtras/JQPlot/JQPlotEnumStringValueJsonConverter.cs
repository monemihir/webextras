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
using System.Reflection;
using Newtonsoft.Json;
using WebExtras.Core;

namespace WebExtras.JQPlot
{
  /// <summary>
  /// A generic enum to string value JSON.Net converter for all
  /// enums defined for JQPlot
  /// </summary>
  [Serializable]
  public class JQPlotEnumStringValueJsonConverter : JsonConverter
  {
    /// <summary>
    /// The namespace that contains all JQPlot specific enums
    /// </summary>
    private const string JQPlotNamespace = "WebExtras.JQPlot";

    /// <summary>
    /// A list of all known enum types
    /// </summary>
    private static List<Type> m_knownEnumTypes;

    /// <summary>
    /// Constructor
    /// </summary>
    public JQPlotEnumStringValueJsonConverter()
    {
      if (m_knownEnumTypes == null)
        m_knownEnumTypes = Assembly.GetExecutingAssembly().GetTypes()
         .Where(t => t.IsEnum && !string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(JQPlotNamespace))
         .ToList();
    }

    /// <summary>
    /// Determines whether this instance can convert the specified object type
    /// </summary>
    /// <param name="objectType">Type of the object</param>
    /// <returns>true if this instance can convert the specified object type; otherwise, false</returns>
    public override bool CanConvert(Type objectType)
    {
      return m_knownEnumTypes.Contains(objectType);
    }

    /// <summary>
    /// Reads the JSON representation of the object
    /// </summary>
    /// <param name="reader">The Newtonsoft.Json.JsonReader to read from</param>
    /// <param name="objectType">Type of the object</param>
    /// <param name="existingValue">The existing value of object being read</param>
    /// <param name="serializer">The calling serializer</param>
    /// <returns>The object value</returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (m_knownEnumTypes.Contains(objectType))
      {
        object parsed = Enum.Parse(objectType, existingValue.ToString().Split('.').Last());

        Enum val = (Enum)parsed;

        return val;
      }

      throw new NotSupportedException("Enum type: " + objectType.FullName + " is not supported");
    }

    /// <summary>
    /// Writes the JSON representation of the object
    /// </summary>
    /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to</param>
    /// <param name="value">The Newtonsoft.Json.JsonWriter to write to</param>
    /// <param name="serializer">The Newtonsoft.Json.JsonWriter to write to</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Enum val = (Enum)value;

      string result = string.IsNullOrWhiteSpace(val.GetStringValue()) ?
        val.ToString().ToCamelCase() :
        val.GetStringValue();

      writer.WriteRawValue(result);
    }
  }
}
