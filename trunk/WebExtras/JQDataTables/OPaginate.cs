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
  /// Language pagination options
  /// </summary>
  [Serializable]
  public class OPaginate
  {
    /// <summary>
    /// Text to use when using the 'full_numbers' type of pagination for the button to take the user to the first page
    /// </summary>
    public string sFirst;

    /// <summary>
    /// Text to use when using the 'full_numbers' type of pagination for the button to take the user to the last page
    /// </summary>
    public string sLast;

    /// <summary>
    /// Text to use for the 'next' pagination button (to take the user to the next page)
    /// </summary>
    public string sNext;

    /// <summary>
    /// Text to use for the 'previous' pagination button (to take the user to the previous page)
    /// </summary>
    public string sPrevious;
  }
}
