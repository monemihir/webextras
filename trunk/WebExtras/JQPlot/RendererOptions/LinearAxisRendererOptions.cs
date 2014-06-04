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
using Newtonsoft.Json;

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Linear axis renderer options
  /// </summary>
  [Serializable]
  public class LinearAxisRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName { get { return "LinearAxisRenderer"; } }

    /// <summary>
    /// EXPERIMENTAL!!  Use at your own risk!  Works only with linear axes and the default tick renderer.  
    /// Array of [start, stop] points to create a broken axis.  Broken axes have a “jump” in them, which 
    /// is an immediate transition from a smaller value to a larger value.  Currently, axis ticks MUST be 
    /// manually assigned if using breakPoints by using the axis ticks array option.
    /// </summary>
    public object breakPoints { get; set; }

    /// <summary>
    /// Label to use at the axis break if breakPoints are specified.
    /// </summary>
    public string breakTickLabel { get; set; }

    /// <summary>
    /// This will ensure that there is always a tick mark at 0.  If data range is strictly positive or 
    /// negative, this will force 0 to be inside the axis bounds unless the appropriate axis pad (pad, 
    /// padMin or padMax) is set to 0, then this will force an axis min or max value at 0.  This has know 
    /// effect when any of the following options are set: autoscale, min, max, numberTicks or tickInterval.
    /// </summary>
    public bool? forceTickAt0 { get; set; }

    /// <summary>
    /// This will ensure that there is always a tick mark at 100.  If data range is strictly above or 
    /// below 100, this will force 100 to be inside the axis bounds unless the appropriate axis pad (pad, 
    /// padMin or padMax) is set to 0, then this will force an axis min or max value at 100.  This has 
    /// know effect when any of the following options are set: autoscale, min, max, numberTicks or tickInterval.
    /// </summary>
    public bool? forceTickAt100 { get; set; }
  }
}
