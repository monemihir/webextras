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
using System.Web;
using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.Html;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   A bootstrap navigation bar element
  /// </summary>
  [Serializable]
  public class BootstrapNavBar : HtmlComponent, IHtmlString
  {
    /// <summary>
    ///   Navbar type
    /// </summary>
    public EBootstrapNavbar Type { get; set; }

    /// <summary>
    ///   The brand hyperlink
    /// </summary>
    public Hyperlink Brand { get; set; }

    /// <summary>
    ///   Default constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    private BootstrapNavBar(EBootstrapNavbar type)
      : base(EHtmlTag.Div)
    {
      Type = type;
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    public BootstrapNavBar(EBootstrapNavbar type, HtmlList items)
      : this(type)
    {
      CreateNavBar(items);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    /// <param name="brandLink">Navigation bar brand link</param>
    /// <param name="items">Navigation bar items</param>
    public BootstrapNavBar(EBootstrapNavbar type, Hyperlink brandLink, HtmlList items)
      : this(type)
    {
      Brand = brandLink;
      CreateNavBar(items);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    public BootstrapNavBar(EBootstrapNavbar type, params Hyperlink[] items)
      : this(type)
    {
      HtmlList list = new HtmlList(EList.Unordered);
      foreach (Hyperlink item in items)
      {
        if (item.CssClasses.Contains("brand") || item.CssClasses.Contains("navbar-brand"))
        {
          Brand = item;
        }
        else
        {
          HtmlListItem li = new HtmlListItem(string.Empty);
          li.AppendTags.Add(item.Component);
          list.AppendTags.Add(li);
        }
      }

      CreateNavBar(list);
    }

    /// <summary>
    ///   Creates a Bootstrap navigation bar from the given
    ///   list of items
    /// </summary>
    /// <param name="list">Navigation bar items</param>
    private void CreateNavBar(HtmlList list)
    {
      list.Attributes["class"] = "nav navbar-nav";

      Attributes["class"] = Type.GetStringValue();

      switch (WebExtrasSettings.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          HtmlComponent innerNav = new HtmlComponent(EHtmlTag.Div);

          innerNav.Attributes["class"] = "navbar-inner";

          if (Brand != null)
            innerNav.PrependTags.Add(Brand.Component);

          innerNav.AppendTags.Add(list);

          AppendTags.Add(innerNav);
          break;
        case EBootstrapVersion.V3:
          if (Brand != null)
          {
            Brand.Attributes["class"] = "navbar-brand";
            PrependTags.Add(Brand.Component);
          }

          AppendTags.Add(list);
          break;
        default:
          throw new BootstrapVersionException();
      }
    }

    /// <summary>Returns an HTML-encoded string.</summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      return ToHtml();
    }
  }
}