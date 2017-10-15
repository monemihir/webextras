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
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   Represents a HTML DIV element
  /// </summary>
  [Serializable]
  public class HtmlDiv : HtmlComponent
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    public HtmlDiv()
      : this(null)
    {
    }

    /// <summary>
    ///   Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="innerHtml">Inner HTML</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlDiv(string innerHtml, object htmlAttributes = null) : base(EHtmlTag.Div, htmlAttributes)
    {
      InnerHtml = innerHtml;
    }
  }
}