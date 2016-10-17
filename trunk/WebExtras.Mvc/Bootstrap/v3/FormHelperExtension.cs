// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2015 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebExtras.Bootstrap;
using WebExtras.Bootstrap.v3;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Html;
using WebExtras.Mvc.Core;
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
      HtmlElement input = new HtmlElement(EHtmlTag.Input);
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
      Span addOn = new Span();
      addOn.CSSClasses.Add("input-group-addon");

      // TODO: remove unnecessary conversion
      addOn.Append(icon.ToHtmlElement());

      Div control = new Div();
      control.Attributes["id"] = fieldId;
      control.Attributes["class"] = "input-group date";
      control.Append(input);
      control.Append(addOn);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson(new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

      HtmlElement script = new HtmlElement(EHtmlTag.Script);
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      control.Append(script);

      return control;
    }

    #endregion DateTimeTextBoxFor extensions
  }
}