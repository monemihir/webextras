﻿/*
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

using System;
using WebExtras.Core;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Pagination type
  /// </summary>
  [Serializable]
  public enum EPagination
  {
    /// <summary>
    /// No paging
    /// </summary>
    None,

    /// <summary>
    /// This plug-in provides the mark-up needed for using Twitter Bootstrap's pagination 
    /// styling with DataTables. Note that this plug-in uses the fnPagingInfo API plug-in 
    /// method to obtain paging information.
    /// </summary>
    [StringValue("bootstrap")]
    Bootstrap,

    /// <summary>
    /// Bootstrap 3 styled normal paging
    /// </summary>
    [StringValue("bs_normal")]
    Bootstrap3,

    /// <summary>
    /// Bootstrap 3 styled 2 button paging
    /// </summary>
    [StringValue("bs_two_button")]
    Bootstrap3_Two_Button,

    /// <summary>
    /// Bootstrap 3 styled 4 button paging
    /// </summary>
    [StringValue("bs_four_button")]
    Bootstrap3_Four_Button,

    /// <summary>
    /// Bootstrap 3 styled full numbers paging
    /// </summary>
    Bootstrap3_Full_Numbers,

    /// <summary>
    /// The built-in pagination functions provide either two buttons (forward / back) 
    /// or lots of buttons (forward, back, first, last and individual pages). This 
    /// plug-in meets the two in the middle providing navigation controls for forward, 
    /// back, first and last.
    /// </summary>
    [StringValue("four_button")]
    FourButton,

    /// <summary>
    /// Full numeric pagination
    /// </summary>
    [StringValue("full_numbers")]
    FullNumbers,

    /// <summary>
    /// This modification of DataTables' standard two button pagination controls adds a 
    /// little animation effect to the paging action by redrawing the table multiple times 
    /// for each event, each draw progressing by one row until the required point in the 
    /// table is reached.
    /// </summary>
    [StringValue("scrolling")]
    Scrolling,

    /// <summary>
    /// Two button pagination
    /// </summary>
    [StringValue("two_button")]
    TwoButton,

    /// <summary>
    /// Gumby pagination
    /// </summary>
    [StringValue("full_numbers")]
    Gumby
  }
}
