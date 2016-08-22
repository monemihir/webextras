// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using WebExtras.Core;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  ///   Generic extension for an extended html string
  /// </summary>
  public static class ExtendedHtmlStringExtension
  {
    /// <summary>
    ///   Adds given CSS class(es) to the current HTML element
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

    /// <summary>
    ///   Sets specified javascript event to the button click action
    /// </summary>
    /// <param name="html">Current button</param>
    /// <param name="javasriptEvent">JavaScript event (normally a user-defined function to be called)</param>
    /// <returns>Updated button</returns>
    public static T WithEvent<T>(this T html, string javasriptEvent) where T : IExtendedHtmlString
    {
      if (string.IsNullOrWhiteSpace(javasriptEvent))
        throw new InvalidUsageException("Invalid javascript event specified");

      string jsEvent = javasriptEvent;

      if (!javasriptEvent.StartsWith("javascript", StringComparison.InvariantCultureIgnoreCase))
        jsEvent = "javascript:" + jsEvent;

      html.Component.Attributes["onclick"] = jsEvent;

      return html;
    }

    /// <summary>
    ///   Sets the button click action to navigate to the given URL
    /// </summary>
    /// <param name="html">Current button</param>
    /// <param name="url">Navigation URL</param>
    /// <returns>Updated button</returns>
    public static T WithNavigation<T>(this T html, string url) where T : IExtendedHtmlString
    {
      string navUrl = string.IsNullOrWhiteSpace(url) ? "#" : url;

      html.Component.Attributes["onclick"] = "window.location='" + navUrl + "'";

      return html;
    }
  }
}