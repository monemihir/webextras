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

using Newtonsoft.Json;
using System;

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Axis tick renderer options
  /// </summary>
  [Serializable]
  public class AxisTickRendererOptions : AxisTickRendererOptionsBase, IRendererOptions
  {
    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName { get { return "AxisTickRenderer"; } }

    /// <summary>
    /// Length of the tick beyond the grid in pixels.
    /// </summary>
    [Obsolete("Use 'markSize' instead")]
    public int? size { get; set; }
    
    /// <summary>
    /// Whether to escape HTML entities in the label.
    /// </summary>
    public string escapeHTML { get; set; }
  }
}
