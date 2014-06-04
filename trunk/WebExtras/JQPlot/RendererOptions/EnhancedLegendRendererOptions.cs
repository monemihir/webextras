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

using Newtonsoft.Json;

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Enhanced legend renderer options
  /// </summary>
  public class EnhancedLegendRendererOptions : LegendRendererOptionsBase, IRendererOptions
  {
    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName { get { return "EnhancedLegendRenderer"; } }

    /// <summary>
    /// False to not enable series on/off toggling on the legend. True or a fadein/fadeout 
    /// speed (number of milliseconds or ‘fast’, ‘normal’, ‘slow’) to enable show/hide of 
    /// series on click of legend item.
    /// </summary>
    public object seriesToggle;

    /// <summary>
    /// True to toggle series with a show/hide method only and not allow fading in/out.  
    /// This is to overcome poor performance of fade in some versions of IE.
    /// </summary>
    public bool? disableIEFading;
  }
}
