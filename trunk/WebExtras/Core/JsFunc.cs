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

using Newtonsoft.Json;
using System;
using System.Text;

namespace WebExtras.Core
{
  /// <summary>
  /// Represents a Javascript function
  /// </summary>
  [JsonConverter(typeof(JsFuncConverter))]
  public class JsFunc
  {
    /// <summary>
    /// Function name. Leave empty if you want an anonymous function
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// An array of function parameter names
    /// </summary>
    public string[] ParameterNames { get; set; }

    /// <summary>
    /// Function body
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Flag indicating whether to surround the function with
    /// a document.ready construct
    /// </summary>
    public bool OnDocumentReady { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public JsFunc()
    {
      ParameterNames = new string[0];
    }
  }

  /// <summary>
  /// Custom JSON converter for JsFunc class
  /// </summary>
  public class JsFuncConverter : JsonConverter
  {
    /// <summary>
    /// Determines whether this instance can convert the specified object type
    /// </summary>
    /// <param name="objectType">Type of the object</param>
    /// <returns>true if this instance can convert the specified object type; otherwise, false</returns>
    public override bool CanConvert(Type objectType)
    {
      return typeof(JsFunc).IsAssignableFrom(objectType);
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
      JsFunc f = (JsFunc)value;

      if (!string.IsNullOrEmpty(f.Body))
      {
        StringBuilder fnText = new StringBuilder();

        fnText.Append("function ");

        if (!string.IsNullOrEmpty(f.Name))
          fnText.Append(f.Name);

        if (f.ParameterNames.Length > 0)
          fnText.Append("(" + string.Join(", ", f.ParameterNames) + ") ");
        else
          fnText.Append("() ");

        fnText.Append("{ " + f.Body + " }");

        StringBuilder docReady = new StringBuilder();
        docReady.Append("$(document).ready(function() { ");
        docReady.Append(fnText.ToString());
        docReady.Append(" });");

        if (f.OnDocumentReady)
          writer.WriteRawValue(docReady.ToString());
        else
          writer.WriteRawValue(fnText.ToString());
      }
    }
  }
}
