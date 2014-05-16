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
* but WITHOUT ANY WARRANTY{get; set;} without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using Newtonsoft.Json;
using WebExtras.JQPlot.SubOptions;

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Axis tick renderer options base class
  /// </summary>
  [Serializable]
  public abstract class AxisTickRendererOptionsBase
  {
    /// <summary>
    /// Tick mark on the axis
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public ETickMarkLocation? mark { get; set; }

    /// <summary>
    /// Whether or not to show the mark on the axis.
    /// </summary>
    public bool? showMark { get; set; }

    /// <summary>
    /// Whether or not to draw the gridline on the grid at this tick.
    /// </summary>
    public bool? showGridline { get; set; }

    /// <summary>
    /// Whether this is a minor tick
    /// </summary>
    public bool? isMinorTick { get; set; }

    /// <summary>
    /// Length of the tick marks in pixels.  For ‘cross’ style, length 
    /// will be stoked above and below axis, so total length will be twice this.
    /// </summary>
    public int? markSize { get; set; }

    /// <summary>
    /// Whether or not to show the tick (mark and label).  Setting this 
    /// to false requires more testing.  It is recommended to set showLabel 
    /// and showMark to false instead.
    /// </summary>
    public bool? show { get; set; }

    /// <summary>
    /// Whether or not to show the label.
    /// </summary>
    public bool? showLabel { get; set; }

    /// <summary>
    /// A class of a formatter for the tick text. sprintf by default.
    /// </summary>
    public object formatter { get; set; }

    /// <summary>
    /// String to prepend to the tick label.  Prefix is prepended to the 
    /// formatted tick label.
    /// </summary>
    public string prefix { get; set; }

    /// <summary>
    /// String passed to the formatter.
    /// </summary>
    public string formatString { get; set; }

    /// <summary>
    /// css spec for the font-family css attribute.
    /// </summary>
    public string fontFamily { get; set; }

    /// <summary>
    /// css spec for the font-size css attribute.
    /// </summary>
    public string fontSize { get; set; }

    /// <summary>
    /// css spec for the color attribute.
    /// </summary>
    public string textColor { get; set; }
  }
}
