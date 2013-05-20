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
using System.Linq;
using System.Web.Routing;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap hyperlink extensions
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
    public static T AddIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      Italic i = new Italic();
      RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
      i.Tag.MergeAttributes<string, object>(attributes);
      
      i["class"] += " icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-");
      
      html.Prepend(i);

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
    public static T AddWhiteIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      Italic i = new Italic();
      RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
      i.Tag.MergeAttributes<string, object>(attributes);
      
      i["class"] = "icon-white icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-");

      html.Prepend(i);

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
    public static T AddIcon<T>(this T html, EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      Italic i = new Italic();
      RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
      i.Tag.MergeAttributes<string, object>(attributes);

      i["class"] += " icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-");

      if (size != EFontAwesomeIconSize.Normal)
        i["class"] += " icon-" + size.GetStringValue();

      html.Prepend(i);

      return html;
    }

    /// <summary>
    /// Add a white icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">[Optional] Icon size</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>Html element with a white icon added</returns>
    public static T AddWhiteIcon<T>(this T html, EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      Italic i = new Italic();
      RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
      i.Tag.MergeAttributes<string, object>(attributes);
      
      i["class"] = "icon-white icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-");

      if (size != EFontAwesomeIconSize.Normal)
        i["class"] += " icon-" + size.GetStringValue();
            
      html.Prepend(i);

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
      return AsButton<T>(html, EBootstrapButton.Default);
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
      if (CanDisplayAsButton(html))
        html.AddCssClass(string.Join(" ", types.Select(t => t.GetStringValue())));

      return html;
    }

    /// <summary>
    /// Check whether we can actually display as button
    /// </summary>
    /// <param name="html">Current HTML element</param>
    /// <returns>True if can display as button, else False</returns>
    private static bool CanDisplayAsButton(IExtendedHtmlString html)
    {
      // We can only display hyperlinks and button as buttons
      try { Hyperlink h = html as Hyperlink; return true; }
      catch (Exception) { }

      try { Button b = html as Button; return true; }
      catch (Exception) { }

      return false;
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
      list.AddCssClass("unstyled");

      return list;
    }

    #endregion List extensions
  }
}
