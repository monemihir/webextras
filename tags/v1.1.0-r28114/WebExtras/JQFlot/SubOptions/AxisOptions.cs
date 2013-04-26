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
using System.Text;
using Newtonsoft.Json;

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// flot axis options
  /// </summary>
  [Serializable]
  public class AxisOptions
  {
    /// <summary>
    /// ctor to intialize defaults. tickDecimals=0, tickLength=0, axisLabelUseCanvas=true
    /// </summary>
    public AxisOptions()
    {
      tickDecimals = 0;
      mode = null;
      timeformat = null;
      minTickSize = null;
      tickLength = 0;
      axisLabelUseCanvas = true;
      axisLabelFontSizePixels = 12;
      axisLabelFontFamily = "Verdana";
    }

    /// <summary>
    /// axis min
    /// </summary>
    public int? min { get; set; }

    /// <summary>
    /// axis max
    /// </summary>
    public int? max { get; set; }

    /// <summary>
    /// tick decimal places
    /// </summary>
    public int? tickDecimals { get; set; }

    /// <summary>
    /// tick step size. 1 give you 1,2,3... 2 gives you 1,3,5... and so on
    /// </summary>
    public int? tickSize { get; set; }

    /// <summary>
    /// min tick size to be used when plotting a time series. eg. [1, "day"]
    /// </summary>
    public object[] minTickSize { get; set; }

    /// <summary>
    /// Length of the tick lines in pixels. Set to 0 to hide tick lines, null
    /// means use default, else a value for to specify width.
    /// </summary>
    public int? tickLength { get; set; }

    /// <summary>
    /// Mode for the axis. Either "time" or null
    /// </summary>
    public string mode { get; set; }

    /// <summary>
    /// Format for the for the tick. See <a href="http://flot.googlecode.com/svn/trunk/API.txt"></a>
    /// for more information on the various available formats
    /// </summary>
    public string timeformat { get; set; }

    /// <summary>
    /// An array of names of months
    /// </summary>
    public string[] monthNames
    {
      get
      {
        return new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
      }
    }

    /// <summary>
    /// Flag indicating whether we are using a 12 hour nomenclature
    /// or a 24 hour nomenclature
    /// </summary>
    public bool? twelveHourClock { get; set; }

    /// <summary>
    /// Axis label to be shown
    /// </summary>
    public string axisLabel { get; set; }

    /// <summary>
    /// If set to true, the axis label will be drawn on the Flot canvas object itself. Y axis text will
    /// be vertical. If set to false, the axis label will be drawn as a HTML DIV element and text will
    /// always be horizontal irrespective of X or Y axis.
    /// </summary>
    private bool m_axisLabelUseCanvas;

    /// <summary>
    /// If set to true, the axis label will be drawn on the Flot canvas object itself. Y axis text will
    /// be vertical. If set to false, the axis label will be drawn as a HTML DIV element and text will
    /// always be horizontal irrespective of X or Y axis.
    /// </summary>
    public bool axisLabelUseCanvas
    {
      get { return m_axisLabelUseCanvas; }

      set
      {
        m_axisLabelUseCanvas = value;
        if (!value)
        {
          // automatically reset the font family and font size
          axisLabelFontFamily = null;
          axisLabelFontSizePixels = null;
        }
      }
    }

    /// <summary>
    /// Font size in pixels for the axis label. This option is only available if 'axisLabelUseCanvas' 
    /// is set to true
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int? axisLabelFontSizePixels { get; set; }

    /// <summary>
    /// Font family for the axis label. This option is only available if 'axisLabelUseCanvas' is
    /// set to true
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string axisLabelFontFamily { get; set; }
  }
}
