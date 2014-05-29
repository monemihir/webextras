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
  /// Axis label renderer options
  /// </summary>
  [Serializable]
  public class AxisLabelRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Whether or not to show the tick (mark and label).
    /// </summary>
    public bool? show { get; set; }

    /// <summary>
    /// The text or html for the label.
    /// </summary>
    public string label { get; set; }

    /// <summary>
    /// true to escape HTML entities in the label.
    /// </summary>
    public bool? escapeHTML { get; set; }
  }
}
