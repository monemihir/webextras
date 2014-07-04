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
using Newtonsoft.Json;
using WebExtras.Core;
using WebExtras.JQFlot.SubOptions;

namespace WebExtras.JQFlot
{
  /// <summary>
  /// flot chart options
  /// </summary>
  [Serializable]
  public class FlotOptions
  {
    /// <summary>
    /// X axis 1
    /// </summary>
    public AxisOptions xaxis;

    /// <summary>
    /// Y axis 1
    /// </summary>
    public AxisOptions yaxis;

    /// <summary>
    /// X axis 2
    /// </summary>
    public AxisOptions x2axis;

    /// <summary>
    /// Y axis 2
    /// </summary>
    public AxisOptions y2axis;

    /// <summary>
    /// Multiple X axis definitions
    /// </summary>
    public AxisOptions[] xaxes;

    /// <summary>
    /// Multiple Y axis definitions
    /// </summary>
    public AxisOptions[] yaxes;

    /// <summary>
    /// Legend options
    /// </summary>
    public LegendOptions legend;

    /// <summary>
    /// Chart grid options
    /// </summary>
    public GridOptions grid;

    /// <summary>
    /// Chart series options
    /// </summary>
    public SeriesOptions series;

    /// <summary>
    /// An array of CSS color specifications to choose from when drawing the various series
    /// </summary>
    public string[] colors;

    /// <summary>
    /// JSON serializes the current Flot options
    /// </summary>
    /// <returns>JSON serialized object</returns>
    public override string ToString()
    {
      return this.ToJson();
    }
  }
}