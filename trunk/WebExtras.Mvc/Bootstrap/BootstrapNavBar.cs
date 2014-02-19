/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// A bootstrap navigation bar element
  /// </summary>
  [Serializable]
  public class BootstrapNavBar : HtmlElement
  {
    /// <summary>
    /// Navbar type
    /// </summary>
    public EBootstrapNavbar Type { get; set; }

    /// <summary>
    /// The brand hyperlink
    /// </summary>
    public Hyperlink Brand { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    private BootstrapNavBar(EBootstrapNavbar type)
      : base(EHtmlTag.Div)
    {
      Type = type;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    public BootstrapNavBar(EBootstrapNavbar type, HtmlList items)
      : this(type)
    {
      CreateNavBar(items);
    }

    /// <summary>
    /// Constructor
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
    /// Constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    public BootstrapNavBar(EBootstrapNavbar type, params Hyperlink[] items)
      : this(type)
    {
      HtmlList list = new HtmlList(EList.Unordered);
      foreach (Hyperlink item in items)
      {
        if (item.CSSClasses.Contains("brand") || item.CSSClasses.Contains("navbar-brand"))
        {
          Brand = item;
        }
        else
        {
          HtmlListItem li = new HtmlListItem(string.Empty);
          li.Append(item);
          list.Append(li);
        }
      }

      CreateNavBar(list);
    }

    /// <summary>
    /// Creates a Bootstrap navigation bar from the given
    /// list of items
    /// </summary>
    /// <param name="list">Navigation bar items</param>
    private void CreateNavBar(HtmlList list)
    {
      list["class"] = "nav navbar-nav";

      this["class"] = Type.GetStringValue();

      switch (WebExtrasMvcConstants.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          Div innerNav = new Div();
          innerNav["class"] = "navbar-inner";

          if (Brand != null)
            innerNav.Prepend(Brand);
          innerNav.Append(list);

          Append(innerNav);
          break;
        case EBootstrapVersion.V3:
          if (Brand != null)
          {
            Brand.Attributes["class"] = "navbar-brand";
            Prepend(Brand);
          }
          Append(list);
          break;
        default:
          throw new BootstrapVersionException();
      }
    }
  }
}
