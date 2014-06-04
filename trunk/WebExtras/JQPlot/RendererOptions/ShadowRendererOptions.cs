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

namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Shadow renderer options
  /// </summary>
  [Serializable]
  public class ShadowRendererOptions : IRendererOptions
  {
    string m_lineJoin;
    string m_lineCap;

    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName { get { return "ShadowRenderer"; } }

    /// <summary>
    /// Angle of the shadow in degrees.  Measured counter-clockwise from the x axis.
    /// </summary>
    public int? angle { get; set; }

    /// <summary>
    /// Pixel offset at the given shadow angle of each shadow stroke from the last stroke.
    /// </summary>
    public int? offset { get; set; }

    /// <summary>
    /// alpha transparency of shadow stroke.
    /// </summary>
    public double? alpha { get; set; }

    /// <summary>
    /// width of the shadow line stroke.
    /// </summary>
    public double? lineWidth { get; set; }

    /// <summary>
    /// How line segments of the shadow are joined. Allowed value is 'miter'.
    /// </summary>
    public string lineJoin
    {
      get { return m_lineJoin; }
      set
      {
        if (value != "miter")
          throw new InvalidOperationException("The only allowed value for this property is: miter");

        m_lineJoin = value;
      }
    }

    /// <summary>
    /// how ends of the shadow line are rendered. Allowed value is 'round'.
    /// </summary>
    public string lineCap
    {
      get { return m_lineCap; }
      set
      {
        if (value != "round")
          throw new InvalidOperationException("The only allowed value for this property is: round");

        m_lineCap = value;
      }
    }

    /// <summary>
    /// whether to fill the shape.
    /// </summary>
    public bool? fill { get; set; }

    /// <summary>
    /// how many times the shadow is stroked.  Each stroke will be offset by offset at angle degrees.
    /// </summary>
    public int? depth { get; set; }

    /// <summary>
    /// wether the shadow is an arc or not.
    /// </summary>
    public bool? isarc { get; set; }
  }
}
