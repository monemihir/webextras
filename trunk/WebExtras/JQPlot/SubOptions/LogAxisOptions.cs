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
using System.Text;
using Newtonsoft.Json;

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Log axis options
  /// </summary>
  [Serializable]
  public class LogAxisOptions : AxisOptions
  {
    /// <summary>
    /// Associated axis type
    /// </summary>
    [JsonIgnore]
    public new string AxisType
    {
      get { return "LogAxis"; }
    }

    /// <summary>
    /// A class of a rendering engine that handles tick generation, scaling input 
    /// data to pixel grid units and drawing the axis element.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public new EJQPlotRenderer? renderer { get { return EJQPlotRenderer.LogAxisRenderer; } }

    /// <summary>
    /// The logarithmic base, commonly 2, 10 or Math.E
    /// </summary>
    [JsonProperty(PropertyName = "base")]
    public object logBase { get; set; }

    /// <summary>
    /// ’even’ or ‘power’.  ‘even’ gives equal pixel spacing of the ticks on the plot.
    /// ‘power’ gives ticks in powers of 10.
    /// </summary>
    public string tickDistribution { get; set; }
  }
}
