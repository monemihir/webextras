// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
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
using WebExtras.Bootstrap;
using WebExtras.Html;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   Twitter bootstrap form HTML helper extensions
  /// </summary>
  public static class FormHelperExtension
  {
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
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, htmlAttributes);
      UpdateComponent(html, bfc, expression);

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
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, ICollection<string> options, object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      var newOptions = options.Select(f => new SelectListOption {Text = f, Value = f}).ToList();

      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, newOptions,
        htmlAttributes);

      if (newOptions.Any(f => f.Selected))
        UpdateComponent(html, bfc, expression, newOptions.First(f => f.Selected).Value);
      else
        UpdateComponent(html, bfc, expression);

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
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> options, object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      var newOptions = options.Select(f => new SelectListOption(f.Text, f.Value, f.Selected)).ToList();
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, newOptions,
        htmlAttributes);

      if (newOptions.Any(f => f.Selected))
        UpdateComponent(html, bfc, expression, newOptions.First(f => f.Selected).Value);
      else
        UpdateComponent(html, bfc, expression);

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
    public static IFormControl<TModel, TValue> FormGroupControlFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, int rows, int columns, object htmlAttributes = null)
    {
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, rows, columns,
        htmlAttributes);
      UpdateComponent(html, bfc, expression);

      return new FormControl<TModel, TValue>(bfc);
    }

    /// <summary>
    ///   Updates the given component with the current value of the property denoted in the expression and also sets the
    ///   validation state
    /// </summary>
    /// <param name="html">Current <see cref="HtmlHelper" /></param>
    /// <param name="bfc">Form component to set value for</param>
    /// <param name="expression">Model property expression</param>
    /// <param name="value">Value to update component with</param>
    private static void UpdateComponent<TModel, TValue>(this HtmlHelper<TModel> html,
      IBootstrapFormComponent<TModel, TValue> bfc, Expression<Func<TModel, TValue>> expression, string value = "")
    {
      bool isValid = html.IsValidFor(expression);

      if (!isValid)
        bfc.Wrapper.CssClasses.Add("has-error");

      if (!string.IsNullOrEmpty(value))
      {
        bfc.SetValue(value);
        return;
      }

      if (html.ViewData.Model == null)
        return;

      object result = string.Empty;

      try
      {
        result = expression.Compile().DynamicInvoke(html.ViewData.Model);
      }
      catch (Exception)
      {
        // ignore
      }

      bfc.SetValue(result == null ? string.Empty : result.ToString());
    }

    #endregion FormGroupControlFor extensions
  }
}