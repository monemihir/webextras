﻿// 
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

using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Gumby;
using WebExtras.Html;
using WebExtras.JQueryUI;
using WebExtras.Mvc.JQueryUI;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Denotes an alert
  /// </summary>
  public class Alert : HtmlComponent, IExtendedHtmlString
  {
    /// <summary>
    ///   The alert type
    /// </summary>
    public EMessage Type { get; private set; }

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
      : this(type, message, string.Empty, (EFontAwesomeIcon?)null, htmlAttributes)
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
      : this(type, message, title, (EFontAwesomeIcon?)null, htmlAttributes)
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
      IHtmlComponent i = (icon != null) ? BootstrapUtil.CreateIcon(icon.Value) : null;

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
      IHtmlComponent i = (icon != null) ? BootstrapUtil.CreateIcon(icon.Value) : null;

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
      IHtmlComponent i = (icon != null) ? JQueryUIUtil.CreateIcon(icon.Value) : null;

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
      IHtmlComponent i = (icon != null) ? GumbyUtil.CreateIcon(icon.Value) : null;

      CreateAlert(type, message, title, i);
    }

    /// <summary>
    ///   Creates an alert
    /// </summary>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    private void CreateAlert(EMessage type, string message, string title, IHtmlComponent icon)
    {
      CssClasses.Add(type.GetStringValue());

      HtmlComponent bc = new HtmlComponent(EHtmlTag.B)
      {
        InnerHtml = title ?? string.Empty
      };

      if (icon != null)
        bc.PrependTags.Add(icon);
      
      if (WebExtrasSettings.CssFramework != ECssFramework.JQueryUI)
      {
        CssClasses.Add("alert");

        Button closeBtn = new Button(EButton.Regular, "&times;", string.Empty);
        closeBtn.CssClasses.Add("close");
        closeBtn.Attributes["data-dismiss"] = "alert";

        PrependTags.Add(closeBtn);
        PrependTags.Add(bc);
        InnerHtml = (!string.IsNullOrWhiteSpace(title) || icon != null)
          ? WebExtrasSettings.HTMLSpace + message
          : message;
      }
      else
      {
        HtmlComponent div = new HtmlComponent(EHtmlTag.Div);

        switch (type)
        {
          case EMessage.Error:
            div.CssClasses.Add("ui-state-error");
            break;

          case EMessage.Information:
          case EMessage.Warning:
            div.CssClasses.Add("ui-state-highlight");
            break;

          case EMessage.Success:
            div.CssClasses.Add("ui-state-success");
            break;
        }

        div.CssClasses.Add("ui-corner-all");
        div.PrependTags.Add(bc);
        div.InnerHtml = (!string.IsNullOrWhiteSpace(title) || icon != null)
          ? WebExtrasSettings.HTMLSpace + message
          : message;

        PrependTags.Add(div);
      }

      Type = type;
    }

    /// <inheritdoc />
    public string ToHtmlString()
    {
      return ToHtml();
    }

    /// <inheritdoc />
    public IHtmlComponent Component { get { return this; } }
  }
}