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

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Server postback item to be posted for server side processing
  /// </summary>
  [Serializable]
  [JsonConverter(typeof(PostbackItemConverter))]
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
      PropertyInfo[] props = o
        .GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance);

      return (from p in props 
              let val = p.GetValue(o, null) 
              where val != null 
              select new PostbackItem(p.Name, JsonConvert.SerializeObject(val))).ToList();
    }
  }

  /// <summary>
  /// PostbackItem JSON converter
  /// </summary>
  [Serializable]
  public class PostbackItemConverter : JsonConverter
  {
    /// <summary>
    /// Determines whether this instance can convert the specified object type
    /// </summary>
    /// <param name="objectType">Type of the object</param>
    /// <returns>true if this instance can convert the specified object type; otherwise, false</returns>
    public override bool CanConvert(Type objectType)
    {
      return objectType.IsAssignableFrom(typeof(PostbackItem));
    }

    /// <summary>
    /// Reads the JSON representation of the object
    /// </summary>
    /// <param name="reader">The Newtonsoft.Json.JsonReader to read from</param>
    /// <param name="objectType">Type of the object</param>
    /// <param name="existingValue">The existing value of object being read</param>
    /// <param name="serializer">The calling serializer</param>
    /// <returns>The object value</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Writes the JSON representation of the object
    /// </summary>
    /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to</param>
    /// <param name="value">The Newtonsoft.Json.JsonWriter to write to</param>
    /// <param name="serializer">The Newtonsoft.Json.JsonWriter to write to</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      PostbackItem p = (PostbackItem)value;

      writer.WriteStartObject();
      writer.WritePropertyName("name");
      writer.WriteValue(p.name);
      writer.WritePropertyName("value");
      writer.WriteRawValue((string)p.value);
      writer.WriteEndObject();
    }
  }
}