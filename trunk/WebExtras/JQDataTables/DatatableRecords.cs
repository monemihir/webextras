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
  /// Class encapsulating the returned well formed json data to a datatables table from a ajax call
  /// http://www.datatables.net
  ///
  /// "In reply to each request for information that DataTables makes to the server,
  /// it expects to get a well formed JSON object with the following parameters."
  /// http://www.datatables.net/usage/server-side
  /// </summary>
  [Serializable]
  public class DatatableRecords
  {
    /// <summary>
    /// Total records, before filtering (i.e. the total number of records in the database)
    /// </summary>
    public int iTotalDisplayRecords { get; set; }

    /// <summary>
    /// Total records, after filtering (i.e. the total number of records after filtering has been
    /// applied - not just the number of records being returned in this result set)
    /// </summary>
    public int iTotalRecords { get; set; }

    /// <summary>
    /// An unaltered copy of sEcho sent from the client side. This parameter will change with each draw (it is basically a draw count) -
    /// so it is important that this is implemented. Note that it strongly recommended for security reasons that you 'cast'
    /// this parameter to an integer in order to prevent Cross Site Scripting (XSS) attacks.
    /// </summary>
    public string sEcho { get; set; }

    /// <summary>
    /// The data in a 2D array
    /// </summary>
    private string[][] m_aaData;

    /// <summary>
    /// The data in a 2D array
    /// </summary>
    public string[][] aaData
    {
      get { return m_aaData; }
      set { m_aaData = SanitiseAAData(value); }
    }

    /// <summary>
    /// Check whether the aaData property is jagged collection and 
    /// if it is converts it to a square/rectangular collection.
    /// This makes sure that we don't have missing columns and avoids
    /// DataTables throwing javascript errors for columns missing.
    /// </summary>
    /// <param name="toBeSanitised">Collection to be sanitised</param>
    /// <returns>Sanitised collection</returns>
    private string[][] SanitiseAAData(IEnumerable<IEnumerable<string>> toBeSanitised)
    {
      if (toBeSanitised != null)
      {
        IEnumerable<IEnumerable<string>> beSanitised = toBeSanitised as IEnumerable<string>[] ?? toBeSanitised.ToArray();
        string[][] newAAData = beSanitised.Select(f => f.ToArray()).ToArray();

        if (beSanitised.Count() > 1)
        {
          int maxLength = beSanitised.Where(f => f != null).Max(f => f.Count());
          IEnumerable<string> empty = Enumerable.Range(0, maxLength).Select(f => string.Empty);
          newAAData = beSanitised
            .Select(f => f.Concat(empty).Take(maxLength))
            .Select(f => f.ToArray())
            .ToArray();
        }

        return newAAData;
      }

      return null;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public DatatableRecords()
    {
      sEcho = "1";
      aaData = new string[0][];
      iTotalDisplayRecords = 0;
      iTotalRecords = 0;
    }

    /// <summary>
    /// Create records from a collection
    /// </summary>
    /// <typeparam name="TType">Type of the collection</typeparam>
    /// <param name="values">The collection to create records from</param>
    /// <returns>Created records</returns>
    /// <exception cref="WebExtras.Core.InvalidUsageException"></exception>
    public static DatatableRecords From<TType>(ICollection<TType> values)
      where TType : class
    {
      List<string[]> data = new List<string[]>();

      if (values == null)
        return new DatatableRecords();

      if (!values.Any())
        return new DatatableRecords();

      Type t = typeof(TType);

      foreach (TType value in values)
      {
        List<KeyValuePair<int, string>> indexedValues = new List<KeyValuePair<int, string>>();
        PropertyInfo[] props = value.GetType().GetProperties();
        foreach (PropertyInfo prop in props)
        {
          AOColumnAttribute[] attribs = (AOColumnAttribute[])prop.GetCustomAttributes(typeof(AOColumnAttribute), false);

          if (attribs.Length == 0)
            continue;

          if (attribs.Length > 1)
            throw new InvalidUsageException(
              string.Format("The property '{0}' on '{1}' can not have multiple decorations of AOColumn attribute", prop.Name, t.FullName));

          // fact that we got here means that the current property is an AOColumn
          IValueFormatter formatter = (IValueFormatter)(attribs[0].ValueFormatter == null ?
            new DefaultValueFormatter() :
            Activator.CreateInstance(attribs[0].ValueFormatter));

          string val = formatter.Format(prop.GetValue(value, null), attribs[0].FormatString, value);

          indexedValues.Add(new KeyValuePair<int, string>(attribs[0].Index, val));
        }

        data.Add(indexedValues.OrderBy(f => f.Key).Select(g => g.Value).ToArray());
      }

      DatatableRecords records = new DatatableRecords
      {
        iTotalDisplayRecords = data.Count,
        iTotalRecords = data.Count,
        aaData = data.ToArray()
      };

      return records;
    }

    /// <summary>
    /// Returns a JSON serialized version of this object
    /// </summary>
    /// <returns>Returns a JSON serialized version of this object</returns>
    public override string ToString()
    {
      return this.ToJson();
    }

    /// <summary>
    /// Render aaData as table rows
    /// </summary>
    /// <returns>Table rows in format <tr><td>...</td><td>...</td></tr></returns>
    public string RenderAADataAsTableRows()
    {
      if (aaData.Length > 0)
        return string.Join("", aaData.Select(r => "<tr>" + string.Join("", r.Select(d => "<td>" + d + "</td>")) + "</tr>"));

      return string.Empty;
    }
  }
}