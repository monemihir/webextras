/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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

using Newtonsoft.Json;
using System;
using WebExtras.Core;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// HTTP method for Ajax call backs
  /// </summary>
  [Serializable]
  public enum EServerMethod
  {
    /// <summary>
    /// HTTP GET method
    /// </summary>
    [StringValue("GET")]
    Get,

    /// <summary>
    /// HTTP POST method
    /// </summary>
    [StringValue("POST")]
    Post
  }

  /// <summary>
  /// EServerMethod enum's custom Json Converter
  /// </summary>
  [Serializable]
  public class EServerMethodJsonConverter : JsonConverter
  {
    /// <summary>
    /// Determines whether this instance can convert the specified object type
    /// </summary>
    /// <param name="objectType">Type of the object</param>
    /// <returns>true if this instance can convert the specified object type; otherwise, false</returns>
    public override bool CanConvert(Type objectType)
    {
      return typeof(EServerMethod).IsAssignableFrom(objectType);
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
      if (existingValue == null)
        return null;

      return Enum.Parse(typeof(EServerMethod), existingValue.ToString().ToTitleCase());
    }

    /// <summary>
    /// Writes the JSON representation of the object
    /// </summary>
    /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to</param>
    /// <param name="value">The Newtonsoft.Json.JsonWriter to write to</param>
    /// <param name="serializer">The Newtonsoft.Json.JsonWriter to write to</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (value == null) { writer.WriteNull(); }
      else { EServerMethod val = (EServerMethod)value; writer.WriteValue(val.GetStringValue()); }
    }
  }
}
