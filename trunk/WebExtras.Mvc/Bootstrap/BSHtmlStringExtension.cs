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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoreLinq;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap hyperlink/button decorators
  /// </summary>
  public static class BSHtmlStringExtension
  {
    #region Icon extensions

    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>    
    /// <returns>Html element with icon added</returns>
    /// <exception cref="WebExtras.Mvc.Core.BootstrapVersionException">Thrown when a valid Bootstrap version
    /// is not selected</exception>
    public static T AddIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      List<string> cssClasses = new List<string>();

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

      html = AddIcon(html, cssClasses, htmlAttributes);

      return html;
    }

    /// <summary>
    /// Add a white icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with a white icon added</returns>
    /// <exception cref="WebExtras.Mvc.Core.BootstrapVersionException">Thrown when a valid Bootstrap version
    /// is not selected</exception>
    public static T AddWhiteIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      List<string> cssClasses = new List<string>();

      switch (WebExtrasMvcConstants.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          cssClasses.Add("icon-white icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));
          break;
        case EBootstrapVersion.V3:
          throw new InvalidOperationException("Since Bootstrap v3, all icons are font based. Therefore, you must use CSS styling to control icon color");
        default:
          throw new BootstrapVersionException();
      }

      html = AddIcon(html, cssClasses, htmlAttributes);

      return html;
    }

    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">[Optional] Icon size</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with icon added</returns>
    /// <exception cref="WebExtras.Mvc.Core.FontAwesomeVersionException">Thrown when a valid FontAwesome
    /// icon library version is not selected</exception>
    public static T AddIcon<T>(this T html, EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      string prefix = string.Empty;

      if (WebExtrasMvcConstants.FontAwesomeVersion == EFontAwesomeVersion.V3)
        prefix = "icon-";
      else if (WebExtrasMvcConstants.FontAwesomeVersion == EFontAwesomeVersion.V4)
        prefix = "fa fa-";
      else
        throw new FontAwesomeVersionException();

      List<string> cssClasses = new List<string>
      {
        prefix + icon.ToString().ToLowerInvariant().Replace("_", "-")
      };

      if (size != EFontAwesomeIconSize.Normal)
        cssClasses.Add(prefix + size.GetStringValue());

      html = AddIcon(html, cssClasses, htmlAttributes);

      return html;
    }

    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="cssClasses">Css classes to be added</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with icon added</returns>
    private static T AddIcon<T>(T html, IEnumerable<string> cssClasses, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      IDictionary<string, object> rvd = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

      List<string> finalClasses = new List<string>(cssClasses);

      if (rvd.ContainsKey("class"))
      {
        finalClasses.AddRange(rvd["class"].ToString().Split(' '));
        rvd.Remove("class");
      }

      Italic i = new Italic();
      i["class"] = string.Join(" ", finalClasses);

      rvd.ForEach(f => i.Attributes[f.Key] = f.Value.ToString());

      html.Prepend(i);

      if (html.Attributes.ContainsKey("style"))
        html.Attributes["style"] += ";text-decoration:none";
      else
        html.Attributes["style"] = "text-decoration:none";

      return html;
    }

    #endregion Icon extensions

    #region Button extensions

    /// <summary>
    /// Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. Can only be either Hyperlink or Button</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <returns>A special button</returns>
    public static T AsButton<T>(this T html) where T : IExtendedHtmlString
    {
      return AsButton(html, EBootstrapButton.Default);
    }

    /// <summary>
    /// Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. Can only be either Hyperlink or Button</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <param name="types">Bootstrap button types</param>
    /// <returns>A special button</returns>
    public static T AsButton<T>(this T html, params EBootstrapButton[] types) where T : IExtendedHtmlString
    {
      if (!HtmlStringUtil.CanDisplayAsButton(html))
        throw new InvalidUsageException("The AsButton decorator can only be used with Button and Hyperlink extensions");

      html.AddCssClass(string.Join(" ", types.Select(t => t.GetStringValue())));

      return html;
    }

    #endregion Button extensions

    #region List extensions

    /// <summary>
    /// Create an unstyled list
    /// </summary>
    /// <param name="list">List to be converted</param>
    /// <returns>An unstyled list</returns>
    public static IExtendedHtmlString AsUnstyled(this HtmlList list)
    {
      list.AddCssClass("unstyled list-unstyled");

      return list;
    }

    /// <summary>
    /// Create an inline list.
    /// </summary>
    /// <param name="list">List to be converted</param>
    /// <returns>An inline list</returns>
    public static IExtendedHtmlString AsInline(this HtmlList list)
    {
      list.AddCssClass("inline list-inline");

      return list;
    }

    #endregion List extensions
  }
}
