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

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// Represents a markings object
  /// </summary>
  [Serializable]
  public class MarkingOptions
  {
    /// <summary>
    /// X axis markings
    /// </summary>
    public MarkingRangeOptions xaxis;

    /// <summary>
    /// Y Axis markings
    /// </summary>
    public MarkingRangeOptions yaxis;

    /// <summary>
    /// Markings color. This must be a CSS color specificaiton.
    /// </summary>
    public string color;

    /// <summary>
    /// Markings line width in pixels
    /// </summary>
    public int? lineWidth;
  }
}
