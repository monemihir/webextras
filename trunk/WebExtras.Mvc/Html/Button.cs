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

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML BUTTON element
  /// </summary>
  [Serializable]
  public class Button : HtmlElement
  {
    /// <summary>
    /// Button onclick event
    /// </summary>
    public string OnClick
    {
      get { return this["onclick"]; }
      set { this["onclick"] = "javascript:" + value; }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="onclick">Javascript onclick event of the button</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public Button(EButton type, string text, string onclick, object htmlAttributes = null)
      : base(EHtmlTag.Button, htmlAttributes)
    {
      InnerHtml = text;

      if (!string.IsNullOrEmpty(onclick))
        OnClick = onclick;

      this["type"] = type.GetStringValue();
    }
  }
}
