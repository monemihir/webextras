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
using Newtonsoft.Json;
using WebExtras.JQFlot.SubOptions;

namespace WebExtras.JQFlot
{
  /// <summary>
  /// flot chart options
  /// </summary>
  [Serializable]
  public class FlotOptions
  {
    /// <summary>
    /// ctor to initialize defaults
    /// </summary>
    public FlotOptions()
    {
      xaxis = new AxisOptions();
      yaxis = new AxisOptions();
      grid = new GridOptions();
    }

    /// <summary>
    /// x axis 1
    /// </summary>
    public AxisOptions xaxis { get; set; }

    /// <summary>
    /// y axis 1
    /// </summary>
    public AxisOptions yaxis { get; set; }

    /// <summary>
    /// y axis 2
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public AxisOptions y2axis { get; set; }

    /// <summary>
    /// chart grid options
    /// </summary>
    public GridOptions grid { get; set; }

    /// <summary>
    /// chart series options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public SeriesOptions series { get; set; }

    /// <summary>
    /// JSON serializes the current Flot options
    /// </summary>
    /// <returns>JSON serialized object</returns>
    public override string ToString()
    {
      return JsonConvert.SerializeObject(
        this,
        new JsonSerializerSettings
        {
          Formatting = Formatting.Indented,
          NullValueHandling = NullValueHandling.Ignore
        });
    }
  }
}