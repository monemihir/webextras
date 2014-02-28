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
using WebExtras.Mvc.Bootstrap;
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Denotes an alert
  /// </summary>
  public class Alert : HtmlElement
  {
    /// <summary>
    /// The alert type
    /// </summary>
    public EMessage Type { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    public Alert(EMessage type, string message, object htmlAttributes = null)
      : this(type, message, string.Empty, null as EFontAwesomeIcon?, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    public Alert(EMessage type, string message, string title, object htmlAttributes = null)
      : this(type, message, title, null as EFontAwesomeIcon?, htmlAttributes)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    public Alert(EMessage type, string message, string title, EFontAwesomeIcon? icon, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      this.AddCssClass("alert");
      this.AddCssClass(type.GetStringValue());

      Button closeBtn = new Button(EButton.Regular, "&times;", string.Empty);
      closeBtn.AddCssClass("close");
      closeBtn["data-dismiss"] = "alert";

      Bold b = new Bold();
      if (icon.HasValue)
      {
        IExtendedHtmlString i = BootstrapIconUtil.Create(icon.Value);
        b.Prepend(i);
      }

      b.InnerHtml = title ?? string.Empty;

      Prepend(closeBtn);
      Prepend(b);
      InnerHtml = (!string.IsNullOrWhiteSpace(title) || icon.HasValue) ? WebExtrasMvcConstants.HTMLSpace + message : message;

      Type = type;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">[Optional] Any extras HTML attributes to be applied. 
    /// Note. These attributes are only applied to the top level div</param>
    public Alert(EMessage type, string message, string title, EBootstrapIcon? icon, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      this.AddCssClass("alert");
      this.AddCssClass(type.GetStringValue());

      Button closeBtn = new Button(EButton.Regular, "&times;", string.Empty);
      closeBtn.AddCssClass("close");
      closeBtn["data-dismiss"] = "alert";

      Bold b = new Bold();
      if (icon.HasValue)
      {
        IExtendedHtmlString i = BootstrapIconUtil.Create(icon.Value);
        b.Prepend(i);
      }

      b.InnerHtml = title ?? string.Empty;

      Prepend(closeBtn);
      Prepend(b);
      InnerHtml = (!string.IsNullOrWhiteSpace(title) || icon.HasValue) ? WebExtrasMvcConstants.HTMLSpace + message : message;

      Type = type;
    }
  }
}
