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

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML LIST ITEM element
  /// </summary>
  [Serializable]
  public class HtmlListItem : HtmlElement
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="innerHtml">List item text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlListItem(string innerHtml, object htmlAttributes = null)
      : base(EHtmlTag.Li, htmlAttributes)
    {
      InnerHtml = innerHtml;
    }

    /// <summary>
    /// Create an HtmlListItem from the given item
    /// </summary>
    /// <param name="item">Item to convert to a list item</param>
    /// <returns>An HtmlListItem</returns>
    public static HtmlListItem From(IExtendedHtmlString item)
    {
      HtmlListItem li = new HtmlListItem(string.Empty);
      li.Append(item);

      return li;
    }
  }
}
