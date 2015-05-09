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
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   Twitter bootstrap form HTML helper extensions
  /// </summary>
  public static class BSFormHtmlHelperExtension
  {
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
      return DateTimeTextBoxFor(html, expression, WebExtrasMvcConstants.BootstrapDateTimePickerOptions, htmlAttributes);
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
      Expression<Func<TModel, TValue>> expression, DateTimePicker.PickerOptions options,
      object htmlAttributes = (IDictionary<string, object>) null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      DateTimePicker.PickerOptions dateTimePickerOptions = options.DeepClone();

      var model = ((DateTime?)ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model);
      if (model.HasValue && model.Value > DateTime.MinValue)
        dateTimePickerOptions.defaultDate = model;

      string fieldId = WebExtrasMvcUtil.GetFieldIdFromExpression(exp);
      string fieldName = WebExtrasMvcUtil.GetFieldNameFromExpression(exp);

      // create the text box
      TagBuilder input = new TagBuilder("input");
      input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
      input.Attributes["type"] = "text";

      //input.Attributes["value"] =
      //  ((DateTime)ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model).ToString(dateTimeFormat);
      input.Attributes["name"] = fieldName;

      if (input.Attributes.ContainsKey("class"))
        input.Attributes["class"] += " form-control";
      else
        input.Attributes["class"] = "form-control";

      // create addon
      TagBuilder addOn = new TagBuilder("span");
      addOn.AddCssClass("input-group-addon");

      TagBuilder icons = new TagBuilder("i");

      if (WebExtrasMvcConstants.FontAwesomeVersion == EFontAwesomeVersion.V4)
        icons.AddCssClass("fa fa-calendar");
      else
        icons.AddCssClass("icon-calendar glyphicon glyphicon-calendar");

      TagBuilder control = new TagBuilder("div");
      control.Attributes["id"] = fieldId;
      control.Attributes["class"] = "input-append input-group date form_datetime";

      addOn.InnerHtml = icons.ToString(TagRenderMode.Normal);
      control.InnerHtml = input.ToString(TagRenderMode.SelfClosing) + addOn.ToString(TagRenderMode.Normal);

      // create JSON dictionary of the picker options
      string op = dateTimePickerOptions.ToJson(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      return MvcHtmlString.Create(control.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    #endregion DateTimeTextBoxFor extensions

    #region FormGroupControl extensions

    /// <summary>
    ///   Create a bootstrap form group control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="expression">Member expression</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>The created form control</returns>
    public static IFormControl<TModel, TValue> FormGroupControl<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
      BootstrapFormControl<TModel, TValue> bfc = new BootstrapFormControl<TModel, TValue>(expression, htmlAttributes);

      return bfc;
    }

    /// <summary>
    ///   Create a bootstrap select form group control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="expression">Member expression</param>
    /// <param name="options">Select list options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>The created form control</returns>
    public static IFormControl<TModel, TValue> FormGroupControl<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, ICollection<string> options, object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      BootstrapFormControl<TModel, TValue> bfc = new BootstrapFormControl<TModel, TValue>(expression, options.ToArray(),
        htmlAttributes);

      return bfc;
    }

    #endregion FormGroupControl extensions
  }
}