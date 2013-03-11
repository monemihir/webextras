/*
* This file is part of - Code Library
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
    /// ctor to set defaults
    /// </summary>
    public FlotSeries()
    {
      label = "";
      color = "#FFAA00";
      yaxis = 1;      
      clickable = false;
      shadowSize = 0;
      hoverable = true;
      data = new List<List<double>>();
      dashes = new DashedLineGraph();
      lines = new LineGraph();
      curvedLines = new CurvedLineGraph();
      points = new PointGraph();
    }

    /// <summary>
    /// label of the series
    /// </summary>
    public string label { get; set; }

    /// <summary>
    /// colour of the series
    /// </summary>
    public string color { get; set; }

    /// <summary>
    /// shadow size in pixels of the line or points
    /// </summary>
    public int shadowSize { get; set; }

    /// <summary>
    /// series data as a collection of x,y doubles
    /// </summary>
    public IEnumerable<IEnumerable<double>> data { get; set; }

    /// <summary>
    /// whether the series responds to a mouse hover
    /// </summary>
    public bool hoverable { get; set; }

    /// <summary>
    /// whether the series responds to a mouse click
    /// </summary>
    public bool clickable { get; set; }

    /// <summary>
    /// which y axis to plot this series against. Defaults to 1
    /// </summary>
    public int yaxis { get; set; }

    /// <summary>
    /// a tooltip to display when the series is hovered or clicked
    /// </summary>
    public string tooltip { get; set; }

    /// <summary>
    /// line options
    /// </summary>
    public LineGraph lines { get; set; }

    /// <summary>
    /// dash options
    /// </summary>
    public DashedLineGraph dashes { get; set; }

    /// <summary>
    /// curved line options
    /// </summary>
    public CurvedLineGraph curvedLines { get; set; }

    /// <summary>
    /// point options
    /// </summary>
    public PointGraph points { get; set; }

    /// <summary>
    /// Returns the current Flot series object as a JSON
    /// serialized string
    /// </summary>
    /// <returns>FlotSeries as a JSON serialized string</returns>
    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}