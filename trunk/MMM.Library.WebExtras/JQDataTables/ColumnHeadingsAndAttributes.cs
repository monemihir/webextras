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
  /// Datatable column headings and data column attributes
  /// </summary>
  [Serializable]
  [Obsolete("Use DatatableColumn instead")]
  public class ColumnHeadingsAndAttributes
  {
    /// <summary>
    /// Column Headings
    /// </summary>
    public IEnumerable<DatatableColumn> ColumnHeadings { get; private set; }

    /// <summary>
    /// Column attributes
    /// </summary>
    public IEnumerable<DatatableSettings.AOColumn> ColumnAttributes { get; private set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="columnHeadings">A list of column headings (names) (THEAD tags)</param>
    /// <param name="columnAttributes">A list of data column attributes (TBODY tags)</param>
    public ColumnHeadingsAndAttributes(IEnumerable<DatatableColumn> columnHeadings, IEnumerable<DatatableSettings.AOColumn> columnAttributes)
    {
      this.ColumnHeadings = columnHeadings;
      this.ColumnAttributes = columnAttributes;

      if (columnAttributes.Count() != columnHeadings.Count())
        throw new Exception(
          string.Format("MMM.Library.WebExtras.JQDataTables.ColumnNamesAndAttributes.Ctor: The number of headings ({0}) and attributes ({1}) don't match.",
          columnHeadings.Count(),
          columnAttributes.Count()));
    }
  }
}