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
using WebExtras.Core;
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
    /// Constructor
    /// </summary>
    /// <param name="type">Navigation bar type</param>
    /// <param name="items">Navigation bar items</param>
    public BootstrapNavBar(EBootstrapNavbar type, params IExtendedHtmlString[] items)
      : base(HtmlTag.Div)
    {
      HtmlList list = new HtmlList(ListType.Unordered);
      list["class"] = "nav";

      IExtendedHtmlString brand = null;

      if (items != null && items.Length > 0)
      {
        foreach (var item in items)
        {
          Type t = item.GetType();

          if (t == typeof(HtmlList))
          {
            list.Prepend(item.PrependTags);
            list.Append(item.AppendTags);
          }
          else if (t == typeof(HtmlListItem))
          {
            list.Append(item);
          }
          else if (item.Tag.Attributes.ContainsKey("class") && item.Tag.Attributes["class"].ContainsIgnoreCase("brand"))
          {
            brand = item;
          }
          else if (t == typeof(Hyperlink))
          {
            // check if this is the "brand"
            HtmlListItem li = new HtmlListItem(string.Empty);
            li.Append(item);
            list.Append(li);
          }
        }
      }
      
      Div innerNav = new Div();
      innerNav["class"] = "navbar-inner";

      if (brand != null)
        innerNav.Append(brand);
      innerNav.Append(list);

      this["class"] = type.GetStringValue();
      
      this.Append(innerNav);
    }
  }
}
