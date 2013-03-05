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

namespace WebExtras.JQDataTables
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
    public string ID { get; private set; }

    /// <summary>
    /// Datatable settings
    /// </summary>
    public DatatableSettings Settings { get; private set; }

    /// <summary>
    /// Datatable column headings
    /// </summary>
    public IEnumerable<DatatableColumn> Columns { get; private set; }

    /// <summary>
    /// Datatable records
    /// </summary>
    public DatatableRecords Records { get; private set; }

    /// <summary>
    /// Postback data for server side processing
    /// </summary>
    public IEnumerable<PostbackItem> Postbacks { get; private set; }

    /// <summary>
    /// Flag indicating whether to enable status column
    /// </summary>
    public bool EnableStatusColumn { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="settings">Datatable settings</param>
    /// <param name="columns">Datatable column specifications</param>
    /// <param name="records">Datatable records</param>
    /// <param name="postbacks">[Optional] Postback data for server side processing</param>
    /// <param name="enableStatusColumn">[Optional] flag indicating whether to enable status column. Defaults to false</param>
    public Datatable(DatatableSettings settings, IEnumerable<DatatableColumn> columns, DatatableRecords records, IEnumerable<PostbackItem> postbacks = null, bool enableStatusColumn = false) :
      this(string.Format("autogen-{0}", Guid.NewGuid().ToString()), settings, columns, records, postbacks, enableStatusColumn) { }

    /// <summary>
    /// Constructor to initialize with an HTML field ID
    /// </summary>
    /// <param name="id">HTML field ID for the Datatable</param>
    /// <param name="settings">Datatable settings</param>
    /// <param name="columns">Datatable column specifications</param>
    /// <param name="records">Datatable records</param>
    /// <param name="postbacks">[Optional] Postback data for server side processing</param>
    /// <param name="enableStatusColumn">[Optional] flag indicating whether to enable status column. Defaults to false</param>
    public Datatable(string id, DatatableSettings settings, IEnumerable<DatatableColumn> columns, DatatableRecords records, IEnumerable<PostbackItem> postbacks = null, bool enableStatusColumn = false)
    {
      ID = id.Replace("-", "_");
      Settings = settings;
      Columns = columns;

      // setup the status column if the flag is set
      if (enableStatusColumn)
        Columns = Columns.Concat(new DatatableColumn[] { new DatatableColumn("", visible: false, bSortable: false) });

      // if the aoColumns were not setup then do a default setup
      if (settings.aoColumns == null)
        settings.SetupAOColumns(Columns);

      Records = records;
      Postbacks = postbacks ?? Enumerable.Empty<PostbackItem>();
      EnableStatusColumn = enableStatusColumn;
    }
  }
}