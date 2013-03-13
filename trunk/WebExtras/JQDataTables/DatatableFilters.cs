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

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Datatables callback variables
  /// </summary>
  [Serializable]
  public class DatatableFilters
  {
    /// Request sequence number sent by DataTable,
    /// same value must be returned in response
    public string sEcho { get; set; }

    /// Text used for filtering
    public string sSearch { get; set; }

    /// Number of records that should be shown in table
    public int iDisplayLength { get; set; }

    /// First record that should be shown(used for paging)
    public int iDisplayStart { get; set; }

    /// Number of columns in table
    public int iColumns { get; set; }

    /// Number of columns that are used in sorting
    public int iSortingCols { get; set; }

    /// First sort column numeric index, possible to have
    /// _1,_2 etc for multi column sorting
    public int iSortCol_0 { get; set; }

    /// Sort direction of the first sorted column, asc or desc
    public string sSortDir_0 { get; set; }

    /// Comma separated list of column names
    public string sColumns { get; set; }

    /// <summary>
    /// Sort direction decided on the sSortDir_0 property
    /// </summary>
    public SortType SortDirection { get { return sSortDir_0 == "asc" ? SortType.Ascending : SortType.Descending; } }

    /// <summary>
    /// Default constructor
    /// </summary>
    public DatatableFilters()
    {
      sEcho = "1";
      iDisplayStart = 0;
      iDisplayLength = 0;
      sSortDir_0 = "asc";
      iSortCol_0 = 0;
    }
  }
}