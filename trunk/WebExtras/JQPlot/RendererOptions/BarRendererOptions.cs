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
  /// BarRenderer options
  /// </summary>
  [Serializable]
  public class BarRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName { get { return "BarRenderer"; } }

    /// <summary>
    /// Number of pixels between adjacent bars at the same axis value.
    /// </summary>
    public int? barPadding { get; set; }

    /// <summary>
    /// Number of pixels between groups of bars at adjacent axis values.
    /// </summary>
    public int? barMargin { get; set; }

    /// <summary>
    /// ‘vertical’ = up and down bars, ‘horizontal’ = side to side bars
    /// </summary>
    public string barDirection { get; set; }

    /// <summary>
    /// Width of the bar in pixels (auto by default). 
    /// </summary>
    public int? barWidth { get; set; }

    /// <summary>
    /// offset of the shadow from the slice and offset of each succesive stroke of the shadow from the last.
    /// </summary>
    public int? shadowOffset { get; set; }

    /// <summary>
    /// number of strokes to apply to the shadow, each stroke offset shadowOffset from the last.
    /// </summary>
    public int? shadowDepth { get; set; }

    /// <summary>
    /// transparency of the shadow (0 = transparent, 1 = opaque)
    /// </summary>
    public double? shadowAlpha { get; set; }

    /// <summary>
    /// Whether to plot as a waterfall chart
    /// </summary>
    public bool? waterfall { get; set; }

    /// <summary>
    /// group bars into these many groups
    /// </summary>
    public int? groups { get; set; }

    /// <summary>
    /// true to color each bar of a series separately rather than have every 
    /// bar of a given series the same color. If used for non-stacked multiple 
    /// series bar plots, user should specify a separate ‘seriesColors’ array 
    /// for each series.  Otherwise, each series will set their bars to the same 
    /// color array. This option has no Effect for stacked bar charts and is disabled.
    /// </summary>
    public bool? varyBarColor { get; set; }

    /// <summary>
    /// True to highlight slice when moused over. This must be false to enable 
    /// highlightMouseDown to highlight when clicking on a slice.
    /// </summary>
    public bool? highlightMouseOver { get; set; }

    /// <summary>
    /// True to highlight when a mouse button is pressed over a slice.  
    /// This will be disabled if highlightMouseOver is true.
    /// </summary>
    public bool? highlightMouseDown { get; set; }

    /// <summary>
    /// an array of colors to use when highlighting a bar.
    /// </summary>
    public string[] highlightColors { get; set; }
  }
}
