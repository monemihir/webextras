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

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Line renderer options
  /// </summary>
  [Serializable]
  public class LineRendererOptions : IRendererOptions
  {
    /// <summary>
    /// True to highlight area on a filled plot when moused over.  
    /// This must be false to enable highlightMouseDown to highlight 
    /// when clicking on an area on a filled plot.
    /// </summary>
    public bool? highlightMouseOver { get; set; }

    /// <summary>
    /// True to highlight when a mouse button is pressed over an area 
    /// on a filled plot.  This will be disabled if highlightMouseOver is true.
    /// </summary>
    public bool? highlightMouseDown { get; set; }

    /// <summary>
    /// CSS color to use when highlighting an area on a filled plot.
    /// </summary>
    public string highlightColor { get; set; }
  }
}
