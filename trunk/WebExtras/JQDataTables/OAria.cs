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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Language ARIA label options
  /// </summary>
  [Serializable]
  public class OAria
  {
    /// <summary>
    /// ARIA label that is added to the table headers when the column may be 
    /// sorted ascending by activing the column (click or return when focused). 
    /// Note that the column header is prefixed to this string
    /// </summary>
    public string sSortAscending;

    /// <summary>
    /// ARIA label that is added to the table headers when the column may be 
    /// sorted descending by activing the column (click or return when focused). 
    /// Note that the column header is prefixed to this string
    /// </summary>
    public string sSortDescending;
  }
}
