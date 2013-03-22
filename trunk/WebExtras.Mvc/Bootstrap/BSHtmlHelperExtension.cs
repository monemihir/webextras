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
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap Html Helper extension methods
  /// </summary>
  public static class BSHtmlHelperExtension
  {
    /// <summary>
    /// Renders a Bootstrap icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <returns>A Bootstrap icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, BootstrapIcon icon)
    {
      Italic i = new Italic();
      i["class"] = "icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-");

      return i;
    }

    /// <summary>
    /// Create a bootstrap navigation bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A bootstrap navigation bar</returns>
    public static BootstrapNavBar Navbar(this HtmlHelper html, BootstrapNavbarType type, params IExtendedHtmlString[] items)
    {
      return new BootstrapNavBar(type, items);
    }
  }
}
