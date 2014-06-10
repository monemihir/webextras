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

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Funnel renderer options
  /// </summary>
  [Serializable]
  public class FunnelRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName
    {
      get { return "FunnelRenderer"; }
    }

    /// <summary>
    /// padding between the funnel and plot edges, legend, etc.
    /// </summary>
    public PaddingOptions padding { get; set; }

    /// <summary>
    /// spacing between funnel sections in pixels.
    /// </summary>
    public int? sectionMargin { get; set; }

    /// <summary>
    /// true or false, wether to fill the areas.
    /// </summary>
    public bool? fill { get; set; }

    /// <summary>
    /// offset of the shadow from the area and offset of each succesive
    /// stroke of the shadow from the last.
    /// </summary>
    public int? shadowOffset { get; set; }

    /// <summary>
    /// transparency of the shadow (0 = transparent, 1 = opaque)
    /// </summary>
    public double? shadowAlpha { get; set; }

    /// <summary>
    /// number of strokes to apply to the shadow, each stroke offset shadowOffset from the last.
    /// </summary>
    public int? shadowDepth { get; set; }

    /// <summary>
    /// True to highlight bubbles when moused over.  This must be false to 
    /// enable highlightMouseDown to highlight when clicking on a slice.
    /// </summary>
    public bool? highlightMouseOver { get; set; }

    /// <summary>
    /// True to highlight when a mouse button is pressed over a bubble.  
    /// This will be disabled if highlightMouseOver is true.
    /// </summary>
    public bool? highlightMouseDown { get; set; }

    /// <summary>
    /// An array of colors to use when highlighting a slice.  Calculated 
    /// automatically if not supplied.
    /// </summary>
    public string[] highlightColors { get; set; }

    /// <summary>
    /// width of line if areas are stroked and not filled.
    /// </summary>
    public int? lineWidth { get; set; }

    /// <summary>
    /// The ratio of the width of the top of the funnel to the bottom. a ratio of 0 will
    /// make an upside down pyramid.
    /// </summary>
    public double? widthRatio { get; set; }

    /// <summary>
    /// Either ‘label’, ‘value’, ‘percent’ or an array of labels to place on the pie slices.  
    /// Defaults to percentage of each pie slice.
    /// </summary>
    public object dataLabels { get; set; }

    /// <summary>
    /// true to show data labels on slices.
    /// </summary>
    public bool? showDataLabels { get; set; }

    /// <summary>
    /// Format string for data labels.  If none, ‘%s’ is used for “label” and for arrays, ‘%d’ 
    /// for value and ‘%d%%’ for percentage.
    /// </summary>
    public string dataLabelFormatString { get; set; }

    /// <summary>
    /// Threshhold in percentage (0	100) of pie area, below which no label will be displayed.  
    /// This applies to all label types, not just to percentage labels.
    /// </summary>
    public int? dataLabelThreshold { get; set; }
  }
}
