﻿// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using WebExtras.Core;
using WebExtras.JQDataTables.Plugins;

namespace WebExtras.JQDataTables
{
  /// <summary>
  ///   jQuery Datatable settings
  /// </summary>
  [Serializable]
  public class DatatableSettings
  {
    #region Default settings

    /// <summary>
    ///   Enable or disable automatic column width calculation. This can be disabled as an optimisation
    ///   (it takes some time to calculate the widths) if the tables widths are passed in using aoColumns.
    /// </summary>
    public bool? bAutoWidth;

    /// <summary>
    ///   Deferred rendering can provide DataTables with a huge speed boost when you are using an Ajax or
    ///   JS data source for the table. This option, when set to true, will cause DataTables to defer the
    ///   creation of the table elements for each row until they are needed for a draw - saving a
    ///   significant amount of time.
    /// </summary>
    public bool? bDeferRender;

    /// <summary>
    ///   Enable or disable filtering of data. Filtering in DataTables is "smart" in that it allows the
    ///   end user to input multiple words (space separated) and will match a row containing those words,
    ///   even if not in the order that was specified (this allow matching across multiple columns). Note
    ///   that if you wish to use filtering in DataTables this must remain 'true' - to remove the default
    ///   filtering input box and retain filtering abilities, please use {@link DataTable.defaults.sDom}.
    /// </summary>
    public bool? bFilter;

    /// <summary>
    ///   Enable or disable the table information display. This shows information about the data that is
    ///   currently visible on the page, including information about filtered data if that action is being
    ///   performed.
    /// </summary>
    public bool? bInfo;

    /// <summary>
    ///   Enable jQuery UI ThemeRoller support (required as ThemeRoller requires some slightly
    ///   different and additional mark-up from what DataTables has traditionally used).
    /// </summary>
    public bool? bJQueryUI;

    /// <summary>
    ///   Allows the end user to select the size of a formatted page from a select menu
    ///   (sizes are 10, 25, 50 and 100). Requires pagination (bPaginate)
    /// </summary>
    public bool bLengthChange;

    /// <summary>
    ///   Enable or disable pagination
    /// </summary>
    public bool bPaginate;

    ///// <summary>
    ///// Enable or disable the display of a 'processing' indicator when the table is being processed 
    ///// (e.g. a sort). This is particularly useful for tables with large amounts of data where it 
    ///// can take a noticeable amount of time to sort the entries.
    ///// </summary>    
    //public bool? bProcessing;   // Todo: For some reason this does not work :(

    /// <summary>
    ///   Configure DataTables to use server-side processing. Note that the sAjaxSource parameter must
    ///   also be given in order to give DataTables a source to obtain the required data for each draw.
    /// </summary>
    public bool bServerSide;

    /// <summary>
    ///   Enable or disable sorting of columns. Sorting of individual columns can be disabled by the
    ///   "bSortable" option for each column.
    /// </summary>
    public bool? bSort;

    /// <summary>
    ///   Enable or disable the addition of the classes 'sorting_1', 'sorting_2' and 'sorting_3' to
    ///   the columns which are currently being sorted on. This is presented as a feature switch as
    ///   it can increase processing time (while classes are removed and added) so for large data sets
    ///   you might want to turn this off.
    /// </summary>
    public bool? bSortClasses;

    /// <summary>
    ///   Enable or disable state saving. When enabled a cookie will be used to save table display
    ///   information such as pagination information, display length, filtering and sorting. As such
    ///   when the end user reloads the page the display display will match what thy had previously set up.
    /// </summary>
    public bool? bStateSave;

    /// <summary>
    ///   Enable horizontal scrolling. When a table is too wide to fit into a certain layout, or you have
    ///   a large number of columns in the table, you can enable x-scrolling to show the table in a
    ///   viewport, which can be scrolled. This property can be any CSS unit, or a number (in which case
    ///   it will be treated as a pixel measurement).
    /// </summary>
    public string sScrollX;

    /// <summary>
    ///   Enable vertical scrolling. Vertical scrolling will constrain the DataTable to the
    ///   given height, and enable scrolling for any data which overflows the current viewport.
    ///   This can be used as an alternative to paging to display a lot of data in a small area
    ///   (although paging and scrolling can both be enabled at the same time). This property
    ///   can be any CSS unit, or a number (in which case it will be treated as a pixel
    ///   measurement).
    /// </summary>
    public string sScrollY;

    #endregion Default settings

    #region Some extra settings

    /// <summary>
    ///   If sorting is enabled, then DataTables will perform a first pass sort on initialisation.
    ///   You can define which column(s) the sort is performed upon, and the sorting direction, with
    ///   this variable. The aaSorting array should contain an array for each column to be sorted
    ///   initially containing the column's index and a direction string ('asc' or 'desc')
    /// </summary>
    public object[][] aaSorting { get; private set; }

    /// <summary>
    ///   Individual data column specifications
    /// </summary>
    public AOColumn[] aoColumns;

    /// <summary>
    ///   Language init options
    /// </summary>
    public OLanguage oLanguage;

    /// <summary>
    ///   Replace a DataTable which matches the given selector and replace it with one which has the
    ///   properties of the new initialisation object passed. If no table matches the selector, then
    ///   the new DataTable will be constructed as per normal.
    /// </summary>
    public bool? bDestroy;

    /// <summary>
    ///   Retrieve the DataTables object for the given selector. Note that if the table has already
    ///   been initialised, this parameter will cause DataTables to simply return the object that
    ///   has already been set up - it will not take account of any changes you might have made to
    ///   the initialisation object passed to DataTables (setting this parameter to true is an
    ///   acknowledgement that you understand this). bDestroy can be used to reinitialise a table
    ///   if you need.
    /// </summary>
    public bool? bRetrieve;

    /// <summary>
    ///   Indicate if DataTables should be allowed to set the padding / margin etc for the scrolling
    ///   header elements or not. Typically you will want this.
    /// </summary>
    public bool? bScrollAutoCss;

    /// <summary>
    ///   When vertical (y) scrolling is enabled, DataTables will force the height of the table's
    ///   viewport to the given height at all times (useful for layout). However, this can look odd
    ///   when filtering data down to a small data set, and the footer is left "floating" further
    ///   down. This parameter (when enabled) will cause DataTables to collapse the table's viewport
    ///   down when the result set will fit within the given Y height.
    /// </summary>
    public bool? bScrollCollapse;

    /// <summary>
    ///   Allows control over whether DataTables should use the top (true) unique cell that is found
    ///   for a single column, or the bottom (false - default). This is useful when using complex headers.
    /// </summary>
    public bool? bSortCellsTop;

    /// <summary>
    ///   Duration of the cookie which is used for storing session information. This value is given in seconds.
    /// </summary>
    public int? iCookieDuration;

    /// <summary>
    ///   When enabled DataTables will not make a request to the server for the first page draw - rather
    ///   it will use the data already on the page (no sorting etc will be applied to it), thus saving on
    ///   an XHR at load time. iDeferLoading is used to indicate that deferred loading is required, but
    ///   it is also used to tell DataTables how many records there are in the full table (allowing the
    ///   information element and pagination to be displayed correctly). In the case where a filtering is
    ///   applied to the table on initial load, this can be indicated by giving the parameter as an array,
    ///   where the first element is the number of records available after filtering and the second element
    ///   is the number of records without filtering (allowing the table information element to be shown
    ///   correctly).
    /// </summary>
    public int? iDeferLoading;

    /// <summary>
    ///   Number of rows to display on a single page when using pagination. If feature enabled
    ///   (bLengthChange) then the end user will be able to over-ride this to a custom setting
    ///   using a pop-up menu
    /// </summary>
    public int iDisplayLength;

    /// <summary>
    ///   Define the starting point for data display when using DataTables with pagination. Note that this
    ///   parameter is the number of records, rather than the page number, so if you have 10 records per
    ///   page and want to start on the third page, it should be "20".
    /// </summary>
    public int? iDisplayStart;

    /// <summary>
    ///   The scroll gap is the amount of scrolling that is left to go before DataTables will load the
    ///   next 'page' of data automatically. You typically want a gap which is big enough that the
    ///   scrolling will be smooth for the user, while not so large that it will load more data than need.
    /// </summary>
    public int? iScrollLoadGap;

    /// <summary>
    ///   By default DataTables allows keyboard navigation of the table (sorting, paging, and filtering)
    ///   by adding a tabindex attribute to the required elements. This allows you to tab through the
    ///   controls and press the enter key to activate them. The tabindex is default 0, meaning that the
    ///   tab follows the flow of the document. You can overrule this using this parameter if you wish.
    ///   Use a value of -1 to disable built-in keyboard navigation.
    /// </summary>
    public int? iTabIndex;

    /// <summary>
    ///   This parameter allows you to have define the global filtering state at initialisation time.
    ///   As an object the "sSearch" parameter must be defined, but all other parameters are optional.
    ///   When "bRegex" is true, the search string will be treated as a regular expression, when false
    ///   (default) it will be treated as a straight string. When "bSmart" DataTables will use it's
    ///   smart filtering methods (to word match at any point in the data), when false this will not
    ///   be done.
    /// </summary>
    public OSearch oSearch;

    /// <summary>
    ///   By default DataTables will look for the property 'aaData' when obtaining data from an Ajax
    ///   source or for server-side processing - this parameter allows that property to be changed.
    ///   You can use Javascript dotted object notation to get a data source for multiple levels of
    ///   nesting.
    /// </summary>
    public string sAjaxDataProp;

    /// <summary>
    ///   You can instruct DataTables to load data from an external source using this parameter (use
    ///   aData if you want to pass data in you already have). Simply provide a url a JSON object can
    ///   be obtained from. This object must include the parameter 'aaData' which is the data source
    ///   for the table.
    /// </summary>
    public string sAjaxSource;

    /// <summary>
    ///   This parameter can be used to override the default prefix that DataTables assigns to a
    ///   cookie when state saving is enabled.
    /// </summary>
    public string sCookiePrefix;

    /// <summary>
    ///   This initialisation variable allows you to specify exactly where in the DOM you want
    ///   DataTables to inject the various controls it adds to the page (for example you might
    ///   want the pagination controls at the top of the table). DIV elements (with or without
    ///   a custom class) can also be added to aid styling.
    /// </summary>
    public string sDom;

    /// <summary>
    ///   DataTables features two different built-in pagination interaction methods
    ///   ('two_button' or 'full_numbers') which present different page controls to the end user.
    /// </summary>
    public string sPaginationType;

    /// <summary>
    ///   This property can be used to force a DataTable to use more width than it might otherwise
    ///   do when x-scrolling is enabled. For example if you have a table which requires to be well
    ///   spaced, this parameter is useful for "over-sizing" the table, and thus forcing scrolling.
    ///   This property can by any CSS unit, or a number (in which case it will be treated as a
    ///   pixel measurement).
    /// </summary>
    public string sScrollXInner;

    /// <summary>
    ///   Set the HTTP method that is used to make the Ajax call for server-side processing or
    ///   Ajax sourced data.
    /// </summary>
    [JsonConverter(typeof(EServerMethodJsonConverter))] public EServerMethod? sServerMethod;

    /// <summary>
    ///   This parameter allows you to readily specify the entries in the length dropdown menu that
    ///   DataTables shows when pagination is enabled. It can be either a 1D array of options which
    ///   will be used for both the displayed option and the value, or a 2D array which will use the
    ///   array in the first position as the value, and the array in the second position as the
    ///   displayed options (useful for language strings such as 'All')
    /// </summary>
    public object aLengthMenu;

    #endregion Some extra settings

    #region Properties

    /// <summary>
    ///   The current paging scheme
    /// </summary>
    [JsonIgnore]
    public EPagination Paging { get; private set; }

    /// <summary>
    ///   Settings for plugins
    /// </summary>
    [JsonIgnore]
    public virtual List<IDatatablePlugin<object>> Plugins { get; private set; }

    #endregion Properties

    #region Callbacks

    /// <summary>
    ///   Customise the cookie and / or the parameters being stored when using DataTables with state saving enabled.
    ///   This function is called whenever the cookie is modified, and it expects a fully formed cookie string to
    ///   be returned. Note that the data object passed in is a Javascript object which must be converted to a
    ///   string (JSON.stringify for example).
    /// </summary>
    public JsFunc fnCookieCallback;

    /// <summary>
    ///   This function is called when a TR element is created (and all TD child elements have been inserted), or \
    ///   registered if using a DOM source, allowing manipulation of the TR element (adding classes etc)
    /// </summary>
    public JsFunc fnCreatedRow;

    /// <summary>
    ///   This function is called on every 'draw' event, and allows you to dynamically modify any aspect you want
    ///   about the created DOM.
    /// </summary>
    public JsFunc fnDrawCallback;

    /// <summary>
    ///   This function is called on every 'draw' event, and allows you to dynamically modify the header row. This
    ///   can be used to calculate and display useful information about the table.
    /// </summary>
    public JsFunc fnHeaderCallback;

    /// <summary>
    ///   Identical to fnHeaderCallback() but for the table footer this function allows you to modify the table
    ///   footer on every 'draw' even.
    /// </summary>
    public JsFunc fnFooterCallback;

    /// <summary>
    ///   When rendering large numbers in the information element for the table (i.e. "Showing 1 to 10 of 57
    ///   entries") DataTables will render large numbers to have a comma separator for the 'thousands' units
    ///   (e.g. 1 million is rendered as "1,000,000") to help readability for the end user. This function will
    ///   override the default method DataTables uses.
    /// </summary>
    public JsFunc fnFormatNumber;

    /// <summary>
    ///   The information element can be used to convey information about the current state of the table.
    ///   Although the internationalisation options presented by DataTables are quite capable of dealing with
    ///   most customisations, there may be times where you wish to customise the string further. This
    ///   callback allows you to do exactly that.
    /// </summary>
    public JsFunc fnInfoCallback;

    /// <summary>
    ///   Called when the table has been initialised. Normally DataTables will initialise sequentially and
    ///   there will be no need for this function, however, this does not hold true when using external
    ///   language information since that is obtained using an async XHR call.
    /// </summary>
    public JsFunc fnInitComplete;

    /// <summary>
    ///   Called at the very start of each table draw and can be used to cancel the draw by returning false,
    ///   any other return (including undefined) results in the full draw occurring).
    /// </summary>
    public JsFunc fnPreDrawCallback;

    /// <summary>
    ///   This function allows you to 'post process' each row after it have been generated for each table
    ///   draw, but before it is rendered on screen. This function might be used for setting the row class name etc.
    /// </summary>
    public JsFunc fnRowCallback;

    /// <summary>
    ///   This parameter allows you to override the default function which obtains the data from the server
    ///   ($.getJSON) so something more suitable for your application. For example you could use POST data,
    ///   or pull information from a Gears or AIR database.
    /// </summary>
    public JsFunc fnServerData;

    /// <summary>
    ///   It is often useful to send extra data to the server when making an Ajax request - for example custom
    ///   filtering information, and this callback function makes it trivial to send extra information to the server.
    ///   The passed in parameter is the data set that has been constructed by DataTables, and you can add to this
    ///   or modify it as you require.
    /// </summary>
    public JsFunc fnServerParams;

    /// <summary>
    ///   Load the table state. With this function you can define from where, and how, the state of a table is loaded.
    ///   By default DataTables will load from its state saving cookie, but you might wish to use local storage (HTML5)
    ///   or a server-side database.
    /// </summary>
    public JsFunc fnStateLoad;

    /// <summary>
    ///   Callback which allows modification of the saved state prior to loading that state. This callback is called
    ///   when the table is loading state from the stored data, but prior to the settings object being modified by the
    ///   saved state. Note that for plug-in authors, you should use the 'stateLoadParams' event to load parameters for
    ///   a plug-in.
    /// </summary>
    public JsFunc fnStateLoadParams;

    /// <summary>
    ///   Callback that is called when the state has been loaded from the state saving method and the DataTables
    ///   settings object has been modified as a result of the loaded state.
    /// </summary>
    public JsFunc fnStateLoaded;

    /// <summary>
    ///   Save the table state. This function allows you to define where and how the state information for the
    ///   table is stored - by default it will use a cookie, but you might want to use local storage (HTML5) or a
    ///   server-side database.
    /// </summary>
    public JsFunc fnStateSave;

    /// <summary>
    ///   Callback which allows modification of the state to be saved. Called when the table has changed state a
    ///   new state save is required. This method allows modification of the state saving object prior to actually
    ///   doing the save, including addition or other state properties or modification. Note that for plug-in authors,
    ///   you should use the 'stateSaveParams' event to save parameters for a plug-in.
    /// </summary>
    public JsFunc fnStateSaveParams;

    #endregion Callbacks

    #region Ctors

    /// <summary>
    ///   Default constructor
    /// </summary>
    public DatatableSettings()
    {
      Init();
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="displayLength">Number of rows to display on a single page when using pagination</param>
    /// <param name="sortOption">Column sort option. If this is null no sorting will be applied</param>
    /// <param name="ajaxSource">AJAX source URL</param>
    /// <param name="footerSuffix">
    ///   [Optional] This string gives information to the end user about the information
    ///   that is current on display on the page
    /// </param>
    /// <param name="tableHeight">
    ///   [Optional] Height of the table in pixels. Defaults to 200px. Note. Pass in a null if to do not
    ///   want any table height set
    /// </param>
    public DatatableSettings(int displayLength, AASort sortOption, string ajaxSource, string footerSuffix = "",
      string tableHeight = "200px")
      : this(displayLength, (sortOption == null ? null : new[] {sortOption}), ajaxSource, footerSuffix, tableHeight)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="displayLength">Number of rows to display on a single page when using pagination</param>
    /// <param name="sortOptions">Column sort options. If this is null no sorting will be applied</param>
    /// <param name="ajaxSource">AJAX source URL</param>
    /// <param name="footerSuffix">
    ///   [Optional] This string gives information to the end user about the information
    ///   that is current on display on the page
    /// </param>
    /// <param name="tableHeight">
    ///   [Optional] Height of the table in pixels. Defaults to 200px. Note. Pass in a null if to do not
    ///   want any table height set
    /// </param>
    public DatatableSettings(int displayLength, IEnumerable<AASort> sortOptions, string ajaxSource,
      string footerSuffix = "", string tableHeight = "200px")
    {
      Init();
      bFilter = bLengthChange = false;
      iDisplayLength = displayLength;
      sScrollY = tableHeight;

      SetupAASort(sortOptions);

      oLanguage = new OLanguage
      {
        sInfo = "Showing _START_ to _END_ of _TOTAL_ " + footerSuffix,
        sInfoEmpty = "No records"
      };
      sAjaxSource = ajaxSource;
      bServerSide = !string.IsNullOrEmpty(ajaxSource);

      SetupPaging(WebExtrasSettings.DatatablesPaginationScheme);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="displayLength">Number of rows to display on a single page when using pagination</param>
    /// <param name="column">Column specifications</param>
    /// <param name="sortOption">Column sort option. If this is null no sorting will be applied</param>
    /// <param name="ajaxSource">AJAX source URL</param>
    /// <param name="footerSuffix">
    ///   [Optional] This string gives information to the end user about the information
    ///   that is current on display on the page
    /// </param>
    /// <param name="tableHeight">
    ///   [Optional] Height of the table in pixels. Defaults to 200px. Note. Pass in a null if to do not
    ///   want any table height set
    /// </param>
    public DatatableSettings(int displayLength, AOColumn column, AASort sortOption, string ajaxSource,
      string footerSuffix = "", string tableHeight = "200px")
      : this(
        displayLength, new[] {column}, (sortOption == null) ? null : new[] {sortOption}, ajaxSource, footerSuffix,
        tableHeight)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="displayLength">Number of rows to display on a single page when using pagination</param>
    /// <param name="columns">Column specifications</param>
    /// <param name="sortOption">Column sort option. If this is null no sorting will be applied</param>
    /// <param name="ajaxSource">AJAX source URL</param>
    /// <param name="footerSuffix">
    ///   [Optional] This string gives information to the end user about the information
    ///   that is current on display on the page
    /// </param>
    /// <param name="tableHeight">
    ///   [Optional] Height of the table in pixels. Defaults to 200px. Note. Pass in a null if to do not
    ///   want any table height set
    /// </param>
    public DatatableSettings(int displayLength, IEnumerable<AOColumn> columns, AASort sortOption, string ajaxSource,
      string footerSuffix = "", string tableHeight = "200px")
      : this(
        displayLength, columns, (sortOption == null) ? null : new[] {sortOption}, ajaxSource, footerSuffix, tableHeight)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="displayLength">Number of rows to display on a single page when using pagination</param>
    /// <param name="columns">Column specifications</param>
    /// <param name="sortOptions">Column sort options. If this is null no sorting will be applied</param>
    /// <param name="ajaxSource">AJAX source URL</param>
    /// <param name="footerSuffix">
    ///   [Optional] This string gives information to the end user about the information
    ///   that is current on display on the page
    /// </param>
    /// <param name="tableHeight">
    ///   [Optional] Height of the table in pixels. Defaults to 200px. Note. Pass in a null if to do not
    ///   want any table height set
    /// </param>
    /// <exception cref="System.Exception"></exception>
    /// <exception cref="System.ArgumentNullException"></exception>
    public DatatableSettings(int displayLength, IEnumerable<AOColumn> columns, IEnumerable<AASort> sortOptions,
      string ajaxSource, string footerSuffix = "", string tableHeight = "200px")
      : this(displayLength, sortOptions, ajaxSource, footerSuffix, tableHeight)
    {
      if (columns == null)
        throw new ArgumentNullException("columns");

      IEnumerable<AOColumn> enumerable = columns as AOColumn[] ?? columns.ToArray();

      CheckAOColumnSetup(enumerable);

      aoColumns = enumerable.ToArray();
    }

    #endregion Ctors

    #region Init

    /// <summary>
    ///   Initialise
    /// </summary>
    private void Init()
    {
      Plugins = new List<IDatatablePlugin<object>>();
      iDisplayLength = 10;
    }

    #endregion Init

    #region Setups

    /// <summary>
    ///   Setup the jQuery dataTables aaSort variable from given set
    ///   of sort option
    /// </summary>
    /// <param name="sortOption">Sort option</param>
    public void SetupAASort(AASort sortOption)
    {
      SetupAASort(new[] {sortOption});
    }

    /// <summary>
    ///   Setup the jQuery dataTables aaSort variable from given set
    ///   of sort options
    /// </summary>
    /// <param name="sortOptions">Sort options</param>
    public virtual void SetupAASort(IEnumerable<AASort> sortOptions)
    {
      if (sortOptions != null)
        aaSorting = sortOptions.Select(f => f.ToArray()).ToArray();
    }

    /// <summary>
    ///   Setup the paging mechanism. <see cref="T:WebExtras.Core.WebExtrasConstants" />
    /// </summary>
    /// <param name="type">Pagination type to use</param>
    public virtual void SetupPaging(EPagination type)
    {
      string sDomDefault = string.Empty;

      switch (type)
      {
        case EPagination.None:
          bPaginate = false;
          sPaginationType = null;
          iDisplayLength = 10000;
          break;

        case EPagination.Bootstrap:
          sDomDefault = "t<'row-fluid'<'span6'i><'span6'p>>";
          goto default;

        case EPagination.Bootstrap3:
          sDomDefault = "t<'row'<'col-xs-6'i><'col-xs-6'p>>";
          goto default;

        case EPagination.Gumby:
          sDomDefault = "t<'row'<'six columns'i><'six columns'p>>";
          goto default;

        default:
          bPaginate = true;
          sDom = string.IsNullOrWhiteSpace(sDom) ? sDomDefault : sDom;
          sPaginationType = type.GetStringValue();
          break;
      }

      Paging = type;
    }

    /// <summary>
    ///   Sets up the created row callback.
    /// </summary>
    /// <remarks>
    ///   Invoked when status column is enabled for the datatable via the
    ///   <see cref="WebExtras.JQDataTables.Datatable" /> constructor
    /// </remarks>
    public virtual void SetupfnCreatedRow()
    {
      string[] fnParamNames = {"nRow", "aData", "iDataIndex"};
      const string fnBody = "$(nRow).addClass(aData[aData.length - 1]);";

      fnCreatedRow = new JsFunc {Body = fnBody, ParameterNames = fnParamNames};
    }

    /// <summary>
    ///   Sets up postbacks for the server data callback
    /// </summary>
    /// <param name="postbacks">Postbacks to be setup</param>
    /// <remarks>Invoked when there are postbacks via the <see cref="WebExtras.JQDataTables.Datatable" /> constructor </remarks>
    public virtual void SetupfnServerData(IEnumerable<PostbackItem> postbacks)
    {
      IEnumerable<PostbackItem> postbackItems = postbacks as IList<PostbackItem> ?? postbacks.ToList();
      if (postbacks == null || !postbackItems.Any())
        return;

      string[] aoDataPushes = postbackItems.Select(f => string.Format("aoData.push({0});", f.ToJson())).ToArray();

      string[] fnParamNames = {"sSource", "aoData", "fnCallback"};

      StringBuilder fnBody = new StringBuilder();
      fnBody.Append("\n\t\t");
      fnBody.Append(string.Join("\n\t\t", aoDataPushes));
      fnBody.Append("\n\t\t");
      fnBody.Append("$.getJSON(sSource, aoData, function(json) { fnCallback(json); });");

      fnServerData = new JsFunc {ParameterNames = fnParamNames, Body = fnBody.ToString()};
    }

    #endregion Setups

    #region Checks

    /// <summary>
    ///   Checks whether the aoColumns have been setup properly
    /// </summary>
    /// <param name="columns">A collection of columns</param>
    /// <exception cref="WebExtras.Core.InvalidUsageException"></exception>
    private static void CheckAOColumnSetup(IEnumerable<AOColumn> columns)
    {
      List<int> emptyHeading = new List<int>();
      int idx = 0;
      foreach (AOColumn c in columns)
      {
        if (string.IsNullOrEmpty(c.sTitle) && ((c.bVisible.HasValue && c.bVisible.Value) || !c.bVisible.HasValue))
        {
          emptyHeading.Add(idx);
        }
        idx++;
      }

      if (emptyHeading.Count > 0)
        throw new InvalidUsageException(string.Format("Column(s) {0} have no title specified.",
          string.Join(",", emptyHeading)));
    }

    #endregion Checks

    /// <summary>
    ///   Returns a JSON serialized version of this object
    /// </summary>
    /// <returns>Returns a JSON serialized version of this object</returns>
    public override string ToString()
    {
      return ToString(WebExtrasSettings.JsonSerializerSettings);
    }

    /// <summary>
    ///   Returns a JSON serialized version of this object
    /// </summary>
    /// <param name="settings">Json serialiser settings</param>
    /// <returns>Returns a JSON serialized version of this object</returns>
    public string ToString(JsonSerializerSettings settings)
    {
      settings.Converters.Add(new EServerMethodJsonConverter());

      IDictionary<string, object> serializationDict = DatatablesHelper.ToDictionary(this, settings.NullValueHandling);

      IDictionary<string, object> pluginOptions = new Dictionary<string, object>();

      foreach (IDatatablePlugin<object> p in Plugins)
      {
        var options = p.CreateOptions(settings.NullValueHandling);

        pluginOptions.Add(p.Name, options);
      }

      if (sPaginationType == EPagination.Bootstrap.GetStringValue() && !string.IsNullOrWhiteSpace(sPaginationType))
        sPaginationType = EPagination.FullNumbers.GetStringValue();

      serializationDict = serializationDict.Merge(pluginOptions);

      string json = JsonConvert.SerializeObject(serializationDict, settings);

      return json;
    }
  }
}