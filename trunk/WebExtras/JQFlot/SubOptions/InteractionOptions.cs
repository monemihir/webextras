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
  /// Represents Flot interaction options
  /// </summary>
  [Serializable]
  public class InteractionOptions
  {
    /// <summary>
    /// A numeric FPS value which specified maximum time to delay a redraw of
    /// interactive things. Set it to -1 to disable delay.
    /// </summary>
    public int? redrawOverlayInterval;
  }
}
