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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap Html Helper extension methods
  /// </summary>
  public static class BSHtmlHelperExtension
  {
    /// <summary>
    /// Renders a Bootstrap icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EBootstrapIcon icon, object htmlAttributes = null)
    {
      Italic i = new Italic();
      i["class"] = "icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-");

      return i;
    }

    /// <summary>
    /// Renders a Bootstrap Font-Awesome icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EFontAwesomeIcon icon, object htmlAttributes)
    {
      return Icon(html, icon, EFontAwesomeIconSize.Normal, htmlAttributes);
    }

    /// <summary>
    /// Renders a Bootstrap Font-Awesome icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <param name="size">Icon size</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>A Bootstrap icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, object htmlAttributes = null)
    {
      Italic i = new Italic();
      i["class"] = "icon-" + icon.ToString().ToLowerInvariant().Replace("_", "-") + " icon-" + size.GetStringValue();

      i.Tag.MergeAttributes<string, object>(new RouteValueDictionary(htmlAttributes));

      return i;
    }

    /// <summary>
    /// Create a bootstrap navigation bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    /// <returns>A bootstrap navigation bar</returns>
    public static BootstrapNavBar Navbar(this HtmlHelper html, EBootstrapNavbar type, params IExtendedHtmlString[] items)
    {
      return new BootstrapNavBar(type, items);
    }

    /// <summary>
    /// Create a bootstrap progress bar
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">Progress bar type</param>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A boostrap progress bar</returns>
    public static BootstrapProgressBar ProgressBar(this HtmlHelper html, EBootstrapProgressBar type, int percent, object htmlAttributes = null)
    {
      return new BootstrapProgressBar(type, percent, htmlAttributes);
    }

    #region TooltipFor extensions

    /// <summary>
    /// Create a Bootstrap tooltip. The tooltip text is retrieved from the
    /// 'Description' attribute for the property
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
    /// Create a Bootstrap tooltip
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
      MemberExpression exp = expression.Body as MemberExpression;
      string tooltip = GetTooltipFor(html, expression);

      return TooltipFor(html, expression, tooltipText, "right", "hover");
    }

    /// <summary>
    /// Create a Bootstrap tooltip. The tooltip text is retrieved from the
    /// 'Description' attribute for the property
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
      MemberExpression exp = expression.Body as MemberExpression;
      string tooltip = GetTooltipFor(html, expression);

      return TooltipFor(html, expression, tooltip, placement, trigger);
    }

    /// <summary>
    /// Creates a Bootstrap tooltip
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
      MemberExpression exp = expression.Body as MemberExpression;
      string fieldId = exp.Member.Name + "_tip";

      TagBuilder i = new TagBuilder("i");
      i.AddCssClass("icon-info-sign");
      i.AddCssClass("help-inline");
      i.Attributes["id"] = fieldId;

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$('#" + fieldId + "').tooltip({ title: '" + tooltipText + "', placement: '" + placement + "', trigger: '" + trigger + "' });";

      return MvcHtmlString.Create(i.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    /// <summary>
    /// Get the 'Description' attribute text for the given property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lambda expression</param>
    /// <returns>Tooltip text to be displayed</returns>
    private static string GetTooltipFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
    {
      string tooltip = null;
      MemberExpression exp = expression.Body as MemberExpression;
      if (exp != null)
      {
        DescriptionAttribute descAtt = exp.Member.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();
        tooltip = (descAtt == null) ? null : descAtt.Description;
      }
      else
        tooltip = string.Empty;
      return tooltip;
    }

    #endregion TooltipFor extensions
  }
}
