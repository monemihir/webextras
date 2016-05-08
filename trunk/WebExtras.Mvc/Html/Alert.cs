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

using WebExtras.Bootstrap;
using WebExtras.Component;
using WebExtras.Core;
using WebExtras.Gumby;
using WebExtras.Mvc.JQueryUI;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Denotes an alert
  /// </summary>
  public class Alert : HtmlElement
  {
    /// <summary>
    ///   The alert type
    /// </summary>
    public EMessage Type { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    public Alert(EMessage type, string message, object htmlAttributes = null)
      : this(type, message, string.Empty, (EFontAwesomeIcon?) null, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    public Alert(EMessage type, string message, string title, object htmlAttributes = null)
      : this(type, message, title, (EFontAwesomeIcon?) null, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    public Alert(EMessage type, string message, string title, EFontAwesomeIcon? icon, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      IExtendedHtmlString i = (icon != null) ? BootstrapUtil.CreateIcon(icon.Value).ToHtmlElement() : null;

      CreateAlert(type, message, title, i);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    public Alert(EMessage type, string message, string title, EBootstrapIcon? icon, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      IExtendedHtmlString i = (icon != null) ? BootstrapUtil.CreateIcon(icon.Value).ToHtmlElement() : null;

      CreateAlert(type, message, title, i);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    public Alert(EMessage type, string message, string title, EJQueryUIIcon? icon, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      IExtendedHtmlString i = (icon != null) ? JQueryUIUtil.CreateIcon(icon.Value) : null;

      CreateAlert(type, message, title, i);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    public Alert(EMessage type, string message, string title, EGumbyIcon? icon, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      IExtendedHtmlString i = (icon != null) ? GumbyUtil.CreateIcon(icon.Value).ToHtmlElement() : null;

      CreateAlert(type, message, title, i);
    }

    /// <summary>
    ///   Creates an alert
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    private void CreateAlert(EMessage type, string message, string title, IExtendedHtmlString icon)
    {
      CSSClasses.Add(type.GetStringValue());

      HtmlComponent bc = new HtmlComponent(EHtmlTag.B)
      {
        InnerHtml = title ?? string.Empty
      };

      if (icon != null)
        bc.PrependTags.Add(icon.Component);

      Bold b = new Bold(bc);

      if (WebExtrasConstants.CssFramework != ECssFramework.JQueryUI)
      {
        CSSClasses.Add("alert");

        Button closeBtn = new Button(EButton.Regular, "&times;", string.Empty);
        closeBtn.CSSClasses.Add("close");
        closeBtn["data-dismiss"] = "alert";

        Prepend(closeBtn);
        Prepend(b);
        InnerHtml = (!string.IsNullOrWhiteSpace(title) || icon != null)
          ? WebExtrasConstants.HTMLSpace + message
          : message;
      }
      else
      {
        Div div = new Div();

        switch (type)
        {
          case EMessage.Error:
            div.CSSClasses.Add("ui-state-error");
            break;

          case EMessage.Information:
          case EMessage.Warning:
            div.CSSClasses.Add("ui-state-highlight");
            break;

          case EMessage.Success:
            div.CSSClasses.Add("ui-state-success");
            break;
        }

        div.CSSClasses.Add("ui-corner-all");
        div.Prepend(b);
        div.InnerHtml = (!string.IsNullOrWhiteSpace(title) || icon != null)
          ? WebExtrasConstants.HTMLSpace + message
          : message;

        Prepend(div);
      }

      Type = type;
    }
  }
}