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

using Nancy.ViewEngines.Razor;
using WebExtras.Core;
using WebExtras.Html;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  ///   Generic extensions for form elements
  /// </summary>
  public static class FormHelperExtension
  {
    /// <summary>
    ///   Creates a button
    /// </summary>
    /// <param name="html">Current HTML helpers</param>
    /// <param name="text">Button text</param>
    /// <param name="htmlAttributes">[Optional] Any extra html attributes</param>
    /// <returns>A HTML button element</returns>
    public static IExtendedHtmlString Button(this HtmlHelpers html, string text, object htmlAttributes = null)
    {
      return Button(html, EButton.Regular, text, htmlAttributes);
    }

    /// <summary>
    ///   Creates a button
    /// </summary>
    /// <param name="html">Current HTML helpers</param>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="htmlAttributes">[Optional] Any extra html attributes</param>
    /// <returns>A HTML button element</returns>
    public static IExtendedHtmlString Button(this HtmlHelpers html, EButton type, string text, object htmlAttributes = null)
    {
      HtmlComponent component = new HtmlComponent(EHtmlTag.Button, htmlAttributes);
      component.Attributes["type"] = type.GetStringValue();
      component.InnerHtml = text;

      if (type == EButton.Cancel)
        component.Attributes["onclick"] = "javascript:window.history.back()";

      return new ExtendedHtmlString(component);
    }
  }
}