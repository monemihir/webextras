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

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// Represents a pie graph's shadow definition
  /// </summary>
  [Serializable]
  public class PieShadowOptions
  {
    /// <summary>
    /// Vertical distance in pixels of the tilted pie shadow
    /// </summary>
    public int? top;

    /// <summary>
    /// Horizontal distance in pixels of the tilted pie shadow
    /// </summary>
    public int? left;

    /// <summary>
    /// Alpha value of the tilted pie shadow
    /// </summary>
    public double? alpha;
  }
}
