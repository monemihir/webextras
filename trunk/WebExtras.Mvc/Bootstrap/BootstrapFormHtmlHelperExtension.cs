﻿/*
* This file is part of - Code Library
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
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Twitter bootstrap form HTML helper extensions
  /// </summary>
  public static class BootstrapFormHtmlHelperExtension
  {
    #region IconButton extensions

    /// <summary>
    /// Create a HTML Button control with an icon
    /// </summary>
    /// <param name="html">Current HTMLHelper object</param>
    /// <param name="type">Type of the button control. Valid values are 'regular',
    /// 'submit', 'reset'</param>
    /// <param name="cssClass">CSS class</param>
    /// <param name="id">ID</param>
    /// <param name="value">Value text to display on button</param>
    /// <param name="iconClass">Icon CSS class(s) to be prepended for the link. Multiple icon classes must be separated with
    /// spaces</param>
    /// <param name="onClick">[Optional] Javascript onClick event name. Defaults to null. Note. If button type is 'Submit' or
    /// 'Reset' this onclick event will be ignored and can be null</param>
    /// <param name="htmlAttributes">[Optional] Additional html attributes to apply to the link (BUTTON) object</param>
    /// <returns>HTML Button</returns>
    public static MvcHtmlString IconButton(
      this HtmlHelper html,
      ButtonOfType type,
      string cssClass,
      string id,
      string value,
      string iconClass,
      string onClick = null,
      object htmlAttributes = (IDictionary<string, object>)null)
    {
      string autogenId = string.Format("autogen-{0}", new Random(DateTime.Now.Millisecond).Next(1, 9999).ToString());
      TagBuilder button = new TagBuilder("button");
      button.Attributes["id"] = string.IsNullOrEmpty(id) ? autogenId : id;
      button.InnerHtml = string.Format("<i class='{0}'></i>&nbsp;{1}", iconClass, value);
      onClick = (!string.IsNullOrEmpty(onClick) && onClick.EndsWith("()")) ? onClick : onClick + "()";
      if (!string.IsNullOrEmpty(cssClass))
        button.AddCssClass(cssClass);
      button.Attributes["type"] = (type == ButtonOfType.Regular) ? "button" : type.ToString().ToLower();
      if (type == ButtonOfType.Regular)
        button.Attributes["onclick"] = "javascript:" + onClick;

      button.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      return MvcHtmlString.Create(button.ToString(TagRenderMode.Normal));
    }

    #endregion IconButton extensions

    #region DateTextBoxFor extensions

    /// <summary>
    /// Creates a Bootstrap date picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="dateFormat">Date format</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date picker control</returns>
    public static MvcHtmlString DateTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string dateFormat, object htmlAttributes = (IDictionary<string,object>)null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = GetFieldId(exp);

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker({ pickTime: false }); });";

      MvcHtmlString control = GetDateTimePickerFor(html, expression, dateFormat, htmlAttributes);

      return MvcHtmlString.Create(control.ToHtmlString() + script.ToString(TagRenderMode.Normal));
    }

    #endregion DateTextBoxFor extensions

    #region TimeTextBoxFor extensions

    /// <summary>
    /// Creates a Bootstrap time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="timeFormat">Time format</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date picker control</returns>
    public static MvcHtmlString TimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string timeFormat, object htmlAttributes = (IDictionary<string,object>)null)
    {
      MemberExpression exp = expression.Body as MemberExpression;
      string fieldId = GetFieldId(exp);

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker({ pickDate: false }); });";

      MvcHtmlString control = GetDateTimePickerFor(html, expression, timeFormat, htmlAttributes);

      return MvcHtmlString.Create(control.ToHtmlString() + script.ToString(TagRenderMode.Normal));
    }

    #endregion TimeTextBoxFor extensions

    #region DateTimeTextBoxFor extensions

    /// <summary>
    /// Creates a Bootstrap date time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="dateTimeFormat">Date and Time format</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    public static MvcHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string dateTimeFormat, object htmlAttributes = (IDictionary<string,object>)null)
    {
      MemberExpression exp = expression.Body as MemberExpression;
      string fieldId = GetFieldId(exp);

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(); });";

      MvcHtmlString control = GetDateTimePickerFor(html, expression, dateTimeFormat, htmlAttributes);

      return MvcHtmlString.Create(control.ToHtmlString() + script.ToString(TagRenderMode.Normal));
    }

    #endregion DateTimeTextBoxFor extensions

    #region Misc methods

    /// <summary>
    /// Creates a Bootstrap date time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="dateTimeFormat">Date and Time format</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    private static MvcHtmlString GetDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string dateTimeFormat, object htmlAttributes = (IDictionary<string,object>)null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = GetFieldId(exp);
      string fieldName = GetFieldName(exp);

      // create the text box
      TagBuilder input = new TagBuilder("input");
      input.Attributes["type"] = "text";
      input.Attributes["value"] = ((DateTime)ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model).ToString(dateTimeFormat);
      input.Attributes["data-format"] = dateTimeFormat;
      input.Attributes["name"] = fieldName;
      input.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      // create addon
      TagBuilder addOn = new TagBuilder("span");
      addOn.AddCssClass("add-on");

      TagBuilder icons = new TagBuilder("i");
      icons.Attributes["data-time-icon"] = "icon-time";
      icons.Attributes["data-date-icon"] = "icon-calendar";

      TagBuilder div = new TagBuilder("div");
      div.Attributes["id"] = fieldId;
      div.AddCssClass("input-append");

      addOn.InnerHtml = icons.ToString(TagRenderMode.Normal);
      div.InnerHtml = input.ToString(TagRenderMode.Normal) + addOn.ToString(TagRenderMode.Normal);

      return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
    }

    /// <summary>
    /// Gets the HTML field ID to be applied
    /// </summary>
    /// <param name="expression">Member expression to process</param>
    /// <returns>HTML field ID</returns>
    private static string GetFieldId(MemberExpression expression)
    {
      return string.Join("_", GetComponents(expression));
    }

    /// <summary>
    /// Gets the HTML field Name to be applied
    /// </summary>
    /// <param name="expression">Member expression to process</param>
    /// <returns>HTML field Name</returns>
    private static string GetFieldName(MemberExpression expression)
    {
      return string.Join(".", GetComponents(expression));
    }

    /// <summary>
    /// Gets the usable components from the expression. For eg. f.Model.Member
    /// will return Model and Member as usable components.
    /// </summary>
    /// <param name="expression">Member expression to process</param>
    /// <returns>A collection of components that can be used to make
    /// a field ID or field Name</returns>
    private static IEnumerable<string> GetComponents(MemberExpression expression)
    {
      List<string> components = new List<string>();
      List<string> split = expression.Expression.ToString().Split('.').ToList();

      if (split.Count > 1)
      {
        split.RemoveAt(0);
        components.AddRange(split);
      }

      components.Add(expression.Member.Name);
      return components;
    }

    #endregion Misc methods
  }
}