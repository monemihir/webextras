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

using WebExtras.Component;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  /// Generic extension for an extended html string
  /// </summary>
  public static class ExtendedHtmlStringExtension
  {
    /// <summary>
    /// Adds given CSS class(es) to the current HTML element
    /// </summary>
    /// <param name="html">HTML element to add class to</param>
    /// <param name="css">CSS class(es) to be added</param>
    /// <returns>Current HTML element with classes added</returns>
    public static T AddCssClass<T>(this T html, string css) where T : IExtendedHtmlString
    {
      if (!string.IsNullOrWhiteSpace(css))
        html.Component.CssClasses.AddRange(css.Trim().Split(' '));

      return html;
    }
  }
}
