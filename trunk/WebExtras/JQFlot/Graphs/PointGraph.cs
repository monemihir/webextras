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

namespace WebExtras.JQFlot.Graphs
{
  /// <summary>
  /// point options
  /// </summary>
  [Serializable]
  public class PointGraph : BaseGraph
  {
    /// <summary>
    /// The radius in pixels of the points
    /// </summary>
    public int? radius;

    /// <summary>
    /// Point symbol generator function
    /// </summary>
    public JsFunc symbol;
  }
}
