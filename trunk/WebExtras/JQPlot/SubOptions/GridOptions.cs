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
using Newtonsoft.Json;
using WebExtras.JQPlot.RendererOptions;

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Grid options
  /// </summary>
  [Serializable]
  public class GridOptions
  {
    /// <summary>
    /// Whether to draw gridlines on the plot 
    /// </summary>
    public bool? drawGridlines;

    /// <summary>
    /// css color of the grid lines.
    /// </summary>
    public string gridLineColor;

    /// <summary>
    /// width of the grid lines.
    /// </summary>
    public double? gridLineWidth;

    /// <summary>
    /// css spec for the background color.
    /// </summary>
    public string background;

    /// <summary>
    /// css spec for the color of the grid border.
    /// </summary>
    public string borderColor;

    /// <summary>
    /// width of the border in pixels.
    /// </summary>
    public double? borderWidth;

    /// <summary>
    /// True to draw border around grid.
    /// </summary>
    public bool? drawBorder;

    /// <summary>
    /// whether or not to draw a shadow on the line
    /// </summary>
    public bool? shadow;

    /// <summary>
    /// Shadow angle in degrees
    /// </summary>
    public int? shadowAngle;

    /// <summary>
    /// Shadow offset from line in pixels
    /// </summary>
    public double? shadowOffset;

    /// <summary>
    /// Number of times shadow is stroked, each stroke offset shadowOffset from the last.
    /// </summary>
    public int? shadowDepth;

    /// <summary>
    /// an optional css color spec for the shadow in ‘rgba(n, n, n, n)’ form
    /// </summary>
    public string shadowColor;

    /// <summary>
    /// Alpha channel transparency of shadow.  0 = transparent.
    /// </summary>
    public string shadowAlpha;

    /// <summary>
    /// Instance of a renderer which will actually render the grid, see $.jqplot.CanvasGridRenderer.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public EJQPlotRenderer? renderer;

    /// <summary>
    /// Options to pass on to the renderer, see $.jqplot.CanvasGridRenderer.
    /// </summary>
    public IRendererOptions rendererOptions;
  }
}
