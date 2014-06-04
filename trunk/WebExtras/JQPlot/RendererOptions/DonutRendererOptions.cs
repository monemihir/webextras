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


namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Donut renderer options
  /// </summary>
  public class DonutRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Outer diameter of the donut, auto computed by default
    /// </summary>
    public double? diameter { get; set; }

    /// <summary>
    /// Inner diameter of the donut, auto calculated by default.  If specified 
    /// will override thickness value.
    /// </summary>
    public double? innerDiameter { get; set; }

    /// <summary>
    /// Thickness of the donut, auto computed by default Overridden by if 
    /// innerDiameter is specified.
    /// </summary>
    public double? thickness { get; set; }

    /// <summary>
    /// Padding between the donut and plot edges, legend, etc.
    /// </summary>
    public int? padding { get; set; }

    /// <summary>
    /// Angular spacing between donut slices in degrees.
    /// </summary>
    public int? sliceMargin { get; set; }

    /// <summary>
    /// Pixel distance between rings, or multiple series in a donut plot. null 
    /// will compute ringMargin based on sliceMargin.
    /// </summary>
    public int? ringMargin { get; set; }

    /// <summary>
    /// Whether to fill the slices
    /// </summary>
    public bool? fill { get; set; }

    /// <summary>
    /// Offset of the shadow from the slice and offset of each succesive stroke 
    /// of the shadow from the last.
    /// </summary>
    public int? shadowOffset { get; set; }

    /// <summary>
    /// Transparency of the shadow (0 = transparent, 1 = opaque)
    /// </summary>
    public double? shadowAlpha { get; set; }

    /// <summary>
    /// Number of strokes to apply to the shadow, each stroke offset shadowOffset 
    /// from the last.
    /// </summary>
    public int? shadowDepth { get; set; }

    /// <summary>
    /// True to highlight slice when moused over.  This must be false to 
    /// enable highlightMouseDown to highlight when clicking on a slice.
    /// </summary>
    public bool? highlightMouseOver { get; set; }

    /// <summary>
    /// True to highlight when a mouse button is pressed over a slice.  
    /// This will be disabled if highlightMouseOver is true.
    /// </summary>
    public bool? highlightMouseDown { get; set; }

    /// <summary>
    /// An array of colors to use when highlighting a slice.  Calculated 
    /// automatically if not supplied.
    /// </summary>
    public string[] highlightColors { get; set; }

    /// <summary>
    /// Either 'label', 'value', 'percent' or an array of labels to place 
    /// on the pie slices.  Defaults to percentage of each pie slice.
    /// </summary>
    public object dataLabels { get; set; }

    /// <summary>
    /// True to show data labels on slices.
    /// </summary>
    public bool? showDataLabels { get; set; }

    /// <summary>
    /// Format string for data labels.  If none, '%s' is used for "label" 
    /// and for arrays, '%d' for value and '%d%%' for percentage.
    /// </summary>
    public string dataLabelFormatString { get; set; }

    /// <summary>
    /// Threshhold in percentage (0	100) of pie area, below which no label 
    /// will be displayed.  This applies to all label types, not just to 
    /// percentage labels.
    /// </summary>
    public int? dataLabelThreshold { get; set; }

    /// <summary>
    /// A Multiplier (0-1) of the pie radius which controls position of label 
    /// on slice.  Increasing will slide label toward edge of pie, decreasing 
    /// will slide label toward center of pie.
    /// </summary>
    public double? dataLabelPositionFactor { get; set; }

    /// <summary>
    /// Number of pixels to slide the label away from (+) or toward (-) the 
    /// center of the pie.
    /// </summary>
    public int? dataLabelNudge { get; set; }

    /// <summary>
    /// Angle to start drawing donut in degrees.  According to orientation of 
    /// canvas coordinate system: 0 = on the positive x axis -90 = on the 
    /// positive y axis.  90 = on the negaive y axis.  180 or - 180 = on the 
    /// negative x axis.
    /// </summary>
    public int? startAngle { get; set; }
  }
}
