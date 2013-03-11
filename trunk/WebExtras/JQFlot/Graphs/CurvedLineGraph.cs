/*
* This file is part of - Code Library
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

namespace WebExtras.JQFlot.Graphs
{
  /// <summary>
  /// curved line options
  /// </summary>
  [Serializable]
  public class CurvedLineGraph
  {
    /// <summary>
    /// ctor to initialize defaults. show=false, lineWidth=1, fill=false,
    /// fit=true, fitPointDist=0, fillColor=''
    /// </summary>
    public CurvedLineGraph()
    {
      show = false;
      lineWidth = 1;
      fill = false;
      fit = true;
      fitPointDist = 0;
      fillColor = string.Empty;
    }

    /// <summary>
    /// whether to show curved lines.
    /// </summary>
    public bool show { get; set; }

    /// <summary>
    /// line width
    /// </summary>
    public int lineWidth { get; set; }

    /// <summary>
    /// whether the area under the curved line should be filled
    /// </summary>
    public bool fill { get; set; }

    /// <summary>
    /// whether to fit the series to the available canvas area
    /// </summary>
    public bool fit { get; set; }

    /// <summary>
    /// defines the x axis distance of the additional two points
    /// that are used to enforce the min max condition
    /// </summary>
    public double fitPointDist { get; set; }

    /// <summary>
    /// color to fill the series with if other than the default series color.
    /// If left blank, the default series color will be used.
    /// </summary>
    public string fillColor { get; set; }
  }
}
