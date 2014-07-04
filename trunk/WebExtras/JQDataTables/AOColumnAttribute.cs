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
using WebExtras.Core;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// AOColumn attribute
  /// </summary>
  [Serializable]
  [AttributeUsage(AttributeTargets.Property)]
  public class AOColumnAttribute : Attribute
  {
    private Type m_valueFormatter;

    /// <summary>
    /// The index of this column in the rendered table
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Value formatter type
    /// </summary>
    public Type ValueFormatter
    {
      get { return m_valueFormatter; }
      set
      {
        if (value.BaseType != typeof(DefaultValueFormatter))
          throw new TypeLoadException(string.Format("'{0}' must inherit from WebExtras.Core.ValueFormatter", value.FullName));

        m_valueFormatter = value;
      }
    }

    /// <summary>
    /// Enable or disable filtering on the data in this column
    /// </summary>
    public bool bSearchable { get; set; }

    /// <summary>
    /// Enable or Disable sorting based on this column
    /// </summary>
    public bool bSortable { get; set; }

    /// <summary>
    /// The title of the column
    /// </summary>
    public string sTitle { get; set; }
    
    /// <summary>
    /// CSS class to be applied to each column
    /// </summary>
    public string sClass { get; set; }

    /// <summary>
    /// The type allows you to specify how the data for this column will be sorted. 
    /// Four types (string, numeric, date and html (which will strip HTML tags before 
    /// sorting)) are currently available. Note that only date formats understood by 
    /// Javascript's Date() object will be accepted as type date. 
    /// For example: "Mar 26, 2008 5:03 PM"
    /// </summary>
    public EAOColumn sType { get; set; }

    /// <summary>
    /// Defining the width of the column, this parameter may take any CSS value 
    /// (3em, 20px etc). DataTables applies 'smart' widths to columns which have 
    /// not been given a specific width through this interface ensuring that the 
    /// table remains readable
    /// </summary>
    public string sWidth { get; set; }
  }
}
