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

using System.Web.Mvc;
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
    public static BootstrapNavBar Navbar(this HtmlHelper html, EBootstrapNavbar type, params IExtendedHtmlString[] items)
    {
      return new BootstrapNavBar(type, items);
    }

    /// <summary>
    /// Create a bootstrap progress bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Progress bar type</param>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A boostrap progress bar</returns>
    public static BootstrapProgressBar ProgressBar(this HtmlHelper html, EBootstrapProgressBar type, int percent, object htmlAttributes = null)
    {
      return new BootstrapProgressBar(type, percent, htmlAttributes);
    }
  }
}
