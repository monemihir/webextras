// 
// This file is part of - WebExtras
// Copyright (C) 2015 Mihir Mone
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Bootstrap.v2
{
  /// <summary>
  ///   Twitter bootstrap form HTML helper extensions
  /// </summary>
  public static class FormHtmlHelperExtension
  {
    //#region DateTextBoxFor extensions

    ///// <summary>
    /////   Creates a Bootstrap date picker control
    ///// </summary>
    ///// <typeparam name="TModel">Type to be scanned</typeparam>
    ///// <typeparam name="TValue">Property to be scanned</typeparam>
    ///// <param name="html">HtmlHelper extension</param>
    ///// <param name="expression">The property lamba expression</param>
    ///// <param name="options">Date time picker options</param>
    ///// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    ///// <returns>A Bootstrap date picker control</returns>
    //public static MvcHtmlString DateTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
    //  Expression<Func<TModel, TValue>> expression, object options = (IDictionary<string, object>) null,
    //  object htmlAttributes = (IDictionary<string, object>) null)
    //{
    //  // parse the picker options
    //  IDictionary<string, object> pickerOptions = DefaultPickerOptions.Merge(new RouteValueDictionary(options), true);
    //  pickerOptions["minView"] = 2; // this is a date only picker to set the min view to month

    //  return GetDateTimePickerFor(html, expression, pickerOptions, htmlAttributes);
    //}

    //#endregion DateTextBoxFor extensions

    //#region TimeTextBoxFor extensions

    ///// <summary>
    /////   Creates a Bootstrap time picker control
    ///// </summary>
    ///// <typeparam name="TModel">Type to be scanned</typeparam>
    ///// <typeparam name="TValue">Property to be scanned</typeparam>
    ///// <param name="html">HtmlHelper extension</param>
    ///// <param name="expression">The property lamba expression</param>
    ///// <param name="options">Date time picker options</param>
    ///// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    ///// <returns>A Bootstrap date picker control</returns>
    //public static MvcHtmlString TimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
    //  Expression<Func<TModel, TValue>> expression, object options = (IDictionary<string, object>) null,
    //  object htmlAttributes = (IDictionary<string, object>) null)
    //{
    //  // parse the picker options
    //  IDictionary<string, object> pickerOptions = DefaultPickerOptions.Merge(new RouteValueDictionary(options), true);
    //  pickerOptions["maxView"] = 0; // this is a time only picker so set the max view to day
    //  pickerOptions["startView"] = 1; // this is a time only picker so start with the hour view

    //  return GetDateTimePickerFor(html, expression, pickerOptions, htmlAttributes);
    //}

    //#endregion TimeTextBoxFor extensions

    #region DateTimeTextBoxFor extensions

    /// <summary>
    ///   Creates a Bootstrap date time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    public static MvcHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, object htmlAttributes = (IDictionary<string, object>) null)
    {
      return DateTimeTextBoxFor(html, expression, BootstrapConstants.DateTimePickerOptions.DeepClone(), htmlAttributes);
    }

    /// <summary>
    ///   Creates a Bootstrap date time picker control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    public static MvcHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, PickerOptions options,
      object htmlAttributes = (IDictionary<string, object>) null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      PickerOptions pickerOptions =
        options.GetHashCode() == BootstrapConstants.DateTimePickerOptions.GetHashCode()
          ? options.DeepClone()
          : options;

      pickerOptions = pickerOptions.UpdateOptionsBasedOnView();

      string fieldId = WebExtrasMvcUtil.GetFieldIdFromExpression(exp);
      string fieldName = WebExtrasMvcUtil.GetFieldNameFromExpression(exp);
      string datetimeformat = ConvertToCsDateFormat(pickerOptions.format);

      // create the text box
      TagBuilder input = new TagBuilder("input");
      input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
      input.Attributes["type"] = "text";
      input.Attributes["value"] =
        ((DateTime) ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model).ToString(datetimeformat);
      input.Attributes["name"] = fieldName;

      if (input.Attributes.ContainsKey("class"))
        input.Attributes["class"] += " form-control";
      else
        input.Attributes["class"] = "form-control";

      // create addon
      TagBuilder addOn = new TagBuilder("span");
      addOn.AddCssClass("add-on");

      TagBuilder icons = new TagBuilder("i");
      icons.AddCssClass("icon-calendar");

      TagBuilder control = new TagBuilder("div");
      control.Attributes["id"] = fieldId;
      control.Attributes["class"] = "input-append date form_datetime";

      addOn.InnerHtml = icons.ToString(TagRenderMode.Normal);
      control.InnerHtml = input.ToString(TagRenderMode.SelfClosing) + addOn.ToString(TagRenderMode.Normal);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson();

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      return MvcHtmlString.Create(control.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    #endregion DateTimeTextBoxFor extensions

    #region Misc methods

    /// <summary>
    ///   Convert the given JS format to it's equivalent CSharp format
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

      csFormat = csFormat.Replace('i', 'm');

      // toggle the 'h' and 'H' from the JS date format
      csFormat = csFormat.Replace('h', '$');
      csFormat = csFormat.Replace('H', 'h');
      csFormat = csFormat.Replace('$', 'H');

      // convert meridian notification from 'p' to 't'
      csFormat = csFormat.Replace('p', 't');
      csFormat = csFormat.Replace('P', 't');

      return csFormat;
    }

    #endregion Misc methods
  }
}