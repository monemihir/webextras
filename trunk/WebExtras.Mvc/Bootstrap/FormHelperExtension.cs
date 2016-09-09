// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2016 Mihir Mone
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
using WebExtras.Bootstrap;
using WebExtras.Html;
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
      SetComponentValue(html, bfc, expression);

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

      var newOptions = options.Select(f => new SelectListOption { Text = f, Value = f });

      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, newOptions,
        htmlAttributes);
      SetComponentValue(html, bfc, expression);

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

      var newOptions = options.Select(f => new SelectListOption(f.Text, f.Value, f.Selected));
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, newOptions, htmlAttributes);
      SetComponentValue(html, bfc, expression);

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
      BootstrapFormComponent<TModel, TValue> bfc = new BootstrapFormComponent<TModel, TValue>(expression, rows, columns, htmlAttributes);
      SetComponentValue(html, bfc, expression);

      return new FormControl<TModel, TValue>(bfc);
    }

    /// <summary>
    ///   Sets the value of the given component with the current value of the property denoted in the expression
    /// </summary>
    /// <param name="html">Current <see cref="HtmlHelper" /></param>
    /// <param name="bfc">Form component to set value for</param>
    /// <param name="expression">Model property expression</param>
    private static void SetComponentValue<TModel, TValue>(this HtmlHelper<TModel> html, IBootstrapFormComponent<TModel, TValue> bfc, Expression<Func<TModel, TValue>> expression)
    {
      if (html.ViewData.Model == null)
        return;

      var result = expression.Compile().DynamicInvoke(html.ViewData.Model);

      bfc.SetValue(result == null ? string.Empty : result.ToString());
    }

    #endregion FormGroupControlFor extensions
  }
}