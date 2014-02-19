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
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML IMG element
  /// </summary>
  [Serializable]
  public class Image : HtmlElement
  {
    /// <summary>
    /// Image location
    /// </summary>
    public string Src { get { return this["src"]; } set { this["src"] = value; } }

    /// <summary>
    /// Image Alt text
    /// </summary>
    public string AltText { get { return this["alt"]; } set { this["alt"] = value; } }

    /// <summary>
    /// Image title text
    /// </summary>
    public string Title { get { return this["title"]; } set { this["title"] = value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, object htmlAttributes = null)
      : this(href, "", "", htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, string altText, object htmlAttributes = null)
      : this(href, altText, "", htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, string altText, string title, object htmlAttributes = null)
      : base(EHtmlTag.Img, htmlAttributes)
    {
      Src = href;
      AltText = altText;
      Title = title;
    }

    /// <summary>
    /// Converts current hyperlink element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current hyperlink element</returns>
    public override string ToHtmlString(TagRenderMode renderMode)
    {
      return base.ToHtmlString(TagRenderMode.SelfClosing);
    }
  }
}
