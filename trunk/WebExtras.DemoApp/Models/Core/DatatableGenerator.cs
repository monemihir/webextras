/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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
using System.Web;
using WebExtras.Mvc.Html;

namespace WebExtras.DemoApp.Models.Core
{
  /// <summary>
  /// Datatable generator
  /// </summary>
  public static class DatatableGenerator
  {
    /// <summary>
    /// Get data containing special formats i.e hyperlinks, dates, currency 
    /// </summary>
    /// <returns>Special format data</returns>
    public static IList<string[]> GetDataWithSpecialFormat()
    {
      List<string[]> dtData = new List<string[]> {
        new string[] { new Hyperlink("4","#").ToHtmlString(), "mihir", "02-Jan-13", "2", "&euro; 15.00" },
        new string[] { "<a href='#'>3</a>", "sneha", "2013-Mar-12", "45", "&pound; 12.00" },
        new string[] { "<a href='#'>1</a>", "mohan", "20 Mar 13", "32", "$ 151.00" },
        new string[] { "<a href='#'>2</a>", "swati", "29May13", "10", "&#8377; 201.00" },
        new string[] { "<a href='#'>2</a>", "sindhu", "Feb 11, 2012", "110", "&yen; 92.00" }
      };

      return dtData;
    }

    /// <summary>
    /// Get default data
    /// </summary>
    /// <returns>Default data</returns>
    public static IList<string[]> GetDefaultData()
    {
      IList<string[]> dtData = new List<string[]>
      {
        new string[] { "first column row 1", "second column row 1" },    
        new string[] { "first column row 2", "second column row 2" },
        new string[] { "first column row 3", "second column row 3" },
        new string[] { "first column row 4", "second column row 4" }
      };

      return dtData;
    }

    /// <summary>
    /// Get default data with status column classes
    /// </summary>
    /// <returns>Default data</returns>
    public static IList<string[]> GetDefaultDataWithStatusColumn()
    {
      IList<string[]> dtData = new List<string[]>
      {
        new string[] { "first column row 1", "second column row 1", "error danger" },    
        new string[] { "first column row 2", "second column row 2", "warning" },
        new string[] { "first column row 3", "second column row 3", "info" },
        new string[] { "first column row 4", "second column row 4", "success" }
      };

      return dtData;
    }
  }
}