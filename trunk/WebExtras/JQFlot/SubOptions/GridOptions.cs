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
  /// flot grid options
  /// </summary>
  [Serializable]
  public class GridOptions
  {
    /// <summary>
    /// Whether to show the grid
    /// </summary>
    public bool? show;

    /// <summary>
    /// Whether to show grid above the data
    /// </summary>
    public bool? aboveData;

    /// <summary>
    /// Grid color. This must be a CSS color specification.
    /// </summary>
    public string color;

    /// <summary>
    /// Grid background color. Can be a single CSS color specification or
    /// a <see cref="WebExtras.JQFlot.SubOptions.ColorGradientOptions"/> object
    /// </summary>
    public object backgroundColor;

    /// <summary>
    /// Grid margin. Can be a number or a <see cref="WebExtras.JQFlot.SubOptions.DimensionOptions"/> object
    /// </summary>
    public object margin;

    /// <summary>
    /// Grid label margin in pixels
    /// </summary>
    public int? labelMargin;

    /// <summary>
    /// Axis margin in pixels
    /// </summary>
    public int? axisMargin;

    /// <summary>
    /// Markings to be drawn on the grid. This can be a collection of <see cref="WebExtras.JQFlot.SubOptions.MarkingOptions"/>
    /// or a <see cref="WebExtras.Core.JsFunc"/> object
    /// </summary>
    public object markings;

    /// <summary>
    /// Grid border width. Can be a number or a 
    /// <see cref="WebExtras.JQFlot.SubOptions.DimensionOptions"/> object
    /// </summary>
    public object borderWidth;

    /// <summary>
    /// Grid border color. All colors must be CSS color specifications. Can be a
    /// single color or a <see cref="WebExtras.JQFlot.SubOptions.DimensionOptions"/> object
    /// </summary>
    public object borderColor;

    /// <summary>
    /// Minimum border margin in pixels
    /// </summary>
    public int? minBorderMargin;

    /// <summary>
    /// Whether the grid is clickable
    /// </summary>
    public bool? clickable;

    /// <summary>
    /// Whether the grid is hoverable
    /// </summary>
    public bool? hoverable;

    /// <summary>
    /// Whether to highlight nearby items automatically on plot hover/click.
    /// See the 'plothover' and 'plotclick' events for the plot
    /// </summary>
    public bool? autoHighlight;

    /// <summary>
    /// Mouse action radius
    /// </summary>
    public int? mouseActiveRadius;
  }
}
