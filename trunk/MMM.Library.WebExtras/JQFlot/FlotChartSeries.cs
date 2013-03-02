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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace MMM.Library.WebExtras.JQFlot
{
  /// <summary>
  /// A class representing the jquery properties of a flot series for any flot charts (http://code.google.com/p/flot/)
  /// property names must match the flot property names to allow correct .net to json conversion.
  /// see API docs: http://people.iola.dk/olau/flot/API.txt
  /// </summary>
  public class FlotChartSeries
  {
    #region Class LineOptions

    /// <summary>
    /// line options
    /// </summary>
    public class LineOptions
    {
      /// <summary>
      /// ctor to set defaults. show=false, lineWidth=1, fill=false
      /// </summary>
      public LineOptions()
      {
        show = false;
        lineWidth = 1;
        fill = false;
      }

      /// <summary>
      /// whether lines are shown
      /// </summary>
      public bool show { get; set; }

      /// <summary>
      /// the width in pixels of the line
      /// </summary>
      public int lineWidth { get; set; }

      /// <summary>
      /// whether the area under the lines should be filled.
      /// </summary>
      public bool fill { get; set; }
    }

    #endregion Class LineOptions

    #region Class PointOptions

    /// <summary>
    /// point options
    /// </summary>
    public class PointOptions
    {
      /// <summary>
      /// ctor to set defaults. show=false, fillColor='0xFF8800', radius=3
      /// </summary>
      /// <param name="initFillColor">[Optional] Fill color for the points. Defaults to '0xFF8800'</param>
      public PointOptions(string initFillColor = "#FF8800")
      {
        show = false;
        fillColor = initFillColor;
        radius = 3;
      }

      /// <summary>
      /// whether points are shown
      /// </summary>
      public bool show { get; set; }

      /// <summary>
      /// the fill colour of the point
      /// </summary>
      public string fillColor { get; set; }

      /// <summary>
      /// the radius in pixels of the points
      /// </summary>
      public int radius { get; set; }
    }

    #endregion Class PointOptions

    #region Class DashOptions

    /// <summary>
    /// dash options
    /// </summary>
    public class DashOptions
    {
      /// <summary>
      /// ctor to set defaults. show=false, lineWidth=1, dashLength=5
      /// </summary>
      public DashOptions()
      {
        show = false;
        lineWidth = 1;
        dashLength = 5;
      }

      /// <summary>
      /// whether dashes are shown
      /// </summary>
      public bool show { get; set; }

      /// <summary>
      /// line width
      /// </summary>
      public int lineWidth { get; set; }

      /// <summary>
      /// length of a dash in pts notation
      /// </summary>
      public int dashLength { get; set; }
    }

    #endregion Class DashOptions

    #region class CurvedLineOptions

    /// <summary>
    /// curved line options
    /// </summary>
    public class CurvedLineOptions
    {
      /// <summary>
      /// ctor to initialize defaults. show=false, lineWidth=1, fill=false,
      /// fit=true, fitPointDist=0, fillColor=''
      /// </summary>
      public CurvedLineOptions()
      {
        show = false;
        lineWidth = 1;
        fill = false;
        fit = true;
        fitPointDist = 0;
        fillColor = string.Empty;
      }

      /// <summary>
      /// whether to show curved lines.
      /// </summary>
      public bool show { get; set; }

      /// <summary>
      /// line width
      /// </summary>
      public int lineWidth { get; set; }

      /// <summary>
      /// whether the area under the curved line should be filled
      /// </summary>
      public bool fill { get; set; }

      /// <summary>
      /// whether to fit the series to the available canvas area
      /// </summary>
      public bool fit { get; set; }

      /// <summary>
      /// defines the x axis distance of the additional two points
      /// that are used to enforce the min max condition
      /// </summary>
      public double fitPointDist { get; set; }

      /// <summary>
      /// color to fill the series with if other than the default series color.
      /// If left blank, the default series color will be used.
      /// </summary>
      public string fillColor { get; set; }
    }

    #endregion class CurvedLineOptions

    /// <summary>
    /// ctor to set defaults
    /// </summary>
    public FlotChartSeries()
    {
      label = "";
      yaxis = 1;
      color = "#FFAA00";
      lines = new LineOptions();
      points = new PointOptions(color);
      dashes = new DashOptions();
      curvedLines = new CurvedLineOptions();
      clickable = false;
      shadowSize = 0;
      hoverable = true;
    }

    /// <summary>
    /// label of the series
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string label { get; set; }

    /// <summary>
    /// colour of the series
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string color { get; set; }

    /// <summary>
    /// shadow size in pixels of the line or points
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int shadowSize { get; set; }

    /// <summary>
    /// series data as a collection of x,y doubles
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<double[]> data { get; set; }

    /// <summary>
    /// line options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public LineOptions lines { get; set; }

    /// <summary>
    /// dash options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DashOptions dashes { get; set; }

    /// <summary>
    /// curved line options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public CurvedLineOptions curvedLines { get; set; }

    /// <summary>
    /// point options
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public PointOptions points { get; set; }

    /// <summary>
    /// whether the series responds to a mouse hover
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool hoverable { get; set; }

    /// <summary>
    /// whether the series responds to a mouse click
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool clickable { get; set; }

    /// <summary>
    /// a tooltip to display when the series is hovered or clicked
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string tooltip { get; set; }

    /// <summary>
    /// which y axis to plot this series against. Defaults to 1
    /// </summary>
    public int yaxis { get; set; }

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