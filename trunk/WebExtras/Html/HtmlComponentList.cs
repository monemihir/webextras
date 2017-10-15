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

using System;
using System.Collections.Generic;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   Represents an <see cref="IHtmlComponent" /> collection
  /// </summary>
  [Serializable]
  public class HtmlComponentList : List<IHtmlComponent>
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    public HtmlComponentList()
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="components">A collection of components to initialise with</param>
    public HtmlComponentList(IEnumerable<IHtmlComponent> components)
    {
      AddRange(components);
    }

    /// <summary>
    ///   Add given text as a component
    /// </summary>
    /// <param name="text">Text to add</param>
    public void Add(string text)
    {
      HtmlComponent c = new HtmlComponent(WebExtrasSettings.DefaultTagForTextEncapsulation)
      {
        InnerHtml = text
      };

      Add(c);
    }
  }
}