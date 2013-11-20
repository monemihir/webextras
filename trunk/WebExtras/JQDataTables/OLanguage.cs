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
  /// Language init options
  /// </summary>
  [Serializable]
  public class OLanguage
  {
    /// <summary>
    /// ARIA label settings
    /// </summary>
    public OAria oAria;

    /// <summary>
    /// Pagination text settings when using 'full_numbers' type pagination
    /// </summary>
    public OPaginate oPaginate;

    /// <summary>
    /// This string is shown in preference to sZeroRecords when the table is empty of data 
    /// (regardless of filtering). Note that this is an optional parameter - if it is not 
    /// given, the value of sZeroRecords will be used instead (either the default or given value)
    /// </summary>
    public string sEmptyTable;

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

    /// <summary>
    /// When a user filters the information in a table, this string is appended to the information 
    /// (sInfo) to give an idea of how strong the filtering is. The variable MAX is dynamically updated
    /// </summary>
    public string sInfoFiltered;

    /// <summary>
    /// If can be useful to append extra information to the info string at times, and this variable 
    /// does exactly that. This information will be appended to the sInfo (sInfoEmpty and sInfoFiltered 
    /// in whatever combination they are being used) at all times
    /// </summary>
    public string sInfoPostFix;

    /// <summary>
    /// DataTables has a build in number formatter (fnFormatNumber) which is used to format large 
    /// numbers that are used in the table information. By default a comma is used, but this can be 
    /// trivially changed to any character you wish with this parameter
    /// </summary>
    public string sInfoThousands;

    /// <summary>
    /// Detail the action that will be taken when the drop down menu for the pagination length option 
    /// is changed. The 'MENU' variable is replaced with a default select list of 10, 25, 50 and 100, 
    /// and can be replaced with a custom select box if required
    /// </summary>
    public string sLengthMenu;

    /// <summary>
    /// When using Ajax sourced data and during the first draw when DataTables is gathering the data, 
    /// this message is shown in an empty row in the table to indicate to the end user the the data 
    /// is being loaded. Note that this parameter is not used when loading data by server-side 
    /// processing, just Ajax sourced data with client-side processing
    /// </summary>
    public string sLoadingRecords;

    /// <summary>
    /// Text which is displayed when the table is processing a user action (usually a sort command or similar)
    /// </summary>
    public string sProcessing;

    /// <summary>
    /// Details the actions that will be taken when the user types into the filtering input text box. 
    /// The variable "INPUT", if used in the string, is replaced with the HTML text box for the 
    /// filtering input allowing control over where it appears in the string. If "INPUT" is not given 
    /// then the input box is appended to the string automatically
    /// </summary>
    public string sSearch;

    /// <summary>
    /// All of the language information can be stored in a file on the server-side, which DataTables will 
    /// look up if this parameter is passed. It must store the URL of the language file, which is in a JSON 
    /// format, and the object has the same properties as the oLanguage object in the initialiser object (i.e. 
    /// the above parameters). Please refer to one of the example language files to see how this works in action
    /// </summary>
    public string sUrl;

    /// <summary>
    /// Text shown inside the table records when the is no information to be displayed after filtering. 
    /// sEmptyTable is shown when there is simply no information in the table at all (regardless of filtering)
    /// </summary>
    public string sZeroRecords;
  }
}