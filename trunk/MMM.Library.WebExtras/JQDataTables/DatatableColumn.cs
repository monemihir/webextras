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

namespace MMM.Library.WebExtras.JQDataTables
{
  /// <summary>
  /// Datatable column headings
  /// </summary>
  [Serializable]
  public class DatatableColumn
  {
    /// <summary>
    /// Text heading for the column
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// HTML field ID for the column
    /// </summary>
    public string HtmlFieldId { get; private set; }

    /// <summary>
    /// Flag indicating whether this column is sortable
    /// </summary>
    public bool Sortable { get; set; }

    /// <summary>
    /// Css class for this column
    /// </summary>
    public string CssClass { get; set; }

    /// <summary>
    /// Column width in percent
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// Flag indicating whether this column is visible
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="name">Text heading for the column</param>
    /// 
    /// <param name="cssClass">[Optional] CSS class for the cells of this column. Defaults to null</param>
    /// <param name="width">[Optional] Column width in percent. Defaults to null</param>
    /// <param name="visible">[Optional] Flag indicating whether this column is visible. Defaults to true</param>
    public DatatableColumn(string name, string cssClass = null, int? width = null, bool visible = true)
    {
      Name = name;
      HtmlFieldId = name.ToLower() + "_Id";
      Width = width;
      Visible = visible;
      CssClass = cssClass;
    }
  }
}