// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   Bootstrap Html Helper extension methods
  /// </summary>
  public static class HtmlHelperExtension
  {
    #region Icon extensions

    /// <summary>
    ///   Renders a Bootstrap icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    /// <exception cref="BootstrapVersionException">
    ///   Thrown when a valid Bootstrap version
    ///   is not selected
    /// </exception>
    public static IExtendedHtmlStringLegacy Icon(this HtmlHelper html, EBootstrapIcon icon, object htmlAttributes = null)
    {
      return BootstrapUtil.CreateIcon(icon, htmlAttributes).ToHtmlElement();
    }

    /// <summary>
    ///   Renders a Bootstrap Font-Awesome icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    public static IExtendedHtmlStringLegacy Icon(this HtmlHelper html, EFontAwesomeIcon icon, object htmlAttributes)
    {
      return Icon(html, icon, EFontAwesomeIconSize.Normal, htmlAttributes);
    }

    /// <summary>
    ///   Renders a Bootstrap Font-Awesome icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">Icon size</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    /// <exception cref="FontAwesomeVersionException">
    ///   Thrown when a valid FontAwesome
    ///   icon library version is not selected
    /// </exception>
    public static IExtendedHtmlStringLegacy Icon(this HtmlHelper html, EFontAwesomeIcon icon,
      EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null)
    {
      return BootstrapUtil.CreateIcon(icon, size, htmlAttributes).ToHtmlElement();
    }

    #endregion Icon extensions

    #region Navbar extension

    /// <summary>
    ///   Create a navigation bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A navigation bar</returns>
    public static BootstrapNavBar Navbar(this HtmlHelper html, EBootstrapNavbar type, params Hyperlink[] items)
    {
      return new BootstrapNavBar(type, items);
    }

    /// <summary>
    ///   Create a navigation bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Navigation bar type</param>
    /// <param name="brandLink">Navigation bar brand link</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A navigation bar</returns>
    public static BootstrapNavBar Navbar(this HtmlHelper html, EBootstrapNavbar type, Hyperlink brandLink,
      HtmlList items)
    {
      return new BootstrapNavBar(type, brandLink, items);
    }

    /// <summary>
    ///   Create a navigation bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A navigation bar</returns>
    public static BootstrapNavBar Navbar(this HtmlHelper html, EBootstrapNavbar type, HtmlList items)
    {
      return new BootstrapNavBar(type, items);
    }

    #endregion Navbar extension

    #region ProgressBar extension

    /// <summary>
    ///   Create a bootstrap progress bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Progress bar type</param>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="srText">[Optional] Custom text to be displayed in progress bar. Defaults to percentage complete</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A boostrap progress bar</returns>
    public static BootstrapProgressBar ProgressBar(this HtmlHelper html, EBootstrapProgressBar type, int percent,
      string srText = null,
      object htmlAttributes = null)
    {
      return new BootstrapProgressBar(type, percent, srText, htmlAttributes);
    }

    #endregion ProgressBar extension

    #region TooltipFor extensions

    /// <summary>
    ///   Create a Bootstrap tooltip. The tooltip text is retrieved from the
    ///   'Description' attribute for the property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <returns>Bootstrap tooltip attached</returns>
    public static MvcHtmlString TooltipFor<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression)
    {
      return TooltipFor(html, expression, "right", "hover");
    }

    /// <summary>
    ///   Create a Bootstrap tooltip
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="tooltipText">Tooltip text</param>
    /// <returns>Bootstrap tooltip attached</returns>
    public static MvcHtmlString TooltipFor<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression,
      string tooltipText)
    {
      return TooltipFor(html, expression, tooltipText, "right", "hover");
    }

    /// <summary>
    ///   Create a Bootstrap tooltip. The tooltip text is retrieved from the
    ///   'Description' attribute for the property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="placement">[Optional] Placement of the tooltip relative to the help icon</param>
    /// <param name="trigger">[Optional] Trigger mechanism for the tooltip. Valid values: click, hover, focus</param>
    /// <returns>Bootstrap tooltip attached</returns>
    public static MvcHtmlString TooltipFor<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression,
      string placement,
      string trigger)
    {
      string tooltip = GetTooltipFor(html, expression);

      return TooltipFor(html, expression, tooltip, placement, trigger);
    }

    /// <summary>
    ///   Creates a Bootstrap tooltip
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="tooltipText">Tooltip text</param>
    /// <param name="placement">[Optional] Placement of the tooltip relative to the help icon</param>
    /// <param name="trigger">[Optional] Trigger mechanism for the tooltip. Valid values: click, hover, focus</param>
    /// <returns>Bootstrap tooltip attached</returns>
    public static MvcHtmlString TooltipFor<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression,
      string tooltipText,
      string placement,
      string trigger)
    {
      if (expression == null)
        throw new ArgumentNullException("expression");

      MemberExpression exp = (MemberExpression) expression.Body;

      string fieldId = exp.Member.Name + "_tip";

      TagBuilder i = new TagBuilder("i");

      switch (WebExtrasSettings.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          i.AddCssClass("icon-info-sign");
          break;
        case EBootstrapVersion.V3:
          i.AddCssClass("glyphicon glyphicon-info-sign");
          break;
        default:
          throw new BootstrapVersionException();
      }

      i.AddCssClass("help-inline");
      i.Attributes["id"] = fieldId;
      i.Attributes["data-toggle"] = "tooltip";
      i.Attributes["data-original-title"] = tooltipText;
      i.Attributes["data-placement"] = placement;
      i.Attributes["data-trigger"] = trigger;

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$('#" + fieldId + "').tooltip();";

      return MvcHtmlString.Create(i.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    /// <summary>
    ///   Get the 'Description' attribute text for the given property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lambda expression</param>
    /// <returns>Tooltip text to be displayed</returns>
    private static string GetTooltipFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression)
    {
      string tooltip;
      MemberExpression exp = expression.Body as MemberExpression;
      if (exp != null)
      {
        DescriptionAttribute descAtt = exp.Member
          .GetCustomAttributes(typeof(DescriptionAttribute), false)
          .Cast<DescriptionAttribute>()
          .FirstOrDefault();

        tooltip = (descAtt == null) ? null : descAtt.Description;
      }
      else
        tooltip = string.Empty;
      return tooltip;
    }

    #endregion TooltipFor extensions

    #region Alert extensions

    /// <summary>
    ///   Renders a Bootstrap alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    /// <returns>A Bootstrap styled alert</returns>
    public static IExtendedHtmlString Alert(this HtmlHelper html, EMessage type, string message, object htmlAttributes = null)
    {
      return Alert(html, type, message, string.Empty, (EBootstrapIcon?) null, htmlAttributes);
    }

    /// <summary>
    ///   Renders a Bootstrap alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    /// <returns>A Bootstrap styled alert</returns>
    public static IExtendedHtmlString Alert(this HtmlHelper html, EMessage type, string message, string title,
      object htmlAttributes = null)
    {
      return Alert(html, type, message, title, (EBootstrapIcon?) null, htmlAttributes);
    }

    /// <summary>
    ///   Renders a Bootstrap alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    /// <returns>A Bootstrap styled alert</returns>
    public static IExtendedHtmlString Alert(this HtmlHelper html, EMessage type, string message, string title, EFontAwesomeIcon? icon,
      object htmlAttributes = null)
    {
      return new ExtendedHtmlString(new Alert(type, message, title, icon, htmlAttributes));
    }

    /// <summary>
    ///   Renders a Bootstrap alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="title">Title/Heading of the alert</param>
    /// <param name="icon">Icon to be rendered with title/heading</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    /// <returns>A Bootstrap styled alert</returns>
    public static IExtendedHtmlString Alert(this HtmlHelper html, EMessage type, string message, string title, EBootstrapIcon? icon,
      object htmlAttributes = null)
    {
      return new ExtendedHtmlString(new Alert(type, message, title, icon, htmlAttributes));
    }

    #endregion Alert extensions

    #region Hyperlink extensions
    
    /// <summary>
    ///   Create a icon only link
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="icon">Icon to display</param>
    /// <param name="url">Link action</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A icon only link</returns>
    public static IExtendedHtmlString Hyperlink(this HtmlHelper html, EBootstrapIcon icon, string url,
      object htmlAttributes = null)
    {
      return new BootstrapIconlink(icon, url, htmlAttributes);
    }

    /// <summary>
    ///   Create a icon only link
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="icon">Icon to display</param>
    /// <param name="url">Link action</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A icon only link</returns>
    public static IExtendedHtmlString Hyperlink(this HtmlHelper html, EFontAwesomeIcon icon, string url,
      object htmlAttributes = null)
    {
      return new BootstrapIconlink(icon, url, htmlAttributes);
    }

    #endregion Hyperlink extensions
  }
}