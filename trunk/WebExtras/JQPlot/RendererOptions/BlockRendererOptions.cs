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

using System.Collections.Generic;

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Block renderer options
  /// </summary>
  public class BlockRendererOptions : IRendererOptions
  {
    /// <summary>
    /// Default css styles that will be applied to all data blocks. These values 
    /// will be overridden by css styles supplied with the individulal data points.
    /// </summary>
    public IDictionary<string, object> css { get; set; }

    /// <summary>
    /// True to escape html in the box label.
    /// </summary>
    public bool? escapeHtml { get; set; }

    /// <summary>
    /// True to turn spaces in data block label into html breaks <br />.
    /// </summary>
    public bool? insertBreaks { get; set; }

    /// <summary>
    /// True to vary the color of each block in this series according to the 
    /// seriesColors array.  False to set each block to the color specified on this 
    /// series.  This has no effect if a css background color option is specified in 
    /// the renderer css options.
    /// </summary>
    public bool? varyBlockColors { get; set; }
  }
}
