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

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Defines the global filtering state at initialisation time
  /// </summary>
  [Serializable]
  public class OSearch
  {
    /// <summary>
    /// Flag to indicate if the filtering should be case insensitive or not
    /// </summary>
    public bool? bCaseInsensitive;

    /// <summary>
    /// Flag to indicate if the search term should be interpreted as a regular 
    /// expression (true) or not (false) and therefore and special regex characters escaped
    /// </summary>
    public bool? bRegex;

    /// <summary>
    /// Flag to indicate if DataTables is to use its smart filtering or not.
    /// </summary>
    public bool? bSmart;

    /// <summary>
    /// Applied search term
    /// </summary>
    public string sSearch;
  }
}
