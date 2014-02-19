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
using WebExtras.JQFlot.SubOptions;

namespace WebExtras.JQFlot.Graphs
{
  /// <summary>
  /// Represents a Pie graph
  /// </summary>
  [Serializable]
  public class PieGraph
  {
    /// <summary>
    /// Whether to show graph
    /// </summary>
    public bool show;

    /// <summary>
    /// Radius of the pie. If not set will automatically be adjusted based
    /// on the size of the container
    /// </summary>
    public double? radius;

    /// <summary>
    /// Radius of the donut hole. If not set, will automatically default to 0.
    /// If value is between 0 and 1 it will be used as a percentage of the radius,
    /// otherwise if the value is greater than 1, it will be used as direct pixels
    /// </summary>
    public double? innerRadius;

    /// <summary>
    /// Factor of PI used as a start angle (in radians). Can be between
    /// 0 and 2 (where 0 and 2 have the same result).
    /// </summary>
    public double? startAngle;

    /// <summary>
    /// Percentage of tilt ranging from 0 to 1. 1 = fully vertical and
    /// 0 = fully horizontal in which case nothing gets drawn
    /// </summary>
    public double? tilt;

    /// <summary>
    /// Shadow dimension definitions for the graph
    /// </summary>
    public PieShadowOptions shadow;

    /// <summary>
    /// Offset dimension definitions for the graph
    /// </summary>
    public PieOffsetOptions offset;

    /// <summary>
    /// Stroke options for the graph
    /// </summary>
    public PieStrokeOptions stroke;

    /// <summary>
    /// Label options for the graph
    /// </summary>
    public PieLabelOptions label;

    /// <summary>
    /// Slice combine options for the graph
    /// </summary>
    public PieCombineOptions combine;

    /// <summary>
    /// Highlighting options for the graph
    /// </summary>
    public PieHightlightOptions highlight;
  }
}
