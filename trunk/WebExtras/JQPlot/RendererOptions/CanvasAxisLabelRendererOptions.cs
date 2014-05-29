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

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Canvas axis label  renderer options
  /// </summary>
  [Serializable]
  public class CanvasAxisLabelRendererOptions : IRendererOptions
  {
    /// <summary>
    /// angle of text, measured clockwise from x axis.
    /// </summary>
    public int? angle;

    /// <summary>
    /// whether or not to show the tick (mark and label).
    /// </summary>
    public bool? show;

    /// <summary>
    /// whether or not to show the label.
    /// </summary>
    public bool? showLabel;

    /// <summary>
    /// label for the axis.
    /// </summary>
    public string label;

    /// <summary>
    /// CSS spec for the font-family css attribute.  Applies only to browsers supporting 
    /// native font rendering in the canvas tag.  Currently Mozilla 3.5 and Safari 4.
    /// </summary>
    public string fontFamily;

    /// <summary>
    /// CSS spec for font size.
    /// </summary>
    public string fontSize;

    /// <summary>
    /// CSS spec for fontWeight: normal, bold, bolder, lighter or a number 100	900
    /// </summary>
    public string fontWeight;

    /// <summary>
    /// Multiplier to condense or expand font width.  Applies only to browsers which 
    /// don’t support canvas native font rendering.
    /// </summary>
    public double? fontStretch;

    /// <summary>
    /// CSS spec for the color attribute.
    /// </summary>
    public string textColor;

    /// <summary>
    /// true to turn on native canvas font support in Mozilla 3.5+ and Safari 4+.  
    /// If true, label will be drawn with canvas tag native support for fonts.  
    /// If false, label will be drawn with Hershey font metrics.
    /// </summary>
    public bool? enableFontSupport;

    /// <summary>
    /// Point to pixel scaling factor, used for computing height of bounding box around a label.  
    /// The labels text renderer has a default setting of 1.4, which should be suitable for 
    /// most fonts.  Leave as null to use default.  If tops of letters appear clipped, increase 
    /// this.  If bounding box seems too big, decrease.  This is an issue only with the native 
    /// font renderering capabilities of Mozilla 3.5 and Safari 4 since they do not provide a 
    /// method to determine the font height.
    /// </summary>
    public double? pt2px;
  }
}
