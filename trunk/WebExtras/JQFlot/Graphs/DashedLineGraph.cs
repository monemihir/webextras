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
  /// dash options
  /// </summary>
  [Serializable]
  public class DashedLineGraph
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    public DashedLineGraph()
    {
      show = true;
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
}
