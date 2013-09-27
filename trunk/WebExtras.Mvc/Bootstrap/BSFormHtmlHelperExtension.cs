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

using MoreLinq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Twitter bootstrap form HTML helper extensions
  /// </summary>
  public static class BSFormHtmlHelperExtension
  {
    /// <summary>
    /// Default date time picker options
    /// </summary>
    private static readonly IDictionary<string, object> defaultPickerOptions = new Dictionary<string, object>() { 
      { "format", "dd M yyyy" },
      { "autoclose" , true },
      { "todayBtn", true },
      { "todayHighlight", true },
      { "pickerPosition", "bottom-left" }
    };

    #region DateTextBoxFor extensions

    /// <summary>
    /// Creates a Bootstrap date picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date picker control</returns>
    public static MvcHtmlString DateTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object options = (IDictionary<string,object>)null, object htmlAttributes = (IDictionary<string,object>)null)
    {
      // parse the picker options
      IDictionary<string, object> pickerOptions = MergeOptions(new RouteValueDictionary(options));
      pickerOptions["minView"] = 2;      // this is a date only picker to set the min view to month

      return GetDateTimePickerFor(html, expression, pickerOptions, htmlAttributes);
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
    /// <param name="options">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date picker control</returns>
    public static MvcHtmlString TimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object options = (IDictionary<string,object>)null, object htmlAttributes = (IDictionary<string,object>)null)
    {
      // parse the picker options
      IDictionary<string, object> pickerOptions = MergeOptions(new RouteValueDictionary(options));
      pickerOptions["maxView"] = 0;     // this is a time only picker so set the max view to day
      pickerOptions["startView"] = 1;   // this is a time only picker so start with the hour view

      return GetDateTimePickerFor(html, expression, pickerOptions, htmlAttributes);
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
    /// <param name="options">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    public static MvcHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object options = (IDictionary<string,object>)null, object htmlAttributes = (IDictionary<string,object>)null)
    {
      // parse the picker options
      IDictionary<string, object> pickerOptions = MergeOptions(new RouteValueDictionary(options));

      return GetDateTimePickerFor(html, expression, pickerOptions, htmlAttributes);
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
    /// <param name="pickerOptions">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    private static MvcHtmlString GetDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> pickerOptions, object htmlAttributes = (IDictionary<string,object>)null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      string fieldId = string.Join("_", GetComponents(exp));
      string fieldName = string.Join(".", GetComponents(exp));
      string datetimeformat = ConvertToCSDateFormat(pickerOptions["format"].ToString());

      // create the text box
      TagBuilder input = new TagBuilder("input");
      input.Attributes["type"] = "text";
      input.Attributes["value"] = ((DateTime)ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model).ToString(datetimeformat);
      input.Attributes["name"] = fieldName;
      input.Attributes["class"] = "form-control";
      input.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      // create addon
      TagBuilder addOn = new TagBuilder("span");
      addOn.AddCssClass("add-on input-group-addon");

      TagBuilder icons = new TagBuilder("i");
      icons.AddCssClass("icon-calendar");

      TagBuilder control = new TagBuilder("div");
      control.Attributes["id"] = fieldId;
      control.Attributes["class"] = "input-append input-group date form_datetime";

      addOn.InnerHtml = icons.ToString(TagRenderMode.Normal);
      control.InnerHtml = input.ToString(TagRenderMode.SelfClosing) + addOn.ToString(TagRenderMode.Normal);

      // create JSON dictionary of the picker options
      string op = JsonConvert.SerializeObject(pickerOptions);

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      return MvcHtmlString.Create(control.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
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
    /// Merge picker options
    /// </summary>
    /// <param name="options">Picker options to be merged</param>
    /// <returns>Merged options</returns>
    private static IDictionary<string, object> MergeOptions(IDictionary<string, object> options)
    {
      IDictionary<string, object> result = new Dictionary<string, object>(defaultPickerOptions);

      if (options != null && options.Count > 0)
        options.ForEach(f => { result[f.Key] = f.Value; });
          
      return result;
    }

    /// <summary>
    /// Convert the given JS format to it's equivalent CSharp format
    /// </summary>
    /// <param name="jsformat">JavaScript date format</param>
    /// <returns>Equivalent CSharp date format</returns>
    private static string ConvertToCSDateFormat(string jsformat)
    {
      char[] parts = jsformat.ToCharArray();
      string cs_format = new string(parts);

      int uMnthCount = parts.Count(f => f == 'M');
      switch (uMnthCount)
      {
        case 1:
          cs_format = cs_format.Replace("M", "MMM");
          break;
        case 2:
          cs_format = cs_format.Replace("MM", "MMMM");
          break;
        default: break;
      }

      int lMnthCount = parts.Count(f => f == 'm');
      switch (lMnthCount)
      {
        case 1:
          cs_format = cs_format.Replace("m", "M");
          break;

        case 2:
          cs_format = cs_format.Replace("mm", "MM");
          break;

        default: break;
      }

      cs_format = cs_format.Replace('i', 'm');

      // toggle the 'h' and 'H' from the JS date format
      cs_format = cs_format.Replace('h', '$');
      cs_format = cs_format.Replace('H', 'h');
      cs_format = cs_format.Replace('$', 'H');

      // convert meridian notification from 'p' to 't'
      cs_format = cs_format.Replace('p', 't');
      cs_format = cs_format.Replace('P', 't');

      return cs_format;
    }

    #endregion Misc methods
  }
}