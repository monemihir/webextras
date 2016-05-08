// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Represents a HTML DIV element
  /// </summary>
  [Serializable]
  public class Span : HtmlElement
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Span(object htmlAttributes = null)
      : base(EHtmlTag.Span, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="innerHtml">Inner HTML to be displayed</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Span(string innerHtml, object htmlAttributes = null)
      : base(EHtmlTag.Span, htmlAttributes)
    {
      InnerHtml = innerHtml;
    }
  }
}