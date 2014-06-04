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
  /// All renderers available in jqPlot
  /// </summary>
  [Serializable]
  public enum EJQPlotRenderer
  {
    /// <summary>
    /// A "tick" object showing the value of a tick/gridline on the plot.
    /// </summary>
    [StringValue("$.jqplot.AxisTickRenderer")]
    AxisTickRenderer,

    /// <summary>
    /// The default jqPlot grid renderer, creating a grid on a canvas 
    /// element.  The renderer has no additional options beyond the Grid class.
    /// </summary>
    [StringValue("$.jqplot.CanvasGridRenderer")]
    CanvasGridRenderer,

    /// <summary>
    /// The default title renderer for jqPlot.  This class has no options 
    /// beyond the Title class.
    /// </summary>
    [StringValue("$.jqplot.DivTitleRenderer")]
    DivTitleRenderer,

    /// <summary>
    /// The default jqPlot axis renderer, creating a numeric axis.  
    /// The renderer has no additional options beyond the Axis object.
    /// </summary>
    [StringValue("$.jqplot.LinearAxisRenderer")]
    LinearAxisRenderer,

    /// <summary>
    /// Default marker renderer, rendering the points on the line
    /// </summary>
    [StringValue("$.jqplot.MarkerRenderer")]
    MarkerRenderer,

    /// <summary>
    /// The default jqPlot shape renderer.  Given a set of points will plot 
    /// them and either stroke a line (fill = false) or fill them (fill = true).  
    /// If a filled shape is desired, closePath = true must also be set to close the shape.
    /// </summary>
    [StringValue("$.jqplot.shapeRenderer")]
    ShapeRenderer,

    /// <summary>
    /// The default jqPlot shadow renderer, rendering shadows behind shapes.
    /// </summary>
    [StringValue("$.jqplot.shadowRenderer")]
    ShadowRenderer,

    /// <summary>
    /// Renderer to place labels on the axes.
    /// </summary>
    [StringValue("$.jqplot.AxisLabelRenderer")]
    AxisLabelRenderer,

    /// <summary>
    /// Requires: jqplot.canvasTextRenderer.min.js, jqplot.canvasAxisLabelRenderer.min.js plugins
    /// </summary>
    [StringValue("$.jqplot.CanvasAxisLabelRenderer")]
    CanvasAxisLabelRenderer,

    /// <summary>
    /// Requires: jqplot.canvasTextRenderer.min.js, jqplot.canvasAxisTickRenderer.min.js plugins
    /// </summary>
    [StringValue("$.jqplot.CanvasAxisTickRenderer")]
    CanvasAxisTickRenderer,

    /// <summary>
    /// Requires: jqplot.categoryAxisRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.CategoryAxisRenderer")]
    CategoryAxisRenderer,

    /// <summary>
    /// Requires: jqplot.DateAxisRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.DateAxisRenderer")]
    DateAxisRenderer,

    /// <summary>
    /// Legend Renderer specific to donut plots.  Set by default when user creates a donut plot.
    /// 
    /// Requires: jqplot.DonutRenderer.min.js
    /// </summary>
    [StringValue("$.jqplot.DonutLegendRenderer")]
    DonutLegendRenderer
  }
}
