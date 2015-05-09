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
using System.Linq.Expressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebExtras.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Bootstrap.v3
{
  /// <summary>
  ///   Bootstrap 3 specific form extenions
  /// </summary>
  public static class FormHelperExtension
  {
    #region DateTimeTextBoxFor extensions

    /// <summary>
    ///   Creates a Bootstrap date time picker control with default datetime picker
    ///   options. See also <see cref="M:BootstrapConstants.DateTimePickerOptions" /> to
    ///   set default options.
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

      var model = ((DateTime?) ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model);
      if (model.HasValue && model.Value > DateTime.MinValue)
        pickerOptions.defaultDate = model;

      string fieldId = WebExtrasMvcUtil.GetFieldIdFromExpression(exp);
      string fieldName = WebExtrasMvcUtil.GetFieldNameFromExpression(exp);

      // create the text box
      TagBuilder input = new TagBuilder("input");
      input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
      input.Attributes["type"] = "text";
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
      else if (WebExtrasMvcConstants.FontAwesomeVersion == EFontAwesomeVersion.V3)
        icons.AddCssClass("icon-calendar");
      else
        icons.AddCssClass("glyphicon glyphicon-calendar");

      TagBuilder control = new TagBuilder("div");
      control.Attributes["id"] = fieldId;
      control.Attributes["class"] = "input-group date";

      addOn.InnerHtml = icons.ToString(TagRenderMode.Normal);
      control.InnerHtml = input.ToString(TagRenderMode.SelfClosing) + addOn.ToString(TagRenderMode.Normal);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson(new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      return MvcHtmlString.Create(control.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }

    #endregion DateTimeTextBoxFor extensions
  }
}