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
  /// line options
  /// </summary>
  [Serializable]
  public class LineGraph : BaseGraph
  {
    /// <summary>
    /// Specifies whether chart should normally start from zero.
    /// </summary>
    public bool? zero;

    /// <summary>
    /// Whether two adjacent points are connected with a straight line or a 
    /// step i.e a horizontal line followed by a vertical line
    /// </summary>
    public bool? steps;

    /// <summary>
    /// Default constructor
    /// </summary>
    public LineGraph() { }    
  }
}
