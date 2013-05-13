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
using Newtonsoft.Json;

namespace WebExtras.JQDataTables
{
  /// <summary>
  /// Specification for a Datatables data column
  /// </summary>
  [Serializable]
  public class AOColumn
  {
    /// <summary>
    /// Allows a column's sorting to take multiple columns into account when doing a 
    /// sort. For example first name / last name columns make sense to do a multi-column 
    /// sort over the two columns.
    /// </summary>
    public int[] aDataSort;

    /// <summary>
    /// You can control the default sorting direction, and even alter the behaviour of 
    /// the sort handler (i.e. only allow ascending sorting etc) using this parameter
    /// </summary>
    public string[] asSorting;

    /// <summary>
    /// Enable or disable filtering on the data in this column
    /// </summary>
    public bool? bSearchable;

    /// <summary>
    /// Enable / Disable sorting based on this column
    /// </summary>
    public bool? bSortable;

    /// <summary>
    /// Flag indicating whether the column is visible
    /// </summary>
    public bool? bVisible;

    /// <summary>
    /// The column index (starting from 0!) that you wish a sort to be performed 
    /// upon when this column is selected for sorting. This can be used for sorting 
    /// on hidden columns for example
    /// </summary>
    public int? iDataSort;

    /// <summary>
    /// Change the cell type created for the column - either TD cells or TH cells. 
    /// This can be useful as TH cells have semantic meaning in the table body, 
    /// allowing them to act as a header for a row (you may wish to add scope='row' 
    /// to the TH elements)
    /// </summary>
    public string sCellType;

    /// <summary>
    /// CSS Class to give to each cell in this column
    /// </summary>
    public string sClass;

    /// <summary>
    /// When DataTables calculates the column widths to assign to each column, it 
    /// finds the longest string in each column and then constructs a temporary 
    /// table and reads the widths from that. The problem with this is that "mmm" 
    /// is much wider then "iiii", but the latter is a longer string - thus the 
    /// calculation can go wrong (doing it properly and putting it into an DOM 
    /// object and measuring that is horribly(!) slow). Thus as a "work around" 
    /// we provide this option. It will append its value to the text that is found 
    /// to be the longest string for the column - i.e. padding. Generally you 
    /// shouldn't need this, and it is not documented on the general 
    /// DataTables.net documentation
    /// </summary>
    public string sContentPadding;

    /// <summary>
    /// Allows a default value to be given for a column's data, and will be used 
    /// whenever a null data source is encountered (this can be because mData 
    /// is set to null, or because the data source itself is null)
    /// </summary>
    public string sDefaultContent;

    /// <summary>
    /// This parameter is only used in DataTables' server-side processing. It can 
    /// be exceptionally useful to know what columns are being displayed on the 
    /// client side, and to map these to database fields. When defined, the names 
    /// also allow DataTables to reorder information from the server if it comes 
    /// back in an unexpected order (i.e. if you switch your columns around on 
    /// the client-side, your server-side code does not also need updating)
    /// </summary>
    public string sName;

    /// <summary>
    /// Defines a data source type for the sorting which can be used to read 
    /// real-time information from the table (updating the internally cached version) 
    /// prior to sorting. This allows sorting to occur on user editable elements 
    /// such as form inputs
    /// </summary>
    public string sSortDataType;

    /// <summary>
    /// The title of the column
    /// </summary>
    public string sTitle;

    /// <summary>
    /// The type allows you to specify how the data for this column will be sorted. 
    /// Four types (string, numeric, date and html (which will strip HTML tags before 
    /// sorting)) are currently available. Note that only date formats understood by 
    /// Javascript's Date() object will be accepted as type date. 
    /// For example: "Mar 26, 2008 5:03 PM"
    /// </summary>
    [JsonConverter(typeof(EAOColumnTypeJsonConverter))]
    public EAOColumnType? sType;

    /// <summary>
    /// Defining the width of the column, this parameter may take any CSS value 
    /// (3em, 20px etc). DataTables applies 'smart' widths to columns which have 
    /// not been given a specific width through this interface ensuring that the 
    /// table remains readable
    /// </summary>
    public string sWidth;

    /// <summary>
    /// Default constructor
    /// </summary>
    public AOColumn() { bSortable = false; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="title">Column title/header</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public AOColumn(string title)
      : this()
    {
      if (string.IsNullOrEmpty(title))
        throw new ArgumentNullException("title");
      else
        sTitle = title;
    }
  }
}