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
using WebExtras.Core;

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// Represents Pie graph's label options
  /// </summary>
  [Serializable]
  public class PieLabelOptions
  {
    /// <summary>
    /// Whether to show label. If unset, it will automatically
    /// be set to 'false' if legend is enabled, else 'true'
    /// </summary>
    public bool? show;

    /// <summary>
    /// Radius at which to place the labels. If value is between 0
    /// and 1 (inclusive) then it will use that as a percentage of
    /// the container size, otherwise it will use the value as a 
    /// direct pixel length
    /// </summary>
    public double? radius;

    /// <summary>
    /// Hides the labels of any pie slice that is smaller than the 
    /// specified percentage (ranging from 0 to 1). For e.g. a value 
    /// of '0.03' will hide any labels with values 3% or less of total
    /// </summary>
    public double? threshold;

    /// <summary>
    /// Label formatter function
    /// </summary>
    public JsFunc formatter;

    /// <summary>
    /// Pie background color options
    /// </summary>
    public PieBackgroundOptions background;
  }
}
