/*
* This file is part of - Code Library
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

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Language init options
  /// </summary>
  [Serializable]
  public class OLanguage
  {
    /// <summary>
    /// This string gives information to the end user about the information that is current on
    /// display on the page. The _START_, _END_ and _TOTAL_ variables are all dynamically
    /// replaced as the table display updates, and can be freely moved or removed as the
    /// language requirements change
    /// </summary>
    public string sInfo;

    /// <summary>
    /// Display information string for when the table is empty. Typically the format of this
    /// string should match sInfo
    /// </summary>
    public string sInfoEmpty;
  }
}