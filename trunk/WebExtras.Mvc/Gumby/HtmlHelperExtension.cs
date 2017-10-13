// 
// This file is part of - WebExtras
// Copyright 2017 Mihir Mone
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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Gumby;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  ///   Gumby HTML extensions
  /// </summary>
  public static class HtmlHelperExtension
  {
    #region Icon extensions

    /// <summary>
    ///   Renders a Gumby icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Gumby icon</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A Gumby icon</returns>
    public static IExtendedHtmlStringLegacy Icon(this HtmlHelper html, EGumbyIcon icon, object htmlAttributes = null)
    {
      return GumbyUtil.CreateIcon(icon, htmlAttributes).ToHtmlElement();
    }

    #endregion Icon extensions

    #region TooltipFor extensions

    /// <summary>
    ///   Create a Gumby tooltip. The tooltip text is retrieved from the
    ///   'Description' attribute for the property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <returns>Gumby tooltip attached</returns>
    public static MvcHtmlString TooltipFor<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression)
    {
      string tooltip = GetTooltipFor(html, expression);

      return TooltipFor(html, expression, tooltip);
    }

    /// <summary>
    ///   Create a Gumby tooltip
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="tooltipText">Tooltip text</param>
    /// <returns>Gumby tooltip attached</returns>
    public static MvcHtmlString TooltipFor<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression,
      string tooltipText)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      if (exp == null)
        throw new ArgumentNullException("expression");

      string fieldId = exp.Member.Name + "_tip";

      TagBuilder span = new TagBuilder("span");
      span.Attributes["class"] = "ttip";
      span.Attributes["id"] = fieldId;
      span.Attributes["data-tooltip"] = tooltipText == string.Empty ? "No tooltip defined" : tooltipText;

      TagBuilder i = new TagBuilder("i");
      i.Attributes["class"] = "icon-info-circled";
      i.Attributes["title"] = string.Empty;
      i.Attributes["alt"] = string.Empty;

      span.InnerHtml = i.ToString();

      return MvcHtmlString.Create(span.ToString());
    }

    /// <summary>
    ///   Get the 'Description' attribute text for the given property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lambda expression</param>
    /// <returns>Tooltip text to be displayed</returns>
    private static string GetTooltipFor
      <TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
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

    #region Navbar extensions

    /// <summary>
    ///   Create a navigation bar
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A navigation bar</returns>
    public static GumbyNavbar Navbar(this HtmlHelper html, HtmlList items)
    {
      return new GumbyNavbar(items);
    }

    /// <summary>
    ///   Create a navigation bar
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="logoLink">Navigation bar logo link</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A navigation bar</returns>
    public static GumbyNavbar Navbar(this HtmlHelper html, Hyperlink logoLink, HtmlList items)
    {
      return new GumbyNavbar(logoLink, items);
    }

    /// <summary>
    ///   Create a navigation bar
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A navigation bar</returns>
    public static GumbyNavbar Navbar(this HtmlHelper html, params Hyperlink[] items)
    {
      return new GumbyNavbar(items);
    }

    #endregion Navbar extensions

    #region Alert extensions

    /// <summary>
    ///   Renders a Gumby alert
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="type">Type of alert</param>
    /// <param name="message">Alert message</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Any extras HTML attributes to be applied.
    ///   Note. These attributes are only applied to the top level div
    /// </param>
    /// <returns>A Bootstrap styled alert</returns>
    public static IExtendedHtmlString Alert(this HtmlHelper html, EMessage type, string message,
      object htmlAttributes = null)
    {
      return Alert(html, type, message, string.Empty, null, htmlAttributes);
    }

    /// <summary>
    ///   Renders a Gumby alert
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
      return Alert(html, type, message, title, null, htmlAttributes);
    }

    /// <summary>
    ///   Renders a Gumby alert
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
    public static IExtendedHtmlString Alert(this HtmlHelper html, EMessage type, string message, string title,
      EGumbyIcon? icon, object htmlAttributes = null)
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
    public static IExtendedHtmlString Hyperlink(this HtmlHelper html, EGumbyIcon icon, string url,
      object htmlAttributes = null)
    {
      return new GumbyIconLink(icon, url, htmlAttributes);
    }

    #endregion Hyperlink extensions
  }
}