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
  /// flot axis options
  /// </summary>
  [Serializable]
  public class AxisOptions
  {
    #region Default options

    /// <summary>
    /// Flag indicating whether to show axis
    /// </summary>
    public bool? show;

    /// <summary>
    /// Position of the axis on the graph. Can be one of 'bottom', 'top', 'left' or 'right'.
    /// </summary>
    public string position;

    /// <summary>
    /// Time zone of Flot graph. Setting this only makes sense when using time mode rendering.
    /// Can be either 'browser' or a timezone in the format 'UTC+1100'.
    /// </summary>
    public string timezone;

    /// <summary>
    /// Color for the axis. This must be a CSS color specification.
    /// </summary>
    public string color;

    /// <summary>
    /// Color for the ticks. This must be a CSS color specification.
    /// </summary>
    public string tickColor;

    /// <summary>
    /// Font to the used to render ticks. This must be a CSS font specification.
    /// </summary>
    public string font;

    /// <summary>
    /// Axis min value
    /// </summary>
    public int? min;

    /// <summary>
    /// Axis max value
    /// </summary>
    public int? max;

    /// <summary>
    /// The fraction of margin that the scaling algorithm will add to avoid the outermost
    /// points ending up on the grid border.
    /// </summary>
    public double? autoscaleMargin;

    /// <summary>
    /// Transform callback function
    /// </summary>
    public JsFunc transform;

    /// <summary>
    /// Inverse transform callback function
    /// </summary>
    public JsFunc inverseTransform;

    /// <summary>
    /// Can be a number indicating the no. of ticks needed, an array manually specifying
    /// all the ticks to be rendered or a <see cref="WebExtras.Core.JsFunc"/>.
    /// </summary>
    public object ticks;

    /// <summary>
    /// Tick interval size
    /// </summary>
    public int? tickSize;

    /// <summary>
    /// Predominantly used when rendering time series. The format for this array is [2, "month"]
    /// where the second value in the array can be 'second', 'minute', 'hour', 'day', 'month'
    /// or 'year'
    /// </summary>
    public object[] minTickSize;

    /// <summary>
    /// Tick formatter
    /// </summary>
    public JsFunc tickFormatter;

    /// <summary>
    /// Tick decimal places
    /// </summary>
    public int? tickDecimals;

    /// <summary>
    /// Fixed width of tick labels in pixels
    /// </summary>
    public int? labelWidth;

    /// <summary>
    /// Fixed height of tick labels in pixels
    /// </summary>
    public int? labelHeight;

    /// <summary>
    /// Flag indicating whether to reserve space for tick even if the axis is not shown
    /// </summary>
    public bool? reserveSpace;

    /// <summary>
    /// Length of tick lines in pixels
    /// </summary>
    public int? tickLength;

    /// <summary>
    /// The number of another axis to align ticks of current axis to. This is useful when you have
    /// Y axes on left and right and you want the ticks to line up properly. The trade-off is that
    /// the forced ticks won't necessarily be at natural places.
    /// </summary>
    public int? alignTicksWithAxis;

    #endregion Default options

    #region Time series options

    /// <summary>
    /// Specify render mode of the axis. If displaying a time graph this must be set to 'time'.
    /// When using time mode the jquery.flot.time.js plugin is needed
    /// </summary>
    public string mode;

    /// <summary>
    /// Time format for the tick. See <a href="https://github.com/flot/flot/blob/master/API.md"></a>
    /// for more information on the various available formats
    /// </summary>
    public string timeformat;

    /// <summary>
    /// An array of names of months
    /// </summary>
    public string[] monthNames;

    /// <summary>
    /// An array of names of days
    /// </summary>
    public string[] dayNames;

    /// <summary>
    /// Flag indicating whether we are using a 12 hour nomenclature
    /// or a 24 hour nomenclature
    /// </summary>
    public bool? twelveHourClock;

    #endregion Time series options

    #region Axis label extension options

    /// <summary>
    /// Axis label to be shown
    /// </summary>
    public string axisLabel;

    /// <summary>
    /// Whether to use Canvas to draw axis label
    /// </summary>
    private bool? m_axisLabelUseCanvas;

    /// <summary>
    /// Whether to use Canvas to draw axis label
    /// </summary>
    public bool? axisLabelUseCanvas
    {
      get { return m_axisLabelUseCanvas; }
      set
      {
        m_axisLabelUseCanvas = value;
        m_axisLabelUseHtml = null;
      }
    }

    /// <summary>
    /// Whether to use HTML to draw axis label
    /// </summary>
    private bool? m_axisLabelUseHtml;

    /// <summary>
    /// whether to use HTML to draw axis label
    /// </summary>
    public bool? axisLabelUseHtml
    {
      get { return m_axisLabelUseHtml; }
      set
      {
        m_axisLabelUseHtml = value;
        m_axisLabelUseCanvas = null;
      }
    }

    /// <summary>
    /// Font size in pixels for the axis label. This option is only available if 'axisLabelUseCanvas' 
    /// is set to true
    /// </summary>
    public int? axisLabelFontSizePixels;

    /// <summary>
    /// Font family for the axis label. This option is only available if 'axisLabelUseCanvas' is
    /// set to true
    /// </summary>
    public string axisLabelFontFamily;

    /// <summary>
    /// This must be a valid CSS color specification
    /// </summary>
    public string axisLabelColor;

    #endregion Axis label extension options

    /// <summary>
    /// Default constructor
    /// </summary>
    public AxisOptions()
    {
      axisLabel = string.Empty;
    }
  }
}
