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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebExtras.Bootstrap.v3;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Html;
using WebExtras.Mvc.Html;

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
    public static IExtendedHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, object htmlAttributes = (IDictionary<string, object>) null)
    {
      return DateTimeTextBoxFor(html, expression, BootstrapSettings.DateTimePickerOptions.DeepClone(), htmlAttributes);
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
    public static IExtendedHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, PickerOptions options,
      object htmlAttributes = (IDictionary<string, object>) null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      PickerOptions pickerOptions =
        options.GetHashCode() == BootstrapSettings.DateTimePickerOptions.GetHashCode()
          ? options.DeepClone()
          : options;

      pickerOptions = pickerOptions.TryFontAwesomeIcons();

      var model = ((DateTime?) ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model);
      if (model.HasValue && model.Value > DateTime.MinValue)
        pickerOptions.defaultDate = model;

      string fieldId = WebExtrasUtil.GetFieldIdFromExpression(exp);
      string fieldName = WebExtrasUtil.GetFieldNameFromExpression(exp);

      // create the text box
      HtmlComponent input = new HtmlComponent(EHtmlTag.Input);
      var attribs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
        .ToDictionary(k => k.Key, v => v.Value.ToString());

      input.Attributes.Add(attribs);
      input.Attributes["type"] = "text";
      input.Attributes["name"] = fieldName;

      if (input.Attributes.ContainsKey("class"))
        input.Attributes["class"] += " form-control";
      else
        input.Attributes["class"] = "form-control";

      // create icon
      HtmlComponent icon = new HtmlComponent(EHtmlTag.I);
      if (WebExtrasSettings.FontAwesomeVersion == EFontAwesomeVersion.V4)
        icon.CssClasses.Add("fa fa-calendar");
      else if (WebExtrasSettings.FontAwesomeVersion == EFontAwesomeVersion.V3)
        icon.CssClasses.Add("icon-calendar");
      else
        icon.CssClasses.Add("glyphicon glyphicon-calendar");

      // create addon
      HtmlComponent addOn = new HtmlComponent(EHtmlTag.Span);
      addOn.CssClasses.Add("input-group-addon");
      addOn.AppendTags.Add(icon);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson(new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

      HtmlComponent script = new HtmlComponent(EHtmlTag.Script);
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      // create the final component
      IHtmlComponent control;
      if (pickerOptions.useAddonField.Equals(false))
      {
        NullWrapperComponent wrapper = new NullWrapperComponent();

        input.Attributes["id"] = fieldId;
        wrapper.Components.Add(input);

        wrapper.Components.Add(script);

        control = wrapper;
      }
      else
      {
        control = new HtmlComponent(EHtmlTag.Div);
        control.Attributes["id"] = fieldId;
        control.Attributes["class"] = "input-group date";
        control.AppendTags.Add(input);
        control.AppendTags.Add(addOn);
        control.AppendTags.Add(script);
      }

      return new HtmlElement(control);
    }

    #endregion DateTimeTextBoxFor extensions
  }
}