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
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   Validation HTML helper methods
  /// </summary>
  public static class ValidationHtmlHelperExtension
  {
    #region IsValidFor extensions

    /// <summary>
    ///   Gets the validation state of a property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lambda expression</param>
    /// <returns>True if state is valid, else False</returns>
    public static bool IsValidFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression)
    {
      if (expression == null)
        throw new ArgumentNullException("expression");

      MemberExpression exp = expression.Body as MemberExpression;

      string mname = WebExtrasUtil.GetFieldNameFromExpression(exp);

      bool result = true;
      if (html.ViewData.ModelState.ContainsKey(mname))
        result = !(html.ViewData.ModelState[mname].Errors.Count > 0);

      return result;
    }

    /// <summary>
    ///   Get the validation state of a property
    /// </summary>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="memberName">The member name to be checked</param>
    /// <returns>True if state is valid, else False</returns>
    public static bool IsValidFor(this HtmlHelper html, string memberName)
    {
      bool result = true;
      if (html.ViewData.ModelState.ContainsKey(memberName))
        result = !(html.ViewData.ModelState[memberName].Errors.Count > 0);

      return result;
    }

    #endregion IsValidFor extensions
  }
}