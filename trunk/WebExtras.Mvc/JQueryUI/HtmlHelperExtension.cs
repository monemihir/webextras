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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Bootstrap;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.JQueryUI
{
  /// <summary>
  /// JQuery UI Html helper extension methods
  /// </summary>
  public static class HtmlHelperExtension
  {
    #region Icon extensions

    /// <summary>
    /// Renders a JQuery UI icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">JQuery UI icon</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A JQuery UI icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EJQueryUIIcon icon, object htmlAttributes = null)
    {
      return Icon(html, icon, EJQueryUIIconType.Default, htmlAttributes);
    }

    /// <summary>
    /// Renders a JQuery UI icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">JQuery UI icon</param>
    /// <param name="type">JQUery UI icon type</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A JQuery UI icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EJQueryUIIcon icon, EJQueryUIIconType type, object htmlAttributes = null)
    {
      Span s = new Span(htmlAttributes);
      s.AddCssClass("ui-icon");
      s.AddCssClass(string.Format("ui-icon-{0}", icon.ToString().ToLowerInvariant().Replace("_", "-")));
      s.AddCssClass(type.GetStringValue());

      return s;
    }

    #endregion Icon extensions

    #region Alert extensions

    /// <summary>
    /// Renders a jQuery UI alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    /// <returns>A jQuery UI styled alert</returns>
    public static Alert Alert(this HtmlHelper html, EMessage type, string message, object htmlAttributes = null)
    {
      return Alert (html, type, message, string.Empty, (EJQueryUIIcon?)null, htmlAttributes);
    }

    /// <summary>
    /// Renders a jQuery UI alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    /// <returns>A jQuery UI styled alert</returns>
    public static Alert Alert(this HtmlHelper html, EMessage type, string message, string title, object htmlAttributes = null)
    {
      return Alert (html, type, message, title, (EJQueryUIIcon?)null, htmlAttributes);
    }

    /// <summary>
    /// Renders a jQuery UI alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    /// <returns>A jQuery UI styled alert</returns>
    public static Alert Alert(this HtmlHelper html, EMessage type, string message, string title, EJQueryUIIcon? icon, object htmlAttributes = null)
    {
      return new Alert(type, message, title, icon, htmlAttributes);
    }

    #endregion Alert extensions
  }
}
