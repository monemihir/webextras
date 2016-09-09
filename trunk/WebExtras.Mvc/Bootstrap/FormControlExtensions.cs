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

using WebExtras.Bootstrap;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   <see cref="IFormControl{TModel,TValue}" />
  /// </summary>
  public static class FormControlExtensions
  {
    /// <summary>
    ///   Changes render behavior to add on
    /// </summary>
    /// <returns>The updated form control</returns>
    public static IFormControl<TModel, TValue> WithAddonBehavior<TModel, TValue>(
      this IFormControl<TModel, TValue> control)
    {
      IBootstrapFormComponent<TModel, TValue> component = control.Component as IBootstrapFormComponent<TModel, TValue>;
      if (component == null)
        return control;

      component.WithAddonBehavior();

      return control;
    }

    /// <summary>
    ///   Changes render behavior to add on
    /// </summary>
    /// <returns>The updated form control</returns>
    public static IFormControl<TModel, TValue> WithDefaultBehavior<TModel, TValue>(
      this IFormControl<TModel, TValue> control)
    {
      IBootstrapFormComponent<TModel, TValue> component = control.Component as IBootstrapFormComponent<TModel, TValue>;
      if (component == null)
        return control;

      component.WithDefaultBehavior();

      return control;
    }
  }
}