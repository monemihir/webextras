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
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// Gumby hyperlink/button decorator
  /// </summary>
  public static class GumbyHtmlStringExtensions
  {
    ///// <summary>
    ///// Add an icon
    ///// </summary>
    ///// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    ///// <param name="html">Current HTML element</param>
    ///// <param name="icon">Gumby icon to be added</param>
    ///// <param name="iconLeft">[Optional] Flag indicating whether to place icon on left. Defaults to true</param>
    ///// <returns>HTML element with icon added</returns>
    //public static T AddIcon<T>(this T html, EGumbyIcon icon, bool iconLeft = true) where T : IExtendedHtmlString
    //{
    //  if (iconLeft)
    //    html.Tag.AddCssClass("icon-left icon-" + icon.ToString().ToLowerInvariant());
    //  else
    //    html.Tag.AddCssClass("icon-right icon-" + icon.ToString().ToLowerInvariant());

    //  return html;
    //}

    /// <summary>
    /// Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <param name="type">Gumby button type</param>
    /// <param name="style">Gumby button styles</param>
    /// <returns>A Gumby button styled hyperlink</returns>
    public static IExtendedHtmlString AsButton<T>(this T html, EGumbyButton type, params EGumbyButtonStyle[] style) where T : IExtendedHtmlString
    {
      if (WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new GumbyThemeException();

      if (!HtmlStringUtil.CanDisplayAsButton(html))
        throw new InvalidOperationException("The AsButton decorator can only be used with Button and Hyperlink extensions");

      string[] classes = new string[] { 
        "btn",
        type.ToString().ToLowerInvariant(),
        WebExtrasMvcConstants.GumbyTheme.ToString().ToLowerInvariant()
      };

      Div div = new Div();

      div["class"] = string.Join(" ", classes.Concat(style.Select(s => s.ToString().ToLowerInvariant())));

      div.Append(html);

      return div;
    }
  }
}
