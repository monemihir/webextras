// 
// This file is part of - WebExtras
// Copyright 2017 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using WebExtras.Core;
using WebExtras.Html;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Represents an HTML IMG element
  /// </summary>
  [Serializable]
  public class Image : HtmlComponent, IExtendedHtmlString
  {
    /// <summary>
    ///   Image location
    /// </summary>
    public string Src { get { return Attributes["src"]; } set { Attributes["src"] = value; } }

    /// <summary>
    ///   Image Alt text
    /// </summary>
    public string AltText { get { return Attributes["alt"]; } set { Attributes["alt"] = value; } }

    /// <summary>
    ///   Image title text
    /// </summary>
    public string Title { get { return Attributes["title"]; } set { Attributes["title"] = value; } }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, object htmlAttributes = null)
      : this(href, "", "", htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, string altText, object htmlAttributes = null)
      : this(href, altText, "", htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, string altText, string title, object htmlAttributes = null)
      : base(EHtmlTag.Img, htmlAttributes)
    {
      Src = href;

      if (!string.IsNullOrWhiteSpace(altText))
        AltText = altText;

      if (!string.IsNullOrWhiteSpace(title))
        Title = title;
    }

    /// <inheritdoc />
    public string ToHtmlString()
    {
      return ToHtml();
    }

    /// <inheritdoc />
    public IHtmlComponent Component { get { return this; } }
  }
}