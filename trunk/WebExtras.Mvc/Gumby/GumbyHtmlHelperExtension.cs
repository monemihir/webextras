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
using System.Web.Mvc;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// Gumby HTML extensions
  /// </summary>
  public static class GumbyHtmlHelperExtension
  {
    /// <summary>
    /// Renders a Gumby icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Gumby icon</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A Gumby icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EGumbyIcon icon, object htmlAttributes = null)
    {
      Italic i = new Italic(htmlAttributes);
      i["class"] = "icon-" + icon.ToString().ToLowerInvariant().Replace('_', '-');

      return i;
    }
  }
}
