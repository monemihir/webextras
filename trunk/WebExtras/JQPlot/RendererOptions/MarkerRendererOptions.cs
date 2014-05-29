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
using WebExtras.JQPlot.SubOptions;

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Marker renderer options
  /// </summary>
  [Serializable]
  public class MarkerRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Whether or not to show the marker.
    /// </summary>
    public bool? show;

    /// <summary>
    /// Marker style
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public EMarkerStyle? style;

    /// <summary>
    /// size of the line for non-filled markers.
    /// </summary>
    public double? lineWidth;

    /// <summary>
    /// Size of the marker (diameter or circle, length of edge of square, etc.)
    /// </summary>
    public double? size;

    /// <summary>
    /// css color spec for the series
    /// </summary>
    public string color;

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
    /// Alpha channel transparency of shadow.  0 = transparent.
    /// </summary>
    public string shadowAlpha;

    /// <summary>
    /// Renderer that will draws the shadows on the marker.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public EJQPlotRenderer? shadowRenderer;

    /// <summary>
    /// Renderer that will draw the marker.
    /// </summary>
    [JsonConverter(typeof(JQPlotEnumStringValueJsonConverter))]
    public EJQPlotRenderer? shapeRenderer;
  }
}
