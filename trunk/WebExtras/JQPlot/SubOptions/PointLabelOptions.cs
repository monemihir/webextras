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

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Point labels plugin options
  /// </summary>
  public class PointLabelOptions
  {
    /// <summary>
    /// Show the labels or not.
    /// </summary>
    public bool? show { get; set; }

    /// <summary>
    /// Compass location where to position the label around the point.  
    /// ‘n’, ‘ne’, ‘e’, ‘se’, ‘s’, ‘sw’, ‘w’, ‘nw’
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public ELocation? location { get; set; }

    /// <summary>
    /// Whether to use labels within data point arrays.
    /// </summary>
    public bool? labelsFromSeries { get; set; }

    /// <summary>
    /// Array index for location of labels within data point arrays. 
    /// if null, will use the last element of the data point array.
    /// </summary>
    public int? seriesLabelIndex { get; set; }

    /// <summary>
    /// Array of arrays of labels, one array for each series.
    /// </summary>
    public string[][] labels { get; set; }

    /// <summary>
    /// Whether to display value as stacked in a stacked plot. 
    /// No effect if labels is specified.
    /// </summary>
    public bool? stackedValue { get; set; }

    /// <summary>
    /// Vertical padding in pixels between point and label
    /// </summary>
    public int? ypadding { get; set; }

    /// <summary>
    /// Horizontal padding in pixels between point and label
    /// </summary>
    public int? xpadding { get; set; }

    /// <summary>
    /// Whether to escape html entities in the labels.  
    /// If you want to include markup in the labels, set to false.
    /// </summary>
    public bool? escapeHTML { get; set; }

    /// <summary>
    /// Number of pixels that the label must be away from an axis 
    /// boundary in order to be drawn. Negative values will allow 
    /// overlap with the grid boundaries.
    /// </summary>
    public int? edgeTolerance { get; set; }

    /// <summary>
    /// A class of a formatter for the tick text.  sprintf by default.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public ETickFormatter? formatter { get; set; }

    /// <summary>
    /// String passed to the formatter.
    /// </summary>
    public string formatString { get; set; }

    /// <summary>
    /// Whether to not show a label for a value which is 0.
    /// </summary>
    public bool? hideZeroes { get; set; }
  }
}
