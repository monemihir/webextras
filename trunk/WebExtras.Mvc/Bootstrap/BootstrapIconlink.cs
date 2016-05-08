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

using WebExtras.Bootstrap;
using WebExtras.Component;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// A bootstrap icon only hyperlink
  /// </summary>
  public class BootstrapIconlink : Hyperlink
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="icon">Icon to be displayed as the hypelink</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional Extra HTML attributes</param>
    public BootstrapIconlink(EBootstrapIcon icon, string url, object htmlAttributes = null) :
      base(string.Empty, url, htmlAttributes)
    {
      CSSClasses.Add("icon-only-link");
      IHtmlComponent iconElement = BootstrapUtil.CreateIcon(icon);

      Prepend(new HtmlElement(iconElement));
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="icon">Icon to be displayed as the hypelink</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional Extra HTML attributes</param>
    public BootstrapIconlink(EFontAwesomeIcon icon, string url, object htmlAttributes = null) :
      base(string.Empty, url, htmlAttributes)
    {
      CSSClasses.Add("icon-only-link");
      IHtmlComponent iconElement = BootstrapUtil.CreateIcon(icon);

      Prepend(new HtmlElement(iconElement));
    }
  }
}
