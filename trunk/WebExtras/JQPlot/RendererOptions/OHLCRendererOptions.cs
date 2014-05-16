/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// OHLCRenderer options
  /// </summary>
  [Serializable]
  public class OHLCRendererOptions : IRendererOptions
  {
    /// <summary>
    /// true to render chart as candleStick.  Must have an open 
    /// price, cannot be a hlc chart.
    /// </summary>
    public bool? candleStick { get; set; }

    /// <summary>
    /// length of the line in pixels indicating open and close price.  
    /// Default will auto calculate based on plot width and number 
    /// of points displayed.
    /// </summary>
    public string tickLength { get; set; }

    /// <summary>
    /// width of the candlestick body in pixels. Default will auto 
    /// calculate based on plot width and number of candlesticks displayed.
    /// </summary>
    public string bodyWidth { get; set; }

    /// <summary>
    /// color of the open price tick mark.  Default is series color.
    /// </summary>
    public string openColor { get; set; }

    /// <summary>
    /// color of the close price tick mark.  Default is series color.
    /// </summary>
    public string closeColor { get; set; }

    /// <summary>
    /// color of the hi-lo line thorugh the candlestick body.  Default is 
    /// the series color.
    /// </summary>
    public string wickColor { get; set; }

    /// <summary>
    /// true to render an “up” day (close price greater than open price) with a filled candlestick body.
    /// </summary>
    public bool? fillUpBody { get; set; }

    /// <summary>
    /// true to render a “down” day (close price lower than open price) with a filled candlestick body.
    /// </summary>
    public bool? fillDownBody { get; set; }

    /// <summary>
    /// Color of candlestick body of an “up” day.  Default is series color.
    /// </summary>
    public string upBodyColor { get; set; }

    /// <summary>
    /// Color of candlestick body on a “down” day.  Default is series color.
    /// </summary>
    public string downBodyColor { get; set; }

    /// <summary>
    /// true if is a hi-low-close chart (no open price).  This is determined automatically from the series data.
    /// </summary>
    public bool? hlc { get; set; }

    /// <summary>
    /// Width of the hi-low line and open/close ticks.  Must be set in the rendererOptions for the series.
    /// </summary>
    public double? lineWidth { get; set; }
  }
}
