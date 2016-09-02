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
using System.Collections.Specialized;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Html;

namespace WebExtras.Bootstrap
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
    public static IHtmlComponent CreateIcon(EBootstrapIcon icon, object htmlAttributes = null)
    {
      NameValueCollection htmlAttribs = WebExtrasUtil.AnonymousObjectToHtmlAttributes(htmlAttributes);

      List<string> cssClasses = new List<string>();
      if (htmlAttribs.ContainsKey("class"))
      {
        cssClasses.AddRange(htmlAttribs["class"].Split(' '));
        htmlAttribs.Remove("class");
      }

      switch (WebExtrasConstants.BootstrapVersion)
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

      HtmlComponent i = new HtmlComponent(EHtmlTag.I);
      i.CssClasses.AddRange(cssClasses);
      return i;
    }

    /// <summary>
    /// Creates a Bootstrap Font-Awesome icon
    /// </summary>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">Icon size</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    /// <exception cref="FontAwesomeVersionException">Thrown when a valid FontAwesome
    /// icon library version is not selected</exception>
    public static IHtmlComponent CreateIcon(EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null)
    {
      NameValueCollection attrsDictionary = WebExtrasUtil.AnonymousObjectToHtmlAttributes(htmlAttributes);

      List<string> cssClasses = new List<string>();
      if (attrsDictionary.ContainsKey("class"))
      {
        cssClasses.AddRange(attrsDictionary["class"].Split(' '));
        attrsDictionary.Remove("class");
      }

      string prefix;

      switch (WebExtrasConstants.FontAwesomeVersion)
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

      HtmlComponent i = new HtmlComponent(EHtmlTag.I);
      i.CssClasses.AddRange(cssClasses);

      foreach (string key in attrsDictionary.Keys)
        i.Attributes[key] = attrsDictionary[key];

      return i;
    }
  }
}
