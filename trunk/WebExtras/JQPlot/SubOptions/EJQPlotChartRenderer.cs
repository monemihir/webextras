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
    /// The default line renderer for jqPlot, this class has no options beyond the Series class.  
    /// Draws series as a line.
    /// </summary>
    [StringValue("$.jqplot.LineRenderer")]
    LineRenderer,

    /// <summary>
    /// A plugin renderer for jqPlot to draw a bar plot.  Draws series as a line.
    /// 
    /// Requires: jqplot.barRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.BarRenderer")]
    BarRenderer,

    /// <summary>
    /// Requires: jqplot.ohlcRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.OHLCRenderer")]
    OHLCRenderer,

    /// <summary>
    /// Renderer which draws lines as stacked bezier curves.  Data for the line will not be 
    /// specified as an array of [x, y] data point values, but as a an array of [start point, 
    /// bezier curve] So, the line is specified as: [[xstart, ystart], [cp1x, cp1y, cp2x, 
    /// cp2y, xend, yend]]. 
    /// 
    /// Requires: $.jqplot.BezierCurveRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.BezierCurveRenderer")]
    BezierCurveRenderer,

    /// <summary>
    /// Plugin renderer to draw a x-y block chart.  A Block chart has data points displayed 
    /// as colored squares with a text label inside.  Data must be supplied in the form:
    /// 
    /// [[x1, y1, "label 1", {css}], [x2, y2, "label 2", {css}], ...]
    /// 
    /// The label and css object are optional.  If the label is ommitted, the box will collapse 
    /// unless a css height and/or width is specified.
    /// 
    /// The css object is an object specifying css properties such as:
    /// 
    /// {background:'#4f98a5', border:'3px solid gray', padding:'1px'}
    /// 
    /// Note that css properties specified with the data point override defaults specified with 
    /// the series.
    /// 
    /// Requires: $.jqplot.BlockRenderer.min.js
    /// </summary>
    [StringValue("$.jqlot.BlockRenderer")]
    BlockRenderer,

    /// <summary>
    /// Plugin renderer to draw a bubble chart.  A Bubble chart has data points displayed as 
    /// colored circles with an optional text label inside.
    /// 
    /// Data must be supplied in the form:
    /// 
    /// [[x1, y1, r1, <label /> or {label:'text', color:color}], ...]
    /// 
    /// where the label or options object is optional.
    /// 
    /// Note that all bubble colors will be the same unless the “varyBubbleColors” option is 
    /// set to true.  Colors can be specified in the data array or in the seriesColors array 
    /// option on the series.  If no colors are defined, the default jqPlot series of 16 
    /// colors are used.  Colors are automatically cycled around again if there are more 
    /// bubbles than colors.
    /// 
    /// Bubbles are autoscaled by default to fit within the chart area while maintaining 
    /// relative sizes.  If the “autoscaleBubbles” option is set to false, the r(adius) values 
    /// in the data array a treated as literal pixel values for the radii of the bubbles.
    /// 
    /// Requires: $.jqplot.BubbleRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.BubbleRenderer")]
    BubbleRenderer,

    /// <summary>
    /// Plugin renderer to draw a donut chart. x values, if present, will be used as slice 
    /// labels. y values give slice size.
    /// 
    /// Requires: $.jqplot.DonutRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.DonutRenderer")]
    DonutRenderer
  }
}
