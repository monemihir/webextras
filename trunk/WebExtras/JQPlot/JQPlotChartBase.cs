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

using Newtonsoft.Json;
using System;
using WebExtras.Core;

namespace WebExtras.JQPlot
{
  /// <summary>
  /// jqPlot chart
  /// </summary>
  [Serializable]
  public class JQPlotChartBase
  {
    /// <summary>
    /// Chart data
    /// </summary>
    public object chartData { get; set; }

    /// <summary>
    /// Chart options
    /// </summary>
    public JQPlotOptions chartOptions { get; set; }

    /// <summary>
    /// Converts the flot chart to a JSON serialized object
    /// </summary>
    /// <returns>JSON serialized object</returns>
    public override string ToString()
    {
      return this.ToJson();
    }
  }
}
