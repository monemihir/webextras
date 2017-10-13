// 
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
using System.Web.Mvc;
using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Html;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   Bootstrap hyperlink/button decorators
  /// </summary>
  public static class HtmlStringExtension
  {
    #region Icon extensions

    /// <summary>
    ///   Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with icon added</returns>
    /// <exception cref="BootstrapVersionException">
    ///   Thrown when a valid Bootstrap version
    ///   is not selected
    /// </exception>
    public static T AddIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null)
      where T : IExtendedHtmlString
    {
      //List<string> cssClasses = new List<string>();

      //switch (WebExtrasConstants.BootstrapVersion)
      //{
      //  case EBootstrapVersion.V2:
      //    cssClasses.Add("icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));
      //    break;
      //  case EBootstrapVersion.V3:
      //    cssClasses.Add("glyphicon glyphicon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));
      //    break;
      //  default:
      //    throw new BootstrapVersionException();
      //}

      html = AddIcon(html, new[] {icon.GetStringValue()}, htmlAttributes);

      return html;
    }

    /// <summary>
    ///   Add a white icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with a white icon added</returns>
    /// <exception cref="BootstrapVersionException">
    ///   Thrown when a valid Bootstrap version
    ///   is not selected
    /// </exception>
    public static T AddWhiteIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null)
      where T : IExtendedHtmlString
    {
      switch (WebExtrasSettings.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          break;
        case EBootstrapVersion.V3:
          throw new InvalidOperationException(
            "Since Bootstrap v3, all icons are font based. Therefore, you must use CSS styling to control icon color");
        default:
          throw new BootstrapVersionException();
      }

      html = AddIcon(html, new[] {"icon-white " + icon.GetStringValue()}, htmlAttributes);

      return html;
    }

    /// <summary>
    ///   Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">[Optional] Icon size</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with icon added</returns>
    /// <exception cref="FontAwesomeVersionException">
    ///   Thrown when a valid FontAwesome
    ///   icon library version is not selected
    /// </exception>
    public static T AddIcon<T>(this T html, EFontAwesomeIcon icon,
      EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null)
      where T : IExtendedHtmlString
    {
      string prefix = string.Empty;

      if (WebExtrasSettings.FontAwesomeVersion == EFontAwesomeVersion.V3)
        prefix = "icon-";
      else if (WebExtrasSettings.FontAwesomeVersion == EFontAwesomeVersion.V4)
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
    ///   Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="cssClasses">Css classes to be added</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with icon added</returns>
    private static T AddIcon<T>(T html, IEnumerable<string> cssClasses, object htmlAttributes = null)
      where T : IExtendedHtmlString
    {
      IDictionary<string, object> rvd = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

      List<string> finalClasses = new List<string>(cssClasses);
      finalClasses.Add("wb-ext-addicon");

      if (rvd.ContainsKey("class"))
      {
        finalClasses.AddRange(rvd["class"].ToString().Split(' '));
        rvd.Remove("class");
      }

      HtmlComponent i = new HtmlComponent(EHtmlTag.I);
      i.CssClasses.AddRange(finalClasses);

      foreach (string key in rvd.Keys)
        i.Attributes[key] = rvd[key].ToString();

      // TODO: remove unnecessary conversion
      html.Prepend(i.ToHtmlElement());

      if (html.Attributes.ContainsKey("style"))
        html.Attributes["style"] += ";text-decoration:none";
      else
        html.Attributes["style"] = "text-decoration:none";

      return html;
    }

    #endregion Icon extensions

    #region Button extensions

    /// <summary>
    ///   Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. Can only be either Hyperlink or Button</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <returns>A special button</returns>
    public static T AsButton<T>(this T html) where T : IExtendedHtmlString
    {
      return AsButton(html, EBootstrapButton.Default);
    }

    /// <summary>
    ///   Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. Can only be either Hyperlink or Button</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <param name="types">Bootstrap button types</param>
    /// <returns>A special button</returns>
    public static T AsButton<T>(this T html, params EBootstrapButton[] types) where T : IExtendedHtmlString
    {
      if (!WebExtrasMvcUtil.CanDisplayAsButton(html))
        throw new InvalidUsageException("The AsButton decorator can only be used with Button and Hyperlink extensions");

      html.AddCssClass(string.Join(" ", types.Select(t => t.GetStringValue())));

      return html;
    }

    #endregion Button extensions

    #region List extensions

    /// <summary>
    ///   Create an unstyled list
    /// </summary>
    /// <param name="list">List to be converted</param>
    /// <returns>An unstyled list</returns>
    public static IExtendedHtmlString AsUnstyled(this HtmlList list)
    {
      list.CssClasses.Add("unstyled list-unstyled");

      // TODO: Remove redundant re-conversion
      return list.ToHtmlElement();
    }

    /// <summary>
    ///   Create an inline list.
    /// </summary>
    /// <param name="list">List to be converted</param>
    /// <returns>An inline list</returns>
    public static IExtendedHtmlString AsInline(this HtmlList list)
    {
      list.CssClasses.Add("inline list-inline");

      // TODO: Remove redundant re-conversion
      return list.ToHtmlElement();
    }

    #endregion List extensions
  }
}