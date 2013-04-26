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
using Newtonsoft.Json;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Specification for a Datatables data column
  /// </summary>
  [Serializable]
  public class AOColumn
  {
    /// <summary>
    /// Enable / Disable sorting based on this column
    /// </summary>
    public bool bSortable;

    /// <summary>
    /// CSS class for the cells of this column
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string sClass;

    /// <summary>
    /// The width of the column, this parameter may take any CSS value (3em, 20px etc)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string sWidth;

    /// <summary>
    /// Flag indicating whether the column is visible
    /// </summary>
    public bool bVisible;

    /// <summary>
    /// Default constructor
    /// </summary>
    public AOColumn()
    {
      bVisible = true;
    }
  }
}