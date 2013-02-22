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
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace MMM.Library.WebExtras.JQDataTables
{
  /// <summary>
  /// jQuery Datatable settings
  /// </summary>
  [Serializable]
  public class DatatableSettings
  {
    /// <summary>
    /// Language init options
    /// </summary>
    [Serializable]
    public class OLanguage
    {
      /// <summary>
      /// This string gives information to the end user about the information that is current on 
      /// display on the page. The _START_, _END_ and _TOTAL_ variables are all dynamically 
      /// replaced as the table display updates, and can be freely moved or removed as the 
      /// language requirements change
      /// </summary>
      public string sInfo;

      /// <summary>
      /// Display information string for when the table is empty. Typically the format of this 
      /// string should match sInfo
      /// </summary>
      public string sInfoEmpty;
    }

    /// <summary>
    /// Specification for a Datatables data column
    /// </summary>
    [Serializable]
    public class AOColumn
    {
      /// <summary>
      /// Enable / Disable sorting based on this column
      /// </summary>
      public bool bSortable;

      /// <summary>
      /// CSS class for the cells of this column
      /// </summary>
      [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
      public string sClass;

      /// <summary>
      /// The width of the column, this parameter may take any CSS value (3em, 20px etc)
      /// </summary>
      [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
      public string sWidth;

      /// <summary>
      /// Flag indicating whether the column is visible
      /// </summary>
      public bool bVisible;

      /// <summary>
      /// Default constructor
      /// </summary>
      public AOColumn()
      {
        bVisible = true;
      }
    }

    /// <summary>
    /// Specification for the column sorts
    /// </summary>
    [Serializable]
    public class AASort
    {
      /// <summary>
      /// Column number. This is zero indexed i.e the column numbers start from 0
      /// </summary>
      public int columnNumber;

      /// <summary>
      /// Type of sort. Only valid values are "asc" and "desc"
      /// </summary>
      public string sortType;
    }

    /// <summary>
    /// Enable / Disable server side processing. The AJAX source (sAjaxSource) must also be specified
    /// </summary>
    public bool bServerSide;

    /// <summary>
    /// Enable or disable filtering of data
    /// </summary>
    public bool bFilter;

    /// <summary>
    /// Allows the end user to select the size of a formatted page from a select menu 
    /// (sizes are 10, 25, 50 and 100). Requires pagination (bPaginate)
    /// </summary>
    public bool bLengthChange;

    /// <summary>
    /// DataTables features two different built-in pagination interaction methods 
    /// ('two_button' or 'full_numbers') which present different page controls to the end user.
    /// </summary>
    public string sPaginationType;

    /// <summary>
    /// Enable or disable pagination
    /// </summary>
    public bool bPaginate;

    /// <summary>
    /// Enable jQuery UI ThemeRoller support
    /// </summary>
    public bool bJQueryUI;

    /// <summary>
    /// Number of rows to display on a single page when using pagination. If feature enabled 
    /// (bLengthChange) then the end user will be able to over-ride this to a custom setting 
    /// using a pop-up menu
    /// </summary>
    public int iDisplayLength;

    /// <summary>
    /// Enable vertical scrolling. Vertical scrolling will constrain the DataTable to 
    /// the given height (in pixels), an enable scrolling for any data which overflows the current 
    /// viewport.
    /// </summary>
    public string sScrollY;

    /// <summary>
    /// Enable / Disable showing of the "Processing..." status when updating the table
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? bProcessing;

    /// <summary>
    /// If sorting is enabled, then DataTables will perform a first pass sort on initialisation. 
    /// You can define which column(s) the sort is performed upon, and the sorting direction, with 
    /// this variable. The aaSorting array should contain an array for each column to be sorted 
    /// initially containing the column's index and a direction string ('asc' or 'desc')
    /// </summary>
    public object[][] aaSorting;

    /// <summary>
    /// Individual data column specifications
    /// </summary>
    public IEnumerable<AOColumn> aoColumns;

    /// <summary>
    /// Language init options
    /// </summary>
    public OLanguage oLanguage;

    /// <summary>
    /// Url (absolute or relative) to retrieve server side data from. Requires server side processing
    /// to be enabled (bServerSide)
    /// </summary>
    public string sAjaxSource;

    /// <summary>
    /// Manually specify where in the DOM should DataTables inject various
    /// controls it adds
    /// </summary>
    public string sDom;

    /// <summary>
    /// Constructor to setup Datatable with default column widths. All columns will get equal width.
    /// </summary>
    /// <param name="displayLength">Number of rows to display on a single page when using pagination</param>
    /// <param name="sortOptions">Column sort options. If this is null or empty list a default "asc" sort on 
    /// the first column will be applied</param>
    /// <param name="ajaxSource">AJAX source URL</param>
    /// <param name="footerSuffix">[Optional] This string gives information to the end user about the information 
    /// that is current on display on the page</param>
    /// <param name="tableHeight">[Optional] Height of the table in pixels. Defaults to 200px</param>
    public DatatableSettings(int displayLength, IEnumerable<AASort> sortOptions, string ajaxSource, string footerSuffix = "", string tableHeight = "200px")
    {
      bPaginate = true;
      bFilter = bLengthChange = false;
      sPaginationType = "full_numbers";
      iDisplayLength = displayLength;
      sScrollY = tableHeight;

      foreach (AASort s in sortOptions)
      {
        if (s.sortType.ToLower() != "asc" && s.sortType.ToLower() != "desc")
          throw new Exception("Sort type can only be either \"asc\" or \"desc\"");
      }

      aaSorting =
        (sortOptions != null && sortOptions.Count() > 0) ?
        sortOptions.Select(o => new object[2] { o.columnNumber, o.sortType }).ToArray() :
        (new List<object[]> { new object[2] { 0, "asc" } }).ToArray();

      oLanguage = new OLanguage
      {
        sInfo = "Showing _START_ to _END_ of _TOTAL_ " + footerSuffix,
        sInfoEmpty = "No records"
      };
      sAjaxSource = ajaxSource;
    }

    /// <summary>
    /// Setup the jQuery dataTables aoColumns variable from the given
    /// set of columns
    /// </summary>
    /// <param name="columns">Datatable columns</param>
    public void SetupAOColumns(IEnumerable<DatatableColumn> columns)
    {
      aoColumns = columns.Select(c => new AOColumn
      {
        bSortable = c.Sortable,
        sClass = c.CssClass,
        sWidth = c.Width.HasValue ? string.Format("{0}%", c.Width) : null,
        bVisible = c.Visible
      }).ToArray();
    }

    /// <summary>
    /// Returns a JSON serialized version of this object
    /// </summary>
    /// <returns>Returns a JSON serialized version of this object</returns>
    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}