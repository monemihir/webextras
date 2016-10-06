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
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   ModelStateDictionary extension class to add custom/server side validation errors
  /// </summary>
  public static class ModelStateDictionaryExtension
  {
    /// <summary>
    ///   ModelStateDictionary extension method which adds custom/server side validation errors for display by MVC
    /// </summary>
    /// <param name="modelState">ModelStateDictionary object</param>
    /// <param name="errors">NameValueCollection of errors: key=property name, value=error message</param>
    /// <param name="keyPrefix">
    ///   a string to prefix the final key, used for child objects i.e
    ///   ProfileViewModel.User.SecretQuestion
    /// </param>
    public static void AddModelErrors(
      this ModelStateDictionary modelState,
      NameValueCollection errors,
      string keyPrefix = "")
    {
      if (errors == null || errors.Count == 0)
        return;

      keyPrefix = string.IsNullOrEmpty(keyPrefix) ? "" : keyPrefix + ".";

      foreach (string key in errors.Keys)
        modelState.AddModelError(keyPrefix + key, errors[key]);
    }

    /// <summary>
    ///   Get property errors
    /// </summary>
    /// <typeparam name="TModel">Model type</typeparam>
    /// <param name="modelstate">Current model state dictionary</param>
    /// <param name="expression">Property selector</param>
    /// <returns>Property errors if found, else null</returns>
    /// <exception cref="ArgumentNullException">If expression is null</exception>
    public static ModelState GetPropertyErrorsFor<TModel>(this ModelStateDictionary modelstate,
      Expression<Func<TModel>> expression)
    {
      if (expression == null)
        throw new ArgumentNullException("expression");

      string key = WebExtrasUtil.GetFieldNameFromExpression(expression.Body as MemberExpression);

      if (modelstate.ContainsKey(key))
        return modelstate[key];

      return null;
    }

    /// <summary>
    ///   Ignore validation errors for given properties
    /// </summary>
    /// <typeparam name="TModel">Model type</typeparam>
    /// <param name="modelstate">Current model state dictionary</param>
    /// <param name="expression">Property selectors</param>
    public static void IgnoreErrorsFor<TModel>(this ModelStateDictionary modelstate,
      params Expression<Func<TModel, object>>[] expression)
    {
      if (expression == null)
        return;

      if (expression.Length == 0)
        return;

      Array.ForEach(expression,
        f => modelstate.Remove(WebExtrasUtil.GetFieldNameFromExpression(f.Body as MemberExpression)));
    }
  }
}