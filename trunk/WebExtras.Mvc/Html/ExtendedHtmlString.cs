// 
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

using System.Web.Mvc;
using WebExtras.Html;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Default implementation of <see cref="IExtendedHtmlString" />
  /// </summary>
  public sealed class ExtendedHtmlString : IExtendedHtmlString
  {
    /// <summary>
    ///   Empty HTML string
    /// </summary>
    public static IExtendedHtmlString Empty { get { return new ExtendedHtmlString(HtmlComponent.Empty); } }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="component">A HTML component to initialize with</param>
    public ExtendedHtmlString(IHtmlComponent component)
    {
      Component = component;
    }

    /// <summary>Returns an HTML-encoded string.</summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      return MvcHtmlString.Create(Component.ToHtml()).ToHtmlString();
    }

    /// <inheritdoc />
    public IHtmlComponent Component { get; private set; }
  }
}