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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WebExtras.Mvc.JQueryUI
{
  /// <summary>
  /// JQuery UI form helper extensions
  /// </summary>
  public static class JUIFormHelperExtension
  {
    /// <summary>
    /// Default date time picker options
    /// </summary>
    private static readonly IDictionary<string, object> DefaultPickerOptions = new Dictionary<string, object>() { 
      { "dateFormat", "yy-mm-dd" }
    };

    /// <summary>
    /// Creates a JQuery UI date picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date picker control</returns>
    public static MvcHtmlString DateTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, DatePickerOptions options = null, object htmlAttributes = (IDictionary<string,object>)null)
    {
      IDictionary<string, object> mOptions = (options != null) ? options.ToDictionary() : new Dictionary<string, object>();
      
      // parse the picker options
      IDictionary<string, object> pickerOptions = MergeOptions(mOptions);

      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = string.Join("_", GetComponents(exp));
      string fieldName = string.Join(".", GetComponents(exp));
      string dateFormat = ConvertToCsDateFormat(pickerOptions["dateFormat"].ToString());

      // create the text box
      TagBuilder input = new TagBuilder("input");
      input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
      input.Attributes["type"] = "text";
      input.Attributes["value"] = ((DateTime)ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model).ToString(dateFormat);
      input.Attributes["name"] = fieldName;
      input.Attributes["id"] = fieldId;

      TagBuilder control = new TagBuilder("span");
      control.Attributes["class"] = "ui-datepicker-container";
      control.Attributes["id"] = fieldId + "-container";
      control.InnerHtml = input.ToString(TagRenderMode.SelfClosing);

      // create JSON dictionary of the picker options
      string op = JsonConvert.SerializeObject(pickerOptions);

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datepicker(" + op + "); });";

      return MvcHtmlString.Create(control.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    /// <summary>
    /// Merge picker options
    /// </summary>
    /// <param name="options">Picker options to be merged</param>
    /// <returns>Merged options</returns>
    private static IDictionary<string, object> MergeOptions(ICollection<KeyValuePair<string, object>> options)
    {
      IDictionary<string, object> result = new Dictionary<string, object>(DefaultPickerOptions);

      if (options != null && options.Count > 0)
        foreach (var kv in options)
          result[kv.Key] = kv.Value;

      return result;
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
    private static string ConvertToCsDateFormat(string jsformat)
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
  }
}
