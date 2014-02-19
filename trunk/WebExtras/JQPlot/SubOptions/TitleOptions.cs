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


namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Title options
  /// </summary>
  public class TitleOptions
  {
    /// <summary>
    /// Title text
    /// </summary>
    public string text;

    /// <summary>
    /// Whether to show the title
    /// </summary>
    public bool? show;

    /// <summary>
    /// css font-family spec for the legend text.
    /// </summary>
    public string fontFamily;

    /// <summary>
    /// css font-size spec for the legend text.
    /// </summary>
    public string fontSize;

    /// <summary>
    /// css text-align spec for the text.
    /// </summary>
    public string textAlign;

    /// <summary>
    /// css color spec for the legend text.
    /// </summary>
    public string textColor;

    /// <summary>
    /// A class for creating a DOM element for the title, see $.jqplot.DivTitleRenderer.
    /// </summary>
    public ETitleRenderer renderer;

    /// <summary>
    /// renderer specific options passed to the renderer.
    /// </summary>
    public object rendererOptions;
  }
}
