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
using System.Collections.Generic;
using System.Linq;

namespace MMM.Library.WebExtras.JQDataTables
{
  /// <summary>
  /// jQuery Datatable object
  /// </summary>
  [Serializable]
  public class Datatable
  {
    /// <summary>
    /// HTML field ID for the Datatable
    /// </summary>
    public string TableID { get; private set; }

    /// <summary>
    /// Datatable settings
    /// </summary>
    public DatatableSettings TableSettings { get; private set; }

    /// <summary>
    /// Datatable column headings
    /// </summary>
    public DatatableColumn[] Columns { get; private set; }

    /// <summary>
    /// Datatable records
    /// </summary>
    public DatatableRecords TableData { get; private set; }

    /// <summary>
    /// Postback data for server side processing
    /// </summary>
    public PostbackItem[] ServerPostbackData { get; private set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="tableId">HTML field ID for the Datatable</param>
    /// <param name="tableSettings">Datatable settings</param>
    /// <param name="columns">Datatable column specifications</param>
    /// <param name="tableData">Datatable records</param>
    /// <param name="serverData">[Optional] Postback data for server side processing</param>
    public Datatable(string tableId, DatatableSettings tableSettings, IEnumerable<DatatableColumn> columns, DatatableRecords tableData, IEnumerable<PostbackItem> serverData = null)
    {
      TableID = tableId;

      if (tableSettings.aoColumns == null)
        tableSettings.SetupAOColumns(columns);

      TableSettings = tableSettings;
      Columns = columns.ToArray();
      TableData = tableData;
      ServerPostbackData = (serverData != null) ? serverData.ToArray() : new PostbackItem[0];
    }
  }
}