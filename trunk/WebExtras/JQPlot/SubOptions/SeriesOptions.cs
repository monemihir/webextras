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

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Series options
  /// </summary>
  [Serializable]
  public class SeriesOptions
  {
    /// <summary>
    /// Whether to draw series
    /// </summary>
    public bool? show;

    /// <summary>
    /// which x axis to use with this series, either ‘xaxis’ or ‘x2axis’.
    /// </summary>
    public string xaxis;

    /// <summary>
    /// which y axis to use with this series, either ‘yaxis’ or ‘y2axis’.
    /// </summary>
    public string yaxis;

    /// <summary>
    /// A class of a renderer which will draw the series, see $.jqplot.LineRenderer.
    /// </summary>
    public EChartRenderer? renderer;

    /// <summary>
    /// Options to pass on to the renderer.
    /// </summary>
    public object rendererOptions;

    /// <summary>
    /// Line label to use in the legend.
    /// </summary>
    public string lineLabel;

    /// <summary>
    /// css color spec for the series
    /// </summary>
    public string color;

    /// <summary>
    /// width of the line in pixels.  May have different meanings depending on renderer.
    /// </summary>
    public double? lineWidth;

    /// <summary>
    /// Canvas lineJoin style between segments of series.
    /// </summary>
    public string lineJoin;

    /// <summary>
    /// Canvas lineCap style at ends of line.
    /// </summary>
    public string lineCap;

    /// <summary>
    /// whether or not to draw a shadow on the line
    /// </summary>
    public bool? shadow;

    /// <summary>
    /// Shadow angle in degrees
    /// </summary>
    public int? shadowAngle;

    /// <summary>
    /// Shadow offset from line in pixels
    /// </summary>
    public double? shadowOffset;

    /// <summary>
    /// Number of times shadow is stroked, each stroke offset shadowOffset from the last.
    /// </summary>
    public int? shadowDepth;

    /// <summary>
    /// Alpha channel transparency of shadow.  0 = transparent.
    /// </summary>
    public string shadowAlpha;

    /// <summary>
    /// Whether line segments should be be broken at null value.  False will join point on either side of line.
    /// </summary>
    public bool? breakOnNull;

    /// <summary>
    /// A class of a renderer which will draw marker (e.g. circle, square, ...) at the data points, see $.jqplot.MarkerRenderer.
    /// </summary>
    public EJQPlotRenderer? markerRenderer;

    /// <summary>
    /// renderer specific options to pass to the markerRenderer, see $.jqplot.MarkerRenderer.
    /// </summary>
    public MarkerRendererOptions markerOptions;

    /// <summary>
    /// whether to actually draw the line or not.  Series will still be renderered, even if no line is drawn.
    /// </summary>
    public bool? showLine;

    /// <summary>
    /// whether or not to show the markers at the data points.
    /// </summary>
    public bool? showMarker;

    /// <summary>
    /// 0 based index of this series in the plot series array.
    /// </summary>
    public int? index;

    /// <summary>
    /// whether to fill under lines or in bars.  May not be implemented in all renderers.
    /// </summary>
    public bool? fill;

    /// <summary>
    /// CSS color spec to use for fill under line.  Defaults to line color.
    /// </summary>
    public string fillColor;

    /// <summary>
    /// Alpha transparency to apply to the fill under the line.  Use this to adjust alpha separate from fill color.
    /// </summary>
    public string fillAlpha;

    /// <summary>
    /// If true will stroke the line (with color this.color) as well as fill under it.  Applies only when fill is true.
    /// </summary>
    public bool? fillAndStroke;

    /// <summary>
    /// true to not stack this series with other series in the plot.  To render properly, non-stacked series must 
    /// come after any stacked series in the plot’s data series array.  So, the plot’s data series array would look like:
    ///
    /// [stackedSeries1, stackedSeries2, ..., nonStackedSeries1, nonStackedSeries2, ...]
    /// disableStack will put a gap in the stacking order of series, and subsequent stacked series will not fill down 
    /// through the non-stacked series and will most likely not stack properly on top of the non-stacked series.
    /// </summary>
    public bool? disableStack;

    /// <summary>
    /// how close or far (in pixels) the cursor must be from a point marker to detect the point.
    /// </summary>
    public int? neighborThreshold;

    /// <summary>
    /// true will force bar and filled series to fill toward zero on the fill Axis.
    /// </summary>
    public bool? fillToZero;

    /// <summary>
    /// fill a filled series to this value on the fill axis.  Works in conjunction with fillToZero, so that must be true.
    /// </summary>
    public int? fillToValue;

    /// <summary>
    /// Either ‘x’ or ‘y’.  Which axis to fill the line toward if fillToZero is true.  ‘y’ means fill up/down to 0 on the y axis for this series.
    /// </summary>
    public char? fillAxis;

    /// <summary>
    /// true to color negative values differently in filled and bar charts.
    /// </summary>
    public bool? useNegativeColors;
  }
}
