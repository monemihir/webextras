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
  /// Datatables callback variables
  /// </summary>
  [Serializable]
  public class DatatableFilters
  {
    /// <summary>
    /// Request sequence number sent by DataTable,
    /// same value must be returned in response
    /// </summary>
    public string sEcho { get; set; }

    /// <summary>
    /// Text used for filtering
    /// </summary>
    public string sSearch { get; set; }

    /// <summary>
    /// Number of records that should be shown in table
    /// </summary>
    public int iDisplayLength { get; set; }

    /// <summary>
    /// First record that should be shown(used for paging)
    /// </summary>
    public int iDisplayStart { get; set; }

    /// <summary>
    /// Number of columns in table
    /// </summary>
    public int iColumns { get; set; }

    /// <summary>
    /// Number of columns that are used in sorting
    /// </summary>
    public int iSortingCols { get; set; }

    /// <summary>
    /// First sort column numeric index, possible to have
    /// _1,_2 etc for multi column sorting
    /// </summary>
    public int iSortCol_0 { get; set; }

    /// <summary>
    /// Sort direction of the first sorted column, asc or desc
    /// </summary>
    public string sSortDir_0 { get; set; }

    /// <summary>
    /// Comma separated list of column names
    /// </summary>
    public string sColumns { get; set; }

    /// <summary>
    /// Sort direction decided on the sSortDir_0 property
    /// </summary>
    public ESort SortDirection { get { return sSortDir_0 == "asc" ? ESort.Ascending : ESort.Descending; } }

    /// <summary>
    /// Constructor
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