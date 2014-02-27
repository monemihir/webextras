/*
* This file is part of - WebExtras Demo application
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
  /// CanvasAxisTickRenderer options
  /// </summary>
  [Serializable]
  [JsonConverter(typeof(RendererOptionsJsonConverter))]
  public class CanvasAxisTickRendererOptions : AxisTickRendererOptionsBase, IRendererOptions
  {
    /// <summary>
    /// angle of text, measured clockwise from x axis.
    /// </summary>
    public int? angle { get; set; }

    /// <summary>
    /// Label position
    /// </summary>
    public ELabelPosition? labelPosition { get; set; }

    /// <summary>
    /// CSS spec for fontWeight
    /// </summary>
    public string fontWeight { get; set; }

    /// <summary>
    /// Multiplier to condense or expand font width. Applies only to browsers 
    /// which don’t support canvas native font rendering.
    /// </summary>
    public double? fontStretch { get; set; }

    /// <summary>
    /// true to turn on native canvas font support in Mozilla 3.5+ and Safari 4+.  
    /// If true, tick label will be drawn with canvas tag native support for fonts.  
    /// If false, tick label will be drawn with Hershey font metrics.
    /// </summary>
    public bool? enableFontSupport { get; set; }

    /// <summary>
    /// Point to pixel scaling factor, used for computing height of bounding box 
    /// around a label. The labels text renderer has a default setting of 1.4, which 
    /// should be suitable for most fonts.  Leave as null to use default. If tops of 
    /// letters appear clipped, increase this. If bounding box seems too big, decrease.  
    /// This is an issue only with the native font rendering capabilities of Mozilla 
    /// 3.5 and Safari 4 since they do not provide a method to determine the font height.
    /// </summary>
    public double? pt2px { get; set; }
  }

}
