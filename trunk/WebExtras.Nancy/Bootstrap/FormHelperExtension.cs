// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
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
using Nancy.ViewEngines.Razor;
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
      IHtmlComponent control = new DateTimePickerHtmlComponent(name, name, BootstrapConstants.DateTimePickerOptions, htmlAttributes);

      return new ExtendedHtmlString(control);
    }

    /// <summary>
    ///   Creates a Bootstrap date time picker control
    /// </summary>
    /// <param name="html">HtmlHelper extension</param>
    /// <param name="name">Name of HTML control</param>
    /// <param name="options">
    ///   [Optional] Date time picker options. Defaults to
    ///   <see cref="BootstrapConstants.DateTimePickerOptions" />
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
      return html.DateTimeTextBoxFor<TModel, TValue>(expression, BootstrapConstants.DateTimePickerOptions, htmlAttributes);
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
      FormComponent<TModel, TValue> bfc = new FormComponent<TModel, TValue>(expression, htmlAttributes);

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

      var newOptions = options.Select(f => new SelectListOption { Text = f, Value = f });

      FormComponent<TModel, TValue> bfc = new FormComponent<TModel, TValue>(expression, newOptions,
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
      Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListOption> options, object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      var newOptions = options.Select(f => new SelectListOption(f.Text, f.Value, f.Selected));
      FormComponent<TModel, TValue> bfc = new FormComponent<TModel, TValue>(expression, newOptions, htmlAttributes);

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
      FormComponent<TModel, TValue> bfc = new FormComponent<TModel, TValue>(expression, rows, columns, htmlAttributes);

      return new FormControl<TModel, TValue>(bfc);
    }

    #endregion FormGroupControlFor extensions
  }
}