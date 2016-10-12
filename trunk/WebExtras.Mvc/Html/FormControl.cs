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

using WebExtras.FontAwesome;
using WebExtras.Html;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   A bootstrap form control which allows appending and prepending of elements
  /// </summary>
  public class FormControl<TModel, TValue> : IFormControl<TModel, TValue>
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="component">form component to initalise with</param>
    public FormControl(IFormComponent<TModel, TValue> component)
    {
      Component = component;
    }

    #region Implementation of IFormControl<TModel,TValue>

    /// <summary>
    ///   Underlying HTML component
    /// </summary>
    public IFormComponent<TModel, TValue> Component { get; private set; }

    /// <inheritdoc />
    public IFormControl<TModel, TValue> AddText(bool append = true)
    {
      Component = Component.AddText(append);

      return this;
    }

    /// <summary>
    ///   Add text addon to the form control
    /// </summary>
    /// <param name="text">Text to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormControl<TModel, TValue> AddText(string text, bool append = true)
    {
      Component = Component.AddText(text, append);

      return this;
    }

    /// <summary>
    ///   Add icon addon to the form control
    /// </summary>
    /// <param name="icon">Icon to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormControl<TModel, TValue> AddIcon(EFontAwesomeIcon icon, bool append = true)
    {
      Component = Component.AddIcon(icon, append);

      return this;
    }

    /// <summary>
    ///   Add html addon to the form control
    /// </summary>
    /// <param name="html">HTML to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormControl<TModel, TValue> AddHtml(IExtendedHtmlString html, bool append = true)
    {
      Component = Component.AddHtml(html.Component, append);

      return this;
    }

    #endregion Implementation of IFormControl<TModel,TValue>

    #region Implementation of IHtmlString

    /// <summary>Returns an HTML-encoded string.</summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      return Component.ToHtml();
    }

    #endregion Implementation of IHtmlString
  }
}