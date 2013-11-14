﻿/*
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

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML LABEL tag
  /// </summary>
  public class HtmlLabel : HtmlElement
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlLabel(object htmlAttributes = null)
      : this(string.Empty, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="innerHtml">Text to be displayed</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlLabel(string innerHtml, object htmlAttributes = null)
      : base(EHtmlTag.Label, htmlAttributes)
    {
      InnerHtml = innerHtml;
    }
  }
}