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

using System.Web.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.JQueryUI
{
  /// <summary>
  /// JQuery UI form helper extensions
  /// </summary>
  public static class FormHtmlHelperExtension
  {
    /// <summary>
    /// Default date picker options
    /// </summary>
    private static readonly IDictionary<string, object> DefaultDatePickerOptions = new Dictionary<string, object>
    { 
      { "dateFormat", "yy-mm-dd" }
    };

    /// <summary>
    /// Default time picker options
    /// </summary>
    private static readonly IDictionary<string, object> DefaultTimePickerOptions = new Dictionary<string, object>
    { 
      { "timeFormat", "hh:mm" }
    };

    #region Date/Time picker extensions

    /// <summary>
    /// Creates a JQuery UI date picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">[Optional] Date picker options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes to be applied to the text box</param>
    /// <returns>A jQuery UI date picker control</returns>
    public static MvcHtmlString DateTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object options = null, object htmlAttributes = null)
    {
      // parse the picker options
      IDictionary<string, object> pickerOptions = DefaultDatePickerOptions.Merge(new RouteValueDictionary(options), true);

      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = string.Join("_", GetComponents(exp));
      string fieldName = string.Join(".", GetComponents(exp));
      string dateFormat = GetCSharpDateFormat(pickerOptions["dateFormat"].ToString());

      // create the text box
      TagBuilder input = GetInputFieldTag(html, expression, dateFormat, fieldName, fieldId, htmlAttributes);

      // create the enclosing SPAN
      TagBuilder container = GetContainerTag(fieldId, "ui-datepicker-container", input);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson();

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datepicker(" + op + "); });";

      return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    /// <summary>
    /// Creates a JQuery UI date time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">[Optional] Time picker options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes to be applied to the text box</param>
    /// <returns>A jQuery UI date time picker control</returns>
    public static MvcHtmlString TimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object options = null, object htmlAttributes = null)
    {
      // parse the picker options
      IDictionary<string, object> pickerOptions = DefaultTimePickerOptions.Merge(new RouteValueDictionary(options), true);

      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = string.Join("_", GetComponents(exp));
      string fieldName = string.Join(".", GetComponents(exp));
      string timeFormat = pickerOptions["timeFormat"].ToString();

      // create the text box
      TagBuilder input = GetInputFieldTag(html, expression, timeFormat, fieldName, fieldId, htmlAttributes);

      // create the enclosing SPAN
      TagBuilder container = GetContainerTag(fieldId, "ui-timepicker-container", input);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson();

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').timepicker(" + op + "); });";

      return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    /// <summary>
    /// Creates a JQuery UI time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">[Optional] Date and time picker options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes to be applied to the text box</param>
    /// <returns>A jQuery UI time picker control</returns>
    public static MvcHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object options = null, object htmlAttributes = null)
    {
      // parse the picker options
      IDictionary<string, object> pickerOptions = DefaultDatePickerOptions
        .Merge(DefaultTimePickerOptions)
        .Merge(new RouteValueDictionary(options), true);

      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = string.Join("_", GetComponents(exp));
      string fieldName = string.Join(".", GetComponents(exp));
      string dateFormat = GetCSharpDateFormat(pickerOptions["dateFormat"].ToString());
      string timeFormat = pickerOptions["timeFormat"].ToString();
      
      // create the text box
      TagBuilder input = GetInputFieldTag(html, expression, dateFormat + " " + timeFormat, fieldName, fieldId, htmlAttributes);

      // create the enclosing SPAN
      TagBuilder container = GetContainerTag(fieldId, "ui-datepicker-container ui-timepicker-container", input);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson();

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    #endregion Date/Time picker extensions

    #region Helper methods

    /// <summary>
    /// Get the container tag enclosing the INPUT datetime textbox
    /// </summary>
    /// <param name="fieldId">Field ID</param>
    /// <param name="fieldCssClass">Field CSS class</param>
    /// <param name="input">The datetime INPUT tag</param>
    /// <returns>A SPAN enclosing the INPUT tag</returns>
    private static TagBuilder GetContainerTag(string fieldId, string fieldCssClass, TagBuilder input)
    {
      TagBuilder control = new TagBuilder("span");
      control.Attributes["class"] = fieldCssClass;
      control.Attributes["id"] = fieldId + "-container";
      control.InnerHtml = input.ToString(TagRenderMode.SelfClosing);
      return control;
    }

    /// <summary>
    /// Get the INPUT tag for the textbox
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="dateTimeFormat">The date and/or time format to be used to convert datetime property value</param>
    /// <param name="fieldName">Field name</param>
    /// <param name="fieldId">Field ID</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>An INPUT tag for the date/time text box</returns>
    private static TagBuilder GetInputFieldTag<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string dateTimeFormat, string fieldName, string fieldId, object htmlAttributes)
    {
      TagBuilder input = new TagBuilder("input");
      input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
      input.Attributes["type"] = "text";
      input.Attributes["value"] = ((DateTime) ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model).ToString(dateTimeFormat);
      input.Attributes["name"] = fieldName;
      input.Attributes["id"] = fieldId;
      return input;
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

    /// <summary>
    /// Convert the given JS format to it's equivalent CSharp format
    /// </summary>
    /// <param name="jsformat">JavaScript date format</param>
    /// <returns>Equivalent CSharp date format</returns>
    private static string GetCSharpDateFormat(string jsformat)
    {
      char[] parts = jsformat.ToCharArray();
      string csFormat = new string(parts);

      int uMnthCount = parts.Count(f => f == 'M');
      switch (uMnthCount)
      {
        case 1:
          csFormat = csFormat.Replace("M", "MMM");
          break;
        case 2:
          csFormat = csFormat.Replace("MM", "MMMM");
          break;
      }

      int lMnthCount = parts.Count(f => f == 'm');
      switch (lMnthCount)
      {
        case 1:
          csFormat = csFormat.Replace("m", "M");
          break;

        case 2:
          csFormat = csFormat.Replace("mm", "MM");
          break;
      }

      int yearCount = parts.Count(f => f == 'y');
      switch (yearCount)
      {
        case 1:
          csFormat = csFormat.Replace("y", "yy");
          break;

        case 2:
          csFormat = csFormat.Replace("yy", "yyyy");
          break;
      }

      return csFormat;
    }

    #endregion Helper methods
  }
}
