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
    /// Constructor
    /// </summary>
    /// <param name="items">A collection of navbar items</param>
    public GumbyNavbar(ICollection<IExtendedHtmlString> items)
      : base(EHtmlTag.Div)
    {
      HtmlList list = new HtmlList(EList.Unordered);

      IExtendedHtmlString logo = null;

      if (items != null && items.Count > 0)
      {
        foreach (IExtendedHtmlString item in items)
        {
          Type t = item.GetType();

          if (t == typeof(HtmlList))
          {
            list.Prepend(item.PrependTags);
            list.Append(item.AppendTags);
            list["class"] = item.Tag.Attributes["class"];
          }
          else if (item.Tag.Attributes.ContainsKey("class") && item.Tag.Attributes["class"].ContainsIgnoreCase("logo"))
          {
            logo = item;
          }
          else if (t == typeof(Hyperlink))
          {
            // check if this is the "brand"
            HtmlListItem li = new HtmlListItem(string.Empty);
            li.Append(item);
            list.Append(li);
          }
          else
          {
            throw new ArgumentException("A navbar item can only be of type WebExtras.Mvc.Html.HtmlList or WebExtras.Mvc.Html.Hyperlink.\n\n" +
              "You passed in a " + t.FullName + ".");
          }
        }
      }

      this["class"] = "row navbar metro";
      Append(list);

      // append the logo/brand is it was supplied
      if (logo == null)
        return;

      Div logoDiv = new Div();
      logoDiv["class"] = logo.Tag.Attributes["class"];

      logo.Tag.Attributes.Remove("class");
      logoDiv.Append(logo);

      Prepend(logoDiv);
    }
  }
}
