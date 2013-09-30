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
using System.Text;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// Gumby hyperlink/button decorator
  /// </summary>
  public static class GumbyHtmlStringExtensions
  {
    /// <summary>
    /// Create Gumby buttons
    /// </summary>
    /// <param name="btn">Current HTML button to be restyled</param>
    /// <param name="type">Gumby button type</param>
    /// <param name="style">Gumby button styles</param>
    /// <returns>A Gumby styled button</returns>
    public static IExtendedHtmlString AsButton(this Button btn, EGumbyButton type, params EGumbyButtonStyle[] style)
    {
      return GetButton(btn, type, style);
    }

    /// <summary>
    /// Add Gumby button styling to hyperlinks
    /// </summary>
    /// <param name="link">Current HTML hyperlink to be restyled</param>
    /// <param name="type">Gumby button type</param>
    /// <param name="style">Gumby button styles</param>
    /// <returns>A Gumby button styled hyperlink</returns>
    public static IExtendedHtmlString AsButton(this Hyperlink link, EGumbyButton type, params EGumbyButtonStyle[] style)
    {
      return GetButton(link, type, style);
    }

    /// <summary>
    /// Get a Gumby button styled element
    /// </summary>
    /// <param name="element">HTML element to be styled</param>
    /// <param name="type">Gumby button type</param>
    /// <param name="style">Gumby button styles</param>
    /// <returns>A Gumby button styled element</returns>
    private static IExtendedHtmlString GetButton(IExtendedHtmlString element, EGumbyButton type, EGumbyButtonStyle[] style)
    {
      if (WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new GumbyThemeException();

      string[] classes = new string[] { 
        "btn",
        type.ToString().ToLowerInvariant(),
        WebExtrasMvcConstants.GumbyTheme.ToString().ToLowerInvariant()
      };

      Div div = new Div();

      div["class"] = string.Join(" ", classes.Concat(style.Select(s => s.ToString().ToLowerInvariant())));

      div.Append(element);

      return div;
    }
  }
}
