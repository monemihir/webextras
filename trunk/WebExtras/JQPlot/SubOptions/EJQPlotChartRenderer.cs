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

using Newtonsoft.Json;
using System;
using System.Linq;
using WebExtras.Core;

#pragma warning disable 1591

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Chart renderer type
  /// </summary>
  [Serializable]
  public enum EJQPlotChartRenderer
  {
    /// <summary>
    /// Requires: jqplot.barRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.BarRenderer")]
    BarRenderer,

    /// <summary>
    /// Requires: jqplot.ohlcRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.OHLCRenderer")]
    OHLCRenderer
  }

  ///// <summary>
  ///// EJQPlotChartRenderer enum's custom Json Converter
  ///// </summary>
  //[Serializable]
  //public class EJQPlotChartRendererJsonConverter : JsonConverter
  //{
  //  /// <summary>
  //  /// Determines whether this instance can convert the specified object type
  //  /// </summary>
  //  /// <param name="objectType">Type of the object</param>
  //  /// <returns>true if this instance can convert the specified object type; otherwise, false</returns>
  //  public override bool CanConvert(Type objectType)
  //  {
  //    return typeof(EJQPlotChartRenderer).IsAssignableFrom(objectType);
  //  }

  //  /// <summary>
  //  /// Reads the JSON representation of the object
  //  /// </summary>
  //  /// <param name="reader">The Newtonsoft.Json.JsonReader to read from</param>
  //  /// <param name="objectType">Type of the object</param>
  //  /// <param name="existingValue">The existing value of object being read</param>
  //  /// <param name="serializer">The calling serializer</param>
  //  /// <returns>The object value</returns>
  //  public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
  //  {
  //    return existingValue == null ? null : Enum.Parse(typeof(EJQPlotChartRenderer), existingValue.ToString().Split('.').Last());
  //  }

  //  /// <summary>
  //  /// Writes the JSON representation of the object
  //  /// </summary>
  //  /// <param name="writer">The Newtonsoft.Json.JsonWriter to write to</param>
  //  /// <param name="value">The Newtonsoft.Json.JsonWriter to write to</param>
  //  /// <param name="serializer">The Newtonsoft.Json.JsonWriter to write to</param>
  //  public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
  //  {
  //    EJQPlotChartRenderer val = (EJQPlotChartRenderer)value;

  //    writer.WriteRawValue(val.GetStringValue());
  //  }
  //}
}
