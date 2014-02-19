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

namespace WebExtras.JQFlot.Graphs
{
  /// <summary>
  /// curved line options
  /// </summary>
  [Serializable]
  public class CurvedLineGraph : BaseGraph
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    public CurvedLineGraph() { fit = true; fitPointDist = 0; }

    /// <summary>
    /// whether to fit the series to the available canvas area
    /// </summary>
    public bool? fit;

    /// <summary>
    /// defines the x axis distance of the additional two points
    /// that are used to enforce the min max condition
    /// </summary>
    public double? fitPointDist;
  }
}
