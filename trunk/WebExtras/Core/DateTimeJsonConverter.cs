// 
// This file is part of - WebExtras
// Copyright (C) 2015 Mihir Mone
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
using Newtonsoft.Json;

namespace WebExtras.Core
{
  /// <summary>
  ///   Date time json converter
  /// </summary>
  public class DateTimeJsonConverter : JsonConverter
  {
    /// <summary>
    ///   Flag indicating whether the type we are dealing with is nullable
    /// </summary>
    private bool m_isNullable;

    /// <summary>
    ///   Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var parsed = m_isNullable ? (DateTime?) value : (DateTime) value;

      DateTime val = parsed.GetValueOrDefault(DateTime.MinValue);

      if (val == DateTime.MinValue)
        return;

      string writeValue = string.Format("{0}",
        val.Kind == DateTimeKind.Utc ? val.ToString("yyyy-MM-ddTHH:mm:ss") : val.ToString("yyyy-MM-dd HH:mm:ss"));

      writer.WriteValue(writeValue);
    }

    /// <summary>
    ///   Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>
    ///   The object value.
    /// </returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>
    ///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvert(Type objectType)
    {
      m_isNullable = typeof (DateTime?) == objectType;
      return typeof (DateTime) == objectType || m_isNullable;
    }
  }
}