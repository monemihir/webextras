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

using System.Collections.Generic;
using System.Linq;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   A simple wrapper component which renders all internal components side-by-side
  /// </summary>
  public class NullWrapperComponent : HtmlComponent
  {
    /// <summary>
    ///   Internal components to be rendered
    /// </summary>
    public List<HtmlComponent> Components { get; private set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="components">[Optional] Internal components to initialise with</param>
    public NullWrapperComponent(IEnumerable<HtmlComponent> components = null) : base(EHtmlTag.Empty)
    {
      Components = components == null ? new List<HtmlComponent>() : components.ToList();
    }

    /// <inheritdoc />
    public override string ToHtml()
    {
      IEnumerable<string> txtComponents = Components.Select(c => c.ToHtml());

      string html = string.Join("", txtComponents);

      return html;
    }
  }
}