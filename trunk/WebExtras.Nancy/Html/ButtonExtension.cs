// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using WebExtras.Core;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  ///   Generic extensions for HTML button elements
  /// </summary>
  public static class ButtonExtension
  {
    /// <summary>
    ///   Sets specified javascript event to the button click action
    /// </summary>
    /// <param name="btn">Current button</param>
    /// <param name="javasriptEvent">JavaScript event (normally a user-defined function to be called)</param>
    /// <returns>Updated button</returns>
    public static Button WithEvent(this Button btn, string javasriptEvent)
    {
      if (string.IsNullOrWhiteSpace(javasriptEvent))
        throw new InvalidUsageException("Invalid javascript event specified");

      string jsEvent = javasriptEvent;

      if (!javasriptEvent.StartsWith("javascript", StringComparison.InvariantCultureIgnoreCase))
        jsEvent = "javascript:" + jsEvent;

      btn.Component.Attributes["onclick"] = jsEvent;

      return btn;
    }

    /// <summary>
    ///   Sets the button click action to navigate to the given URL
    /// </summary>
    /// <param name="btn">Current button</param>
    /// <param name="url">Navigation URL</param>
    /// <returns>Updated button</returns>
    public static Button WithNavigation(this Button btn, string url)
    {
      string navUrl = string.IsNullOrWhiteSpace(url) ? "#" : url;

      btn.Component.Attributes["onclick"] = "window.location='" + navUrl + "'";

      return btn;
    }
  }
}