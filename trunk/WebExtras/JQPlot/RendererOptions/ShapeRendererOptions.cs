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
  /// Shape renderer options
  /// </summary>
  [Serializable]
  public class ShapeRendererOptions : IRendererOptions
  {
    string m_lineJoin;
    string m_lineCap;

    /// <summary>
    /// Name of the associated renderer for which these options are
    /// </summary>
    [JsonIgnore]
    public string AssociatedRendererName { get { return "ShapeRenderer"; } }

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
    /// wether the shadow is an arc or not.
    /// </summary>
    public bool? isarc { get; set; }

    /// <summary>
    /// true to draw shape as a filled rectangle.
    /// </summary>
    public bool? fillRect { get; set; }

    /// <summary>
    /// true to draw shape as a stroked rectangle.
    /// </summary>
    public bool? strokeRect { get; set; }

    /// <summary>
    /// true to cear a rectangle.
    /// </summary>
    public bool? clearRect { get; set; }

    /// <summary>
    /// CSS color spec for the stoke style
    /// </summary>
    public string strokeStyle { get; set; }

    /// <summary>
    /// CSS color spec for the fill style.
    /// </summary>
    public string fillStyle { get; set; }
  }
}
