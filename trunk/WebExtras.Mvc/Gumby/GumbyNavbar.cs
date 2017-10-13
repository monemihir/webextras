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
using WebExtras.Html;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  ///   A Gumby navigation bar
  /// </summary>
  [Serializable]
  public class GumbyNavbar : HtmlElement
  {
    /// <summary>
    ///   The logo hyperlink
    /// </summary>
    public Hyperlink Logo { get; private set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="logoLink">Navigation bar logo link</param>
    /// <param name="items">Navigation bar items</param>
    public GumbyNavbar(Hyperlink logoLink, HtmlList items)
      : base(EHtmlTag.Div)
    {
      Logo = logoLink;
      CreateNavBar(items);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="items">Navigation bar items</param>
    public GumbyNavbar(HtmlList items)
      : base(EHtmlTag.Div)
    {
      CreateNavBar(items);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="items">Navigation bar items</param>
    public GumbyNavbar(IEnumerable<Hyperlink> items)
      : base(EHtmlTag.Div)
    {
      HtmlList list = new HtmlList(EList.Unordered);

      foreach (Hyperlink item in items)
      {
        if (item.CSSClasses.Contains("logo"))
        {
          Logo = item;
        }
        else
        {
          // check if this is the "brand"
          HtmlListItem li = new HtmlListItem(string.Empty);
          li.AppendTags.Add(item.Component);
          list.AppendTags.Add(li);
        }
      }

      CreateNavBar(list);
    }

    /// <summary>
    ///   Create the Gumby navigation bar
    /// </summary>
    /// <param name="list">Navigation bar items</param>
    private void CreateNavBar(HtmlList list)
    {
      this["class"] = "row navbar metro";

      Component.AppendTags.Add(list);

      // append the logo/brand is it was supplied
      if (Logo == null)
        return;

      HtmlComponent logoDiv = new HtmlComponent(EHtmlTag.Div);

      logoDiv.CssClasses.AddRange(Logo.CSSClasses);
      Logo.CSSClasses.Clear();

      logoDiv.AppendTags.Add(Logo.Component);

      Component.PrependTags.Add(logoDiv);
    }
  }
}