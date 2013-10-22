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
  /// Represents Pie graph's background options
  /// </summary>
  [Serializable]
  public class PieBackgroundOptions
  {
    /// <summary>
    /// Background color of the positioned labels. If null the plugin will 
    /// automatically use the color of the slice
    /// </summary>
    public string color;

    /// <summary>
    /// Opacity of the background for the positioned labels.
    /// Values can be from 0 to 1 where 0 is complete transparent
    /// and 1 if completely opaque
    /// </summary>
    public double? opacity;
  }
}
