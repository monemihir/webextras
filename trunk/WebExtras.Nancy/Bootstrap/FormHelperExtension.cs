﻿// 
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
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using Nancy.ViewEngines.Razor;
using WebExtras.Bootstrap;
using WebExtras.Bootstrap.v3;
using WebExtras.Core;
using WebExtras.Html;
using WebExtras.Nancy.Html;

namespace WebExtras.Nancy.Bootstrap
{
  /// <summary>
  ///   Form helper extensions
  /// </summary>
  public static class FormHelperExtension
  {
    #region DateTimeTextBoxFor extensions

    /// <summary>
    ///   Creates a Bootstrap date time picker control
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="name">Name of HTML control</param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    public static IExtendedHtmlString DateTimeTextBox(this HtmlHelpers html,
      string name,
      object htmlAttributes = null)
    {
      IHtmlComponent control = new DateTimePickerHtmlComponent(name, name, BootstrapSettings.DateTimePickerOptions,
        htmlAttributes);

      return new ExtendedHtmlString(control);
    }

    /// <summary>
    ///   Creates a Bootstrap date time picker control
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="name">Name of HTML control</param>
    /// <param name="options">
    ///   [Optional] Date time picker options. Defaults to
    ///   <see cref="BootstrapSettings.DateTimePickerOptions" />
    /// </param>
    /// <param name="htmlAttributes">Extra HTML attributes to be applied to the text box</param>
    /// <returns>A Bootstrap date time picker control</returns>
    public static IExtendedHtmlString DateTimeTextBox(this HtmlHelpers html,
      string name, PickerOptions options = null,
      object htmlAttributes = null)
    {
      IHtmlComponent control = new DateTimePickerHtmlComponent(name, name, options, htmlAttributes);

      return new ExtendedHtmlString(control);
    }

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
    public static IExtendedHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression,
      object htmlAttributes)
    {
      return html.DateTimeTextBoxFor(expression, BootstrapSettings.DateTimePickerOptions, htmlAttributes);
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
    public static IExtendedHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression,
      PickerOptions options, object htmlAttributes)
    {
      MemberExpression mex = expression.Body as MemberExpression;

      string id = WebExtrasUtil.GetFieldIdFromExpression(mex);
      string name = WebExtrasUtil.GetFieldNameFromExpression(mex);

      IHtmlComponent control = new DateTimePickerHtmlComponent(name, id, options, htmlAttributes);

      return new ExtendedHtmlString(control);
    }

    #endregion DateTimeTextBoxFor extensions

    #region FormGroupControlFor extensions

    /// <summary>
    ///   Create a bootstrap form group control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="expression">Member expression</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>The created form control</returns>
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, htmlAttributes);

      return new FormControl<TModel, TValue>(bfc);
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
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression, ICollection<string> options, object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      var newOptions = options.Select(f => new HtmlSelectListOption {Text = f, Value = f});

      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, newOptions,
        htmlAttributes);

      return new FormControl<TModel, TValue>(bfc);
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
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression, IEnumerable<HtmlSelectListOption> options,
      object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      var newOptions = options.Select(f => new HtmlSelectListOption(f.Text, f.Value, f.Selected));
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, newOptions,
        htmlAttributes);

      return new FormControl<TModel, TValue>(bfc);
    }

    /// <summary>
    ///   Create a bootstrap textarea form group control
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="expression">Member expression</param>
    /// <param name="rows">No. of rows</param>
    /// <param name="columns">No. of columns</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>The created form control</returns>
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression, int rows, int columns, object htmlAttributes = null)
    {
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, rows, columns,
        htmlAttributes);

      return new FormControl<TModel, TValue>(bfc);
    }

    #endregion FormGroupControlFor extensions

    #region Button extensions

    /// <summary>
    ///   Create a bootstrap button of given type
    /// </summary>
    /// <param name="html">Current element</param>
    /// <param name="types">Bootstrap button types</param>
    /// <returns>Updated button</returns>
    public static T AsButton<T>(this T html, params EBootstrapButton[] types) where T : IExtendedHtmlString
    {
      if (html.Component.Tag != EHtmlTag.Button && html.Component.Tag != EHtmlTag.A)
        throw new InvalidUsageException("The AsButton extension can only be used for buttons and hyperlink elements");

      string cssClasses = string.Join(" ", types.Select(t => t.GetStringValue()));

      ExtendedHtmlStringExtension.AddCssClass(html, cssClasses);

      return html;
    }

    #endregion Button extensions

    #region AddIcon extensions

    /// <summary>
    ///   Prepends an icon to the current element
    /// </summary>
    /// <param name="html">Current HTML helpers</param>
    /// <param name="icon">Bootstrap icon</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>HTML element with icon added</returns>
    public static T AddIcon<T>(this T html, EBootstrapIcon icon, object htmlAttributes = null)
      where T : IExtendedHtmlString
    {
      return AddIcon(html, new[] {icon.GetStringValue()}, htmlAttributes);
    }

    /// <summary>
    ///   Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
    /// <param name="cssClasses">Css classes to be added</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>HTML element with icon added</returns>
    private static T AddIcon<T>(T html, IEnumerable<string> cssClasses, object htmlAttributes = null)
      where T : IExtendedHtmlString
    {
      NameValueCollection rvd = WebExtrasUtil.AnonymousObjectToHtmlAttributes(htmlAttributes);

      List<string> finalClasses = new List<string>(cssClasses);

      if (rvd.ContainsKey("class"))
      {
        finalClasses.AddRange(rvd["class"].Split(' '));
        rvd.Remove("class");
      }

      HtmlComponent i = new HtmlComponent(EHtmlTag.I);
      i.CssClasses.AddRange(finalClasses);

      foreach (string key in rvd.Keys)
        i.Attributes[key] = rvd[key];

      // TODO: remove unnecessary conversion
      html.Component.PrependTags.Add(i);

      if (html.Component.Attributes.ContainsKey("style"))
        html.Component.Attributes["style"] += ";text-decoration:none";
      else
        html.Component.Attributes["style"] = "text-decoration:none";

      return html;
    }

    #endregion AddIcon extensions
  }
}