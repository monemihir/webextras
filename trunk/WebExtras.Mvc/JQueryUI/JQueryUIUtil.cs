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

using System.Collections.Generic;
using System.Web.Routing;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.JQueryUI
{
  /// <summary>
  /// jQuery UI utility methods
  /// </summary>
  public static class JQueryUIUtil
  {
    /// <summary>
    /// Creates a jQuery UI icon
    /// </summary>
    /// <param name="icon">Icon to be created</param>
    /// <param name="htmlAttributes">[Optional] Any extra HTML attributes</param>
    /// <returns>A jQuery UI icon</returns>
    public static IExtendedHtmlString CreateIcon(EJQueryUIIcon icon, object htmlAttributes = null)
    {
      RouteValueDictionary rvd = new RouteValueDictionary(htmlAttributes);

      List<string> cssClasses = new List<string>();
      if (rvd.ContainsKey("class"))
      {
        cssClasses.AddRange(rvd["class"].ToString().Split(' '));
        rvd.Remove("class");
      }

      cssClasses.Add("ui-icon");
      cssClasses.Add("ui-icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));
      
      Italic i = new Italic();
      i["class"] = string.Join(" ", cssClasses);

      return i;
    }
  }
}
