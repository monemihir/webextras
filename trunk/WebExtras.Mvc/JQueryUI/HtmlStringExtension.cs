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

using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.JQueryUI
{
  /// <summary>
  /// jQuery UI hyperlink/button decorators
  /// </summary>
  public static class HtmlStringExtension
  {
    #region AddIcon extension

    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>    
    /// <returns>Html element with icon added</returns>
    public static T AddIcon<T>(this T html, EJQueryUIIcon icon, object htmlAttributes = null) where T : IExtendedHtmlString
    {
      Span s = new Span(htmlAttributes);
      s.AddCssClass("ui-icon");
      s.AddCssClass("ui-icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-"));

      html.Prepend(s);

      return html;
    }

    #endregion AddIcon extension
  }
}
