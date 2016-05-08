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

using System.Collections.Specialized;
using WebExtras.Component;
using WebExtras.Core;

namespace WebExtras.Gumby
{
  /// <summary>
  /// Gumby utility methods
  /// </summary>
  public static class GumbyUtil
  {
    /// <summary>
    /// Creates an icon
    /// </summary>
    /// <param name="icon">Icon to be created</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes</param>
    /// <returns>A Gumby icon</returns>
    public static IHtmlComponent CreateIcon(EGumbyIcon icon, object htmlAttributes = null)
    {
      NameValueCollection attrsDictionary = WebExtrasUtil.AnonymousObjectToHtmlAttributes(htmlAttributes);

      HtmlComponent i = new HtmlComponent(EHtmlTag.I);

       i.CssClasses.Add("icon-" + icon.ToString().ToLowerInvariant().Replace('_', '-'));

      foreach (string key in attrsDictionary.Keys)
        i.Attributes[key] = attrsDictionary[key];

      return i;
    }
  }
}
