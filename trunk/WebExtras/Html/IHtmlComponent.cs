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

using System.Collections.Generic;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   A generic interface implemented by HTML components
  /// </summary>
  public interface IHtmlComponent : IHtmlRenderer
  {
    /// <summary>
    ///   The HTML tag representing this component
    /// </summary>
    EHtmlTag Tag { get; }

    /// <summary>
    ///   CSS classes of this component
    /// </summary>
    CssClassList CssClasses { get; }

    /// <summary>
    ///   HTML attribute list for this component
    /// </summary>
    IDictionary<string, string> Attributes { get; }

    /// <summary>
    ///   Inner HTML of the component
    /// </summary>
    string InnerHtml { get; set; }

    /// <summary>
    ///   Tags to appended to the current component. Note these tags are
    ///   appended before the <see cref="InnerHtml" /> when the component
    ///   gets serialized to a HTML string
    /// </summary>
    HtmlComponentList PrependTags { get; }

    /// <summary>
    ///   Tags to appended to the current component. Note these tags are
    ///   appended after the <see cref="InnerHtml" /> when the component
    ///   gets serialized to a HTML string
    /// </summary>
    HtmlComponentList AppendTags { get; }
  }
}