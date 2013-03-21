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
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML LIST element
  /// </summary>
  public class HtmlList : HtmlElement
  {
    /// <summary>
    /// List type
    /// </summary>
    public ListType Type { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of list</param>
    /// <param name="listItems">A collection of items</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlList(ListType type, IEnumerable<HtmlListItem> listItems, object htmlAttributes = null)
      : base(HtmlTag.List, htmlAttributes)
    {
      Tag = new TagBuilder(type.GetStringValue());
      AppendTags.AddRange(listItems);
    }
  }
}
