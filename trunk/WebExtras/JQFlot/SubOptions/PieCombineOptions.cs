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

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// Represents Pie graph's combine options
  /// </summary>
  public class PieCombineOptions
  {
    /// <summary>
    /// Percentage value at which to combine slices. Can
    /// be between 0 and 1
    /// </summary>
    public double? threshold;

    /// <summary>
    /// Color for the combined slices. This must be a 
    /// valid CSS color specification. Hexadecimal color
    /// specification are recommended. If unset, the plugin
    /// will automatically use the color of the first slice
    /// to be combined
    /// </summary>
    public string color;

    /// <summary>
    /// Label for the combined slice
    /// </summary>
    public string label;
  }
}
