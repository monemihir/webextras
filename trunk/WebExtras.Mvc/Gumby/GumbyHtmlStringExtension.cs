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
using System.Linq;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// Gumby hyperlink/button decorator
  /// </summary>
  public static class GumbyHtmlStringExtension
  {
    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <param name="icon">Gumby icon to be added</param>
    /// <param name="iconLeft">[Optional] Flag indicating whether to place icon on left. Defaults to true</param>
    /// <returns>HTML element with icon added</returns>
    public static T AddIcon<T>(this T html, EGumbyIcon icon, bool iconLeft = true) where T : IExtendedHtmlString
    {
      Italic i = new Italic();
      i["class"] = "icon-" + icon.ToString().ToLowerInvariant().Replace('_', '-');

      if (iconLeft)
        html.Prepend(i);
      else
        html.Append(i);

      return html;
    }

    /// <summary>
    /// Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <param name="type">Gumby button type</param>
    /// <param name="sizeOrstyle">Gumby button size/style</param>
    /// <returns>A Gumby button styled hyperlink</returns>
    /// <exception cref="WebExtras.Mvc.Core.GumbyThemeException">Thrown when a valid Gumby framework
    /// theme is not selected</exception>
    public static IExtendedHtmlString AsButton<T>(this T html, EGumbyButton type, params EGumbyButtonStyle[] sizeOrstyle) where T : IExtendedHtmlString
    {
      if (WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new GumbyThemeException();

      if (!HtmlStringUtil.CanDisplayAsButton(html))
        throw new InvalidUsageException("The AsButton decorator can only be used with Button and Hyperlink extensions");

      List<string> classes = new List<string>
      { 
        "btn",
        type.ToString().ToLowerInvariant()
      };

      // if a style was specified then don't add the theme class
      EGumbyButtonStyle[] styles = 
      {
        EGumbyButtonStyle.Oval,
        EGumbyButtonStyle.Rounded,
        EGumbyButtonStyle.Squared,
        EGumbyButtonStyle.Pill_Left,
        EGumbyButtonStyle.Pill_Right
      };

      int styleCnt = sizeOrstyle.Where(styles.Contains).Count();

      if (styleCnt == 0)
        classes.Add(WebExtrasMvcConstants.GumbyTheme.ToString().ToLowerInvariant());

      // if no size was specified set as medium
      EGumbyButtonStyle[] sizes = 
      {
        EGumbyButtonStyle.XLarge,
        EGumbyButtonStyle.Large,
        EGumbyButtonStyle.Medium,
        EGumbyButtonStyle.Small
      };

      int sizeCnt = sizeOrstyle.Where(sizes.Contains).Count();

      if (sizeCnt == 0)
        classes.Add("medium");

      Div div = new Div();

      div["class"] = string.Join(" ", classes
        .Concat(sizeOrstyle.Select(s => s.ToString().ToLowerInvariant().Replace('_', '-'))));

      div.Append(html);

      return div;
    }
  }
}
