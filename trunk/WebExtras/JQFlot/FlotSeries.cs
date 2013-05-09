/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
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
using Newtonsoft.Json;
using WebExtras.JQFlot.Graphs;

namespace WebExtras.JQFlot
{
  /// <summary>
  /// A class representing the jquery properties of a flot series for any flot charts (http://code.google.com/p/flot/)
  /// property names must match the flot property names to allow correct .net to json conversion.
  /// see API docs: http://people.iola.dk/olau/flot/API.txt
  /// </summary>
  [Serializable]
  public class FlotSeries
  {
    /// <summary>
    /// Color to be used for the series. This can be either a CSS color specification
    /// or a number that specifies which auto-generated color to select or a 
    /// <see cref="WebExtras.JQFlot.SubOptions.ColorGradientOptions"/> object
    /// </summary>
    public object color;

    /// <summary>
    /// Series data as x,y or x,y,z values depending on whether the series is
    /// going to be filled
    /// </summary>
    public double[][] data;

    /// <summary>
    /// The label to be used for the legend
    /// </summary>
    public string label;

    /// <summary>
    /// line options
    /// </summary>
    public LineGraph lines;

    /// <summary>
    /// dash options
    /// </summary>
    public DashedLineGraph dashes;

    /// <summary>
    /// curved line options
    /// </summary>
    public CurvedLineGraph curvedLines;

    /// <summary>
    /// point options
    /// </summary>
    public PointGraph points;

    /// <summary>
    /// bar options
    /// </summary>
    public BarGraph bars;

    /// <summary>
    /// which x axis to plot this series against
    /// </summary>
    public int? xaxis;

    /// <summary>
    /// which y axis to plot this series against
    /// </summary>
    public int? yaxis;

    /// <summary>
    /// whether the series responds to a mouse click
    /// </summary>
    public bool? clickable;
    
    /// <summary>
    /// whether the series responds to a mouse hover
    /// </summary>
    public bool? hoverable;

    /// <summary>
    /// shadow size in pixels of the line or points
    /// </summary>
    public int? shadowSize;
        
    /// <summary>
    /// ctor to set defaults
    /// </summary>
    public FlotSeries()
    {
      data = new double[][] { };
      shadowSize = 0;
    }
    
    /// <summary>
    /// Returns the current Flot series object as a JSON
    /// serialized string
    /// </summary>
    /// <returns>FlotSeries as a JSON serialized string</returns>
    public override string ToString()
    {
      return JsonConvert.SerializeObject(
        this,
        new JsonSerializerSettings
        {
          Formatting = Formatting.Indented,
          NullValueHandling = NullValueHandling.Ignore
        });
    }
  }
}