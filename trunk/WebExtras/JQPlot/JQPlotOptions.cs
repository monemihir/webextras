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
using WebExtras.JQPlot.SubOptions;

namespace WebExtras.JQPlot
{
  /// <summary>
  /// jqPlot options
  /// </summary>
  [Serializable]
  public class JQPlotOptions
  {
    /// <summary>
    /// default options that will be applied to all axes.
    /// </summary>
    public AxisOptions axesDefaults;

    /// <summary>
    /// default options that will be applied to all series.
    /// </summary>
    public SeriesOptions seriesDefaults;

    /// <summary>
    /// Array of series object options.
    /// </summary>
    public SeriesOptions[] series;

    /// <summary>
    /// up to 4 axes are supported, each with it’s own options, See Axis for axis specific options.
    /// </summary>
    public IDictionary<string, AxisOptions> axes;

    /// <summary>
    /// See Grid for grid specific options.
    /// </summary>
    public GridOptions grid;

    /// <summary>
    /// Legend options
    /// </summary>
    public LegendOptions legend;

    /// <summary>
    /// An array of CSS color specifications that will be applied, in order, to the series in the plot.  
    /// Colors will wrap around so, if their are more series than colors, colors will be reused 
    /// starting at the beginning.  For pie charts, this specifies the colors of the slices.
    /// </summary>
    public string[] seriesColors;

    /// <summary>
    /// false to not sort the data passed in by the user.  Many bar, stacked and other graphs as well 
    /// as many plugins depend on having sorted data.
    /// </summary>
    public bool? sortData;

    /// <summary>
    /// css spec for the font-size attribute.  Default for the entire plot.
    /// </summary>
    public string fontSize;

    /// <summary>
    /// Chart title
    /// </summary>
    public TitleOptions title;

    /// <summary>
    /// true or false, creates a stack or “mountain” plot.  Not all series renderers may implement this option.
    /// </summary>
    public bool? stackSeries;

    /// <summary>
    /// 1-D data series are internally converted into 2-D [x,y] data point arrays by jqPlot.  
    /// This is the default starting value for the missing x or y value. The added data will be a monotonically 
    /// increasing series (e.g.  [1, 2, 3, ...]) starting at this value.
    /// </summary>
    public int? defaultAxisStart;
  }
}
