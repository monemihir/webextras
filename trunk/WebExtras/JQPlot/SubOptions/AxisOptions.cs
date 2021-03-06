﻿/*
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
using WebExtras.JQPlot.RendererOptions;

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// jqPlot axis options
  /// </summary>
  [Serializable]
  public class AxisOptions : IAxisOptions
  {
    /// <summary>
    /// Associated axis type
    /// </summary>
    [JsonIgnore]
    public virtual string AxisType
    {
      get { return "DefaultAxis"; }
    }

    /// <summary>
    /// Whether to display the axis on the graph
    /// </summary>
    public bool? show { get; set; }

    /// <summary>
    /// A class of a rendering engine for creating the ticks labels displayed on the plot, See $.jqplot.AxisTickRenderer.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public EJQPlotRenderer? tickRenderer { get; set; }

    /// <summary>
    /// Options that will be passed to the tickRenderer, see $.jqplot.AxisTickRenderer options.
    /// </summary>
    public IRendererOptions tickOptions { get; set; }

    /// <summary>
    /// A class of a rendering engine for creating an axis label.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public EJQPlotRenderer? labelRenderer { get; set; }

    /// <summary>
    /// Options passed to the label renderer.
    /// </summary>
    public IRendererOptions labelOptions { get; set; }

    /// <summary>
    /// Label for the axis
    /// </summary>
    public string label { get; set; }

    /// <summary>
    /// Whether to show the axis label.
    /// </summary>
    public bool? showLabel { get; set; }

    /// <summary>
    /// minimum value of the axis (in data units, not pixels). For date axes
    /// can be a string i.e 01-01-2014
    /// </summary>
    public object min { get; set; }

    /// <summary>
    /// maximum value of the axis (in data units, not pixels). For date axes
    /// can be a string i.e 01-01-2014
    /// </summary>
    public object max { get; set; }

    /// <summary>
    /// Autoscale the axis min and max values to provide sensible tick spacing.  
    /// If axis min or max are set, autoscale will be turned off.  The numberTicks, 
    /// tickInterval and pad options do work with autoscale, although tickInterval 
    /// has not been tested yet. padMin and padMax do nothing when autoscale is on.
    /// </summary>
    public bool? autoscale { get; set; }

    /// <summary>
    /// Padding to extend the range above and below the data bounds.  The data range 
    /// is multiplied by this factor to determine minimum and maximum axis bounds.  
    /// A value of 0 will be interpreted to mean no padding, and pad will be set to 1.0.
    /// </summary>
    public double? pad { get; set; }

    /// <summary>
    /// Padding to extend the range above data bounds.  The top of the data range 
    /// is multiplied by this factor to determine maximum axis bounds.  A value of 0 
    /// will be interpreted to mean no padding, and padMax will be set to 1.0.
    /// </summary>
    public double? padMax { get; set; }

    /// <summary>
    /// Padding to extend the range below data bounds.  The bottom of the data range 
    /// is multiplied by this factor to determine minimum axis bounds.  A value of 0 
    /// will be interpreted to mean no padding, and padMin will be set to 1.0.
    /// </summary>
    public double? padMin { get; set; }

    /// <summary>
    /// 1D [val, val, ...] or 2D [[val, label], [val, label], ...] array of ticks 
    /// for the axis.  If no label is specified, the value is formatted into an 
    /// appropriate label.
    /// </summary>
    public object ticks { get; set; }

    /// <summary>
    /// Desired number of ticks.  Default is to compute automatically.
    /// </summary>
    public int? numberTicks { get; set; }

    /// <summary>
    /// Number of units between ticks.  Mutually exclusive with numberTicks.
    /// A number by default, can be string when rendering as date axis
    /// </summary>
    public object tickInterval { get; set; }

    /// <summary>
    /// A class of a rendering engine that handles tick generation, scaling input 
    /// data to pixel grid units and drawing the axis element.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public virtual EJQPlotRenderer? renderer { get; set; }

    /// <summary>
    /// Renderer specific options.  See $.jqplot.LinearAxisRenderer for options.
    /// </summary>
    public IRendererOptions rendererOptions { get; set; }

    /// <summary>
    /// Whether to show the ticks (both marks and labels) or not.  Will not 
    /// override showMark and showLabel options if specified on the ticks 
    /// themselves.
    /// </summary>
    public bool? showTicks { get; set; }

    /// <summary>
    /// Whether to show the tick marks (line crossing grid) or not.  
    /// Overridden by showTicks and showMark option of tick itself.
    /// </summary>
    public bool? showTickMarks { get; set; }

    /// <summary>
    /// Wether or not to show minor ticks.  This is renderer dependent.  
    /// The default $.jqplot.LinearAxisRenderer does not have minor ticks.
    /// </summary>
    public bool? showMinorTicks { get; set; }

    /// <summary>
    /// Use the color of the first series associated with this axis 
    /// for the tick marks and line bordering this axis.
    /// </summary>
    public bool? useSeriesColor { get; set; }

    /// <summary>
    /// Width of line stroked at the border of the axis.  
    /// Defaults to the width of the grid border.
    /// </summary>
    public int? borderWidth { get; set; }

    /// <summary>
    /// Color of the border adjacent to the axis.  
    /// Defaults to grid border color.
    /// </summary>
    public string borderColor { get; set; }

    /// <summary>
    /// Whether to try and synchronize tick spacing across multiple axes so 
    /// that ticks and grid lines line up.  This has an impact on autoscaling 
    /// algorithm, however.  In general, autoscaling an individual axis will 
    /// work better if it does not have to sync ticks.
    /// </summary>
    public bool? syncTicks { get; set; }

    /// <summary>
    /// Approximate pixel spacing between ticks on graph. Used during autoscaling.  
    /// This number will be an upper bound, actual spacing will be less.
    /// </summary>
    public int? tickSpacing { get; set; }
  }
}
