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

using System.ComponentModel;
using WebExtras.FontAwesome;

namespace WebExtras.Html
{
  /// <summary>
  ///   Generic interface implemented by form control elements
  /// </summary>
  /// <typeparam name="TModel">Type to be scanned</typeparam>
  /// <typeparam name="TValue">Property to be scanned</typeparam>
  public interface IFormComponent<TModel, TValue> : IHtmlRenderer
  {
    /// <summary>
    ///   Adds text based on any <see cref="DisplayNameAttribute" /> decorated on the property, otherwise just uses the
    ///   property name
    /// </summary>
    /// <param name="append">[Optional] Whether to append or prepend the text</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddText(bool append = true);

    /// <summary>
    ///   Add text addon to the form control
    /// </summary>
    /// <param name="text">Text to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddText(string text, bool append = true);

    /// <summary>
    ///   Add icon addon to the form control
    /// </summary>
    /// <param name="icon">Icon to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddIcon(EFontAwesomeIcon icon, bool append = true);

    /// <summary>
    ///   Add html addon to the form control
    /// </summary>
    /// <param name="html">HTML to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddHtml(IHtmlComponent html, bool append = true);

    /// <summary>
    ///   Set the value for this component
    /// </summary>
    /// <param name="value">Value to be set</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> SetValue(string value);
  }
}