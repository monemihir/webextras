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

namespace WebExtras.JQPlot.SubOptions
{
  /// <summary>
  /// Legend options
  /// </summary>
  public class LegendOptions
  {
    /// <summary>
    /// Whether to display the legend on the graph
    /// </summary>
    public bool? show;

    /// <summary>
    /// Legend location
    /// </summary>
    public ELegendLocation location;

    /// <summary>
    /// Array of labels to use.  By default the renderer will look 
    /// for labels on the series.  Labels specified in this array 
    /// will override labels specified on the series.
    /// </summary>
    public string[] labels;

    /// <summary>
    /// Whether to show the label text on the legend.
    /// </summary>
    public bool? showLabels;

    /// <summary>
    /// Whether to show the color swatches on the legend.
    /// </summary>
    public bool? showSwatch;

    /// <summary>
    /// ”insideGrid” places legend inside the grid area of the plot.  
    /// “outsideGrid” places the legend outside the grid but inside 
    /// the plot container, shrinking the grid to accomodate the legend.  
    /// “inside” synonym for “insideGrid”, “outside” places the legend 
    /// ouside the grid area, but does not shrink the grid which can 
    /// cause the legend to overflow the plot container.
    /// </summary>
    public ELegendPlacement placement;

    /// <summary>
    /// Set the margins on the legend using the marginTop, marginLeft, 
    /// etc. properties or via CSS margin styling of the .jqplot-table-legend class.
    /// </summary>
    [Obsolete("Use 'marginTop', 'marginBottom', 'marginLeft' and 'marginRight' instead")]
    public int? xoffset;

    /// <summary>
    /// Set the margins on the legend using the marginTop, marginLeft, 
    /// etc. properties or via CSS margin styling of the .jqplot-table-legend class.
    /// </summary>
    [Obsolete("Use 'marginTop', 'marginBottom', 'marginLeft' and 'marginRight' instead")]
    public int? yoffset;

    /// <summary>
    /// css spec for the border around the legend box.
    /// </summary>
    public string border;

    /// <summary>
    /// css spec for the background of the legend box.
    /// </summary>
    public string background;

    /// <summary>
    /// css color spec for the legend text.
    /// </summary>
    public string textColor;

    /// <summary>
    /// css font-family spec for the legend text.
    /// </summary>
    public string fontFamily;

    /// <summary>
    /// css font-size spec for the legend text.
    /// </summary>
    public string fontSize;

    /// <summary>
    /// css padding-top spec for the rows in the legend.
    /// </summary>
    public string rowSpacing;

    /// <summary>
    /// renderer specific options passed to the renderer.
    /// </summary>
    public object rendererOptions;

    /// <summary>
    /// Whether to draw the legend before the series or not.  
    /// Used with series specific legend renderers for pie, donut, mekko charts, etc.
    /// </summary>
    public bool? predraw;

    /// <summary>
    /// CSS margin for the legend DOM element. This will set an element CSS style for 
    /// the margin which will override any style sheet setting. The default will be 
    /// taken from the stylesheet.
    /// </summary>
    public string marginTop;

    /// <summary>
    /// CSS margin for the legend DOM element. This will set an element CSS style for 
    /// the margin which will override any style sheet setting. The default will be 
    /// taken from the stylesheet.
    /// </summary>
    public string marginBottom;

    /// <summary>
    /// CSS margin for the legend DOM element. This will set an element CSS style for 
    /// the margin which will override any style sheet setting. The default will be 
    /// taken from the stylesheet.
    /// </summary>
    public string marginLeft;

    /// <summary>
    /// CSS margin for the legend DOM element. This will set an element CSS style for 
    /// the margin which will override any style sheet setting. The default will be 
    /// taken from the stylesheet.
    /// </summary>
    public string marginRight;
  }
}
