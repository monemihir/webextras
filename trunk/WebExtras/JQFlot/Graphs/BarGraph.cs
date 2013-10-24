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

namespace WebExtras.JQFlot.Graphs
{
  /// <summary>
  /// Represents a bar graph
  /// </summary>
  [Serializable]
  public class BarGraph : BaseGraph
  {
    /// <summary>
    /// Specifies whether chart should normally start from zero.
    /// </summary>
    public bool? zero;

    /// <summary>
    /// The width of the bars in the units of the x axis (or y axis if horizontal is set to true)
    /// </summary>
    public int? barWidth;

    /// <summary>
    /// Specifies how a bar should be aligned. Can be one of 'left', 'right' or 'center'
    /// </summary>
    public string align;

    /// <summary>
    /// Whether to draw the bars horizontally
    /// </summary>
    public bool? horizontal;
  }
}
