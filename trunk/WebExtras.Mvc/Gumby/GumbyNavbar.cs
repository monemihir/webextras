/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
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
using System.Collections.Generic;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// A Gumby navigation bar
  /// </summary>
  [Serializable]
  public class GumbyNavbar : HtmlElement
  {
    /// <summary>
    /// The logo hyperlink
    /// </summary>
    public Hyperlink Logo { get; set; }

    /// <summary>
    /// Constructor
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
    /// Constructor
    /// </summary>
    /// <param name="items">Navigation bar items</param>
    public GumbyNavbar(HtmlList items)
      : base(EHtmlTag.Div)
    {
      CreateNavBar(items);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="items">Navigation bar items</param>
    public GumbyNavbar(IEnumerable<Hyperlink> items)
      : base(EHtmlTag.Div)
    {
      HtmlList list = new HtmlList(EList.Unordered);

      foreach (Hyperlink item in items)
      {
        if (item.Attributes.ContainsKey("class") && item.Attributes["class"].ContainsIgnoreCase("logo"))
        {
          Logo = item;
        }
        else
        {
          // check if this is the "brand"
          HtmlListItem li = new HtmlListItem(string.Empty);
          li.Append(item);
          list.Append(li);
        }
      }

      CreateNavBar(list);
    }

    /// <summary>
    /// Create the Gumby navigation bar
    /// </summary>
    /// <param name="list">Navigation bar items</param>
    private void CreateNavBar(HtmlList list)
    {
      this["class"] = "row navbar metro";
      Append(list);

      // append the logo/brand is it was supplied
      if (Logo == null)
        return;

      Div logoDiv = new Div();
      logoDiv["class"] = Logo.Attributes["class"];

      Logo.Attributes.Remove("class");
      logoDiv.Append(Logo);

      Prepend(logoDiv);
    }
  }
}
