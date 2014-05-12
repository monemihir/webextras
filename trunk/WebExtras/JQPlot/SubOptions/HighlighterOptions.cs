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

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Highlighter plugin options
  /// </summary>
  [Serializable]
  public class HighlighterOptions
  {
    /// <summary>
    /// True to show the highlight
    /// </summary>
    public bool? show { get; set; }

    /// <summary>
    /// Renderer used to draw the marker of the highlighted point.  
    /// Renderer will assimilate attributes from the data point being 
    /// highlighted, so no attributes need set on the renderer directly.  
    /// Default is to turn off shadow drawing on the highlighted point.
    /// </summary>
    [JsonConverter(typeof(EJQPlotRendererJsonConverter))]
    public EJQPlotRenderer? markerRenderer { get; set; }

    /// <summary>
    /// True to show the marker
    /// </summary>
    public bool? showMarker { get; set; }

    /// <summary>
    /// Pixels to add to the lineWidth of the highlight.
    /// </summary>
    public double? lineWidthAdjust { get; set; }

    /// <summary>
    /// Pixels to add to the overall size of the highlight.
    /// </summary>
    public double? sizeAdjust { get; set; }

    /// <summary>
    /// Show a tooltip with data point values.
    /// </summary>
    public bool? showTooltip { get; set; }

    /// <summary>
    /// Where to position tooltip, ‘n’, ‘ne’, ‘e’, ‘se’, ‘s’, ‘sw’, ‘w’, ‘nw’
    /// </summary>
    public string tooltipLocation { get; set; }

    /// <summary>
    /// true = fade in/out tooltip, false = show/hide tooltip
    /// </summary>
    public bool? fadeTooltip { get; set; }

    /// <summary>
    /// ’slow’, ‘def’, ‘fast’, or number of milliseconds.
    /// </summary>
    public object tooltipFadeSpeed { get; set; }

    /// <summary>
    /// Pixel offset of tooltip from the highlight.
    /// </summary>
    public double? tooltipOffset { get; set; }

    /// <summary>
    /// Which axes to display in tooltip, ‘x’, ‘y’ or ‘both’, ‘xy’ 
    /// or ‘yx’ ‘both’ and ‘xy’ are equivalent, ‘yx’ reverses order of labels.
    /// </summary>
    public string tooltipAxes { get; set; }

    /// <summary>
    /// Use the x and y axes formatters to format the text in the tooltip.
    /// </summary>
    public bool? useAxesFormatters { get; set; }

    /// <summary>
    /// sprintf format string for the tooltip.  Uses Ash Searle’s javascript 
    /// sprintf implementation found here: http://hexmen.com/blog/2007/03/printf-sprintf/ 
    /// See http://perldoc.perl.org/functions/sprintf.html for reference.  
    /// Additional “p” and “P” format specifiers added by Chris Leonello.
    /// </summary>
    public string tooltipFormatString { get; set; }

    /// <summary>
    /// alternative to tooltipFormatString will format the whole tooltip text, 
    /// populating with x, y values as indicated by tooltipAxes option.  So, you 
    /// could have a tooltip like: ‘Date: %s, number of cats: %d’ to format the 
    /// whole tooltip at one go.  If useAxesFormatters is true, values will be 
    /// formatted according to Axes formatters and you can populate your tooltip 
    /// string with %s placeholders.
    /// </summary>
    public string formatString { get; set; }

    /// <summary>
    /// Number of y values to expect in the data point array. Typically this is 1.  
    /// Certain plots, like OHLC, will have more y values in each data point array.
    /// </summary>
    public int? yvalues { get; set; }

    /// <summary>
    /// This option requires jQuery 1.4+ True to bring the series of the highlighted 
    /// point to the front of other series.
    /// </summary>
    public bool? bringSeriesToFront { get; set; }
  }
}
