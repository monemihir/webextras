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
using Newtonsoft.Json;
using WebExtras.Core;

namespace WebExtras.JQFlot
{
  /// <summary>
  /// a flot chart containing options and series to be plotted
  /// </summary>
  [Serializable]
  public class FlotChart
  {
    /// <summary>
    /// Flot chart options
    /// </summary>
    public FlotOptions chartOptions { get; set; }

    /// <summary>
    /// Flot chart series to be plotted
    /// </summary>
    public FlotSeries[] chartSeries { get; set; }

    /// <summary>
    /// Converts the flot chart to a JSON serialized object
    /// </summary>
    /// <returns>JSON serialized object</returns>
    public override string ToString()
    {
      return JsonConvert.SerializeObject(this, WebExtrasConstants.JsonSerializerSettings);
    }
  }
}
