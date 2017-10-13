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
using System.Web;
using WebExtras.Core;
using WebExtras.Html;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Represents a HTML LIST element
  /// </summary>
  [Serializable]
  public class HtmlList : HtmlComponent, IHtmlString
  {
    /// <summary>
    ///   List type
    /// </summary>
    public EList Type { get; set; }

    /// <summary>
    ///   Number of items in this list
    /// </summary>
    public int Length { get { return PrependTags.Count + AppendTags.Count; } }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of list</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlList(EList type, object htmlAttributes = null)
      : base(type == EList.Ordered ? EHtmlTag.Ol : EHtmlTag.Ul, htmlAttributes)
    {
      Type = type;
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Type of list</param>
    /// <param name="listItems">A collection of items</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlList(EList type, IEnumerable<HtmlListItem> listItems, object htmlAttributes = null)
      : base(type == EList.Ordered ? EHtmlTag.Ol : EHtmlTag.Ul, htmlAttributes)
    {
      Type = type;
      AppendTags.AddRange(listItems);
    }

    /// <summary>
    ///   Returns an HTML-encoded string.
    /// </summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      return ToHtml();
    }
  }
}