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

using MoreLinq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap utility methods
  /// </summary>
  public static class BootstrapUtil
  {
    /// <summary>
    /// Creates a Bootstrap icon
    /// </summary>
    /// <param name="icon">Icon to be created</param>
    /// <param name="htmlAttributes">[Optional] Any extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    public static IExtendedHtmlString CreateIcon(EBootstrapIcon icon, object htmlAttributes = null)
    {
      RouteValueDictionary rvd = new RouteValueDictionary(htmlAttributes);

      List<string> cssClasses = new List<string>();
      if (rvd.ContainsKey("class"))
      {
        cssClasses.AddRange(rvd["class"].ToString().Split(' '));
        rvd.Remove("class");
      }

      switch (WebExtrasMvcConstants.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          cssClasses.Add("icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));
          break;
        case EBootstrapVersion.V3:
          cssClasses.Add("glyphicon glyphicon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));
          break;
        default:
          throw new BootstrapVersionException();
      }

      Italic i = new Italic();
      i["class"] = string.Join(" ", cssClasses);

      return i;
    }

    /// <summary>
    /// Creates a Bootstrap Font-Awesome icon
    /// </summary>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">Icon size</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    /// <exception cref="WebExtras.Mvc.Core.FontAwesomeVersionException">Thrown when a valid FontAwesome
    /// icon library version is not selected</exception>
    public static IExtendedHtmlString CreateIcon(EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null)
    {
      IDictionary<string, object> attrsDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

      List<string> cssClasses = new List<string>();
      if (attrsDictionary.ContainsKey("class"))
      {
        cssClasses.AddRange(attrsDictionary["class"].ToString().Split(' '));
        attrsDictionary.Remove("class");
      }

      string prefix;

      switch (WebExtrasMvcConstants.FontAwesomeVersion)
      {
        case EFontAwesomeVersion.V3:
          prefix = "icon-";
          break;
        case EFontAwesomeVersion.V4:
          prefix = "fa fa-";
          break;
        default:
          throw new FontAwesomeVersionException();
      }

      cssClasses.Add(prefix + icon.ToString().ToLowerInvariant().Replace("_", "-"));

      if (size != EFontAwesomeIconSize.Normal)
        cssClasses.Add(prefix + size.GetStringValue());

      Italic i = new Italic();
      i["class"] = string.Join(" ", cssClasses);

      attrsDictionary.ForEach(f => i.Attributes[f.Key] = f.Value.ToString());

      return i;
    }
  }
}
