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
using System.Linq.Expressions;
using Nancy.ViewEngines.Razor;
using WebExtras.Bootstrap.v3;
using WebExtras.Component;
using WebExtras.Core;
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

    public static IExtendedHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelpers html,
      Expression<Func<TModel, TValue>> expression,
      object htmlAttributes)
    {
      return html.DateTimeTextBoxFor<TModel, TValue>(expression, BootstrapConstants.DateTimePickerOptions, htmlAttributes);
    }

    public static IExtendedHtmlString DateTimeTextBoxFor<TModel, TValue>(this HtmlHelpers html,
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
  }
}