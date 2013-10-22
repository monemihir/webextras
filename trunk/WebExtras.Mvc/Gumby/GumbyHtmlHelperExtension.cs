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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// Gumby HTML extensions
  /// </summary>
  public static class GumbyHtmlHelperExtension
  {
    #region Icon extensions

    /// <summary>
    /// Renders a Gumby icon
    /// </summary>
    /// <param name="html">Current Html helper object</param>
    /// <param name="icon">Gumby icon</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A Gumby icon</returns>
    public static IExtendedHtmlString Icon(this HtmlHelper html, EGumbyIcon icon, object htmlAttributes = null)
    {
      Italic i = new Italic(htmlAttributes);
      i["class"] = "icon-" + icon.ToString().ToLowerInvariant().Replace('_', '-');

      return i;
    }

    #endregion Icon extensions

    #region TooltipFor extensions

    /// <summary>
    /// Create a Gumby tooltip. The tooltip text is retrieved from the
    /// 'Description' attribute for the property
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
      MemberExpression exp = expression.Body as MemberExpression;
      string tooltip = GetTooltipFor(html, expression);

      return TooltipFor(html, expression, tooltip);
    }

    /// <summary>
    /// Create a Gumby tooltip
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
