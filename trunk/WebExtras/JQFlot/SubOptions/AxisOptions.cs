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

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// flot axis options
  /// </summary>
  [Serializable]
  public class AxisOptions
  {
    /// <summary>
    /// ctor to intialize defaults. tickDecimals=0
    /// </summary>
    public AxisOptions()
    {
      tickDecimals = 0;
      mode = null;
      timeformat = null;
      minTickSize = null;
      tickLength = 0;
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
  }
}
