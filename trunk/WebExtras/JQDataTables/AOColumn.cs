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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using WebExtras.Core;

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
    public int[] aDataSort { get; set; }

    /// <summary>
    /// You can control the default sorting direction, and even alter the behaviour of 
    /// the sort handler (i.e. only allow ascending sorting etc) using this parameter
    /// </summary>
    public string[] asSorting { get; set; }

    /// <summary>
    /// Enable or disable filtering on the data in this column
    /// </summary>
    public bool? bSearchable { get; set; }

    /// <summary>
    /// Enable / Disable sorting based on this column
    /// </summary>
    public bool? bSortable { get; set; }

    /// <summary>
    /// Flag indicating whether the column is visible
    /// </summary>
    public bool? bVisible { get; set; }

    /// <summary>
    /// The column index (starting from 0!) that you wish a sort to be performed 
    /// upon when this column is selected for sorting. This can be used for sorting 
    /// on hidden columns for example
    /// </summary>
    public int? iDataSort { get; set; }

    /// <summary>
    /// Change the cell type created for the column - either TD cells or TH cells. 
    /// This can be useful as TH cells have semantic meaning in the table body, 
    /// allowing them to act as a header for a row (you may wish to add scope='row' 
    /// to the TH elements)
    /// </summary>
    public string sCellType { get; set; }

    /// <summary>
    /// CSS Class to give to each cell in this column
    /// </summary>
    public string sClass { get; set; }

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
    public string sContentPadding { get; set; }

    /// <summary>
    /// Allows a default value to be given for a column's data, and will be used 
    /// whenever a null data source is encountered (this can be because mData 
    /// is set to null, or because the data source itself is null)
    /// </summary>
    public string sDefaultContent { get; set; }

    /// <summary>
    /// This parameter is only used in DataTables' server-side processing. It can 
    /// be exceptionally useful to know what columns are being displayed on the 
    /// client side, and to map these to database fields. When defined, the names 
    /// also allow DataTables to reorder information from the server if it comes 
    /// back in an unexpected order (i.e. if you switch your columns around on 
    /// the client-side, your server-side code does not also need updating)
    /// </summary>
    public string sName { get; set; }

    /// <summary>
    /// Defines a data source type for the sorting which can be used to read 
    /// real-time information from the table (updating the internally cached version) 
    /// prior to sorting. This allows sorting to occur on user editable elements 
    /// such as form inputs
    /// </summary>
    public string sSortDataType { get; set; }

    /// <summary>
    /// The title of the column
    /// </summary>
    public string sTitle { get; set; }

    /// <summary>
    /// The type allows you to specify how the data for this column will be sorted. 
    /// Four types (string, numeric, date and html (which will strip HTML tags before 
    /// sorting)) are currently available. Note that only date formats understood by 
    /// Javascript's Date() object will be accepted as type date. 
    /// For example: "Mar 26, 2008 5:03 PM"
    /// </summary>
    [JsonConverter(typeof(EAOColumnTypeJsonConverter))]
    public EAOColumn? sType { get; set; }

    /// <summary>
    /// Defining the width of the column, this parameter may take any CSS value 
    /// (3em, 20px etc). DataTables applies 'smart' widths to columns which have 
    /// not been given a specific width through this interface ensuring that the 
    /// table remains readable
    /// </summary>
    public string sWidth { get; set; }

    /// <summary>
    /// Developer definable function that is called whenever a cell is created (Ajax 
    /// source, etc) or processed for input (DOM source). This can be used as a 
    /// compliment to mRender allowing you to modify the DOM element (add background 
    /// colour for example) when the element is available.
    /// </summary>
    public JsFunc fnCreatedCell { get; set; }

    /// <summary>
    /// Custom display function that will be called for the display of each cell in this column.
    /// </summary>
    [Obsolete("Use mRender/mData properties instead")]
    public JsFunc fnRender { get; set; }

    /// <summary>
    /// This property can be used to read data from any JSON data source property, including 
    /// deeply nested objects / properties. mData can be given in a number of different ways 
    /// which effect its behaviour: integer, string, null or a <see cref="WebExtras.Core.JsFunc"/> object
    /// </summary>
    public object mData { get; set; }

    /// <summary>
    /// This property is the rendering partner to mData and it is suggested that when you want 
    /// to manipulate data for display (including filtering, sorting etc) but not altering the 
    /// underlying data for the table, use this property. mData can actually do everything this 
    /// property can and more, but this parameter is easier to use since there is no 'set' 
    /// option. Like mData is can be given in a number of different ways to effect its behaviour, 
    /// with the addition of supporting array syntax for easy outputting of arrays (including 
    /// arrays of objects): integer, string or a <see cref="WebExtras.Core.JsFunc"/> object
    /// </summary>
    public object mRender { get; set; }

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

      sTitle = title;
    }

    /// <summary>
    /// Create AOColumn definitions from a type
    /// </summary>
    /// <typeparam name="TType">Type to create AOColumn definitions from</typeparam>
    /// <returns>Generated columns</returns>
    public static AOColumn[] FromType<TType>()
      where TType : class
    {
      Type t = typeof(TType);

      return FromType(t);
    }

    /// <summary>
    /// Create AOColumn definitions from a type
    /// </summary>
    /// <param name="type">Type to create AOColumn definitions from</param>
    /// <returns>Generated columns</returns>
    public static AOColumn[] FromType(Type type)
    {
      string[] ignoredAttributeProperties = { "ValueFormatter", "TypeId" };
      List<KeyValuePair<int, AOColumn>> indexedColumns = new List<KeyValuePair<int, AOColumn>>();

      // get the type and all public properties of the given object instance
      PropertyInfo[] props = type.GetProperties();

      foreach (PropertyInfo prop in props)
      {
        AOColumnAttribute[] attribs = (AOColumnAttribute[])prop.GetCustomAttributes(typeof(AOColumnAttribute), false);

        if (attribs.Length == 0)
          continue;

        if (attribs.Length > 1)
          throw new InvalidUsageException(
            string.Format("The property '{0}' on '{1}' can not have multiple decorations of AOColumn attribute", prop.Name, type.FullName));

        // fact that we got here means that the attribute decoration was all good
        PropertyInfo[] attribProps = attribs[0].GetType().GetProperties();
        AOColumn column = new AOColumn();
        int idx = -1;
        foreach (PropertyInfo attribProp in attribProps)
        {
          // get the value of the attribute property
          object val = attribProp.GetValue(attribs[0], null);

          // the 'TypeId' property is inherited from System.Attribute class
          // and we don't care about it, so just ignore it
          if (val == null || ignoredAttributeProperties.Contains(attribProp.Name))
            continue;

          // the 'Index' property governs the position of the column in the
          // rendered table, so just store it for now and continue
          if (attribProp.Name == "Index")
          {
            idx = (int)val;
            continue;
          }

          // get the same property from AOColumn class and set it's value to
          // the value obtained from the attribute's property
          PropertyInfo propToSet = column.GetType().GetProperty(attribProp.Name);
          propToSet.SetValue(column, val, null);
        }

        // store the column with it's index for further processing
        indexedColumns.Add(new KeyValuePair<int, AOColumn>(idx, column));
      }

      // order the columns by their key and select
      List<AOColumn> columns = indexedColumns.OrderBy(f => f.Key).Select(g => g.Value).ToList();

      return columns.ToArray();
    }
  }
}