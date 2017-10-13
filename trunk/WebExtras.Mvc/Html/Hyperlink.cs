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
  ///   Represents an HTML A element
  /// </summary>
  [Serializable]
  public class Hyperlink : HtmlComponent, IExtendedHtmlString
  {
    /// <summary>
    ///   Link URL
    /// </summary>
    public string Url { get { return Attributes["href"]; } set { Attributes["href"] = value; } }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Hyperlink(string linkText, string url, object htmlAttributes = null)
      : base(EHtmlTag.A, htmlAttributes)
    {
      InnerHtml = linkText;
      Url = url;
    }

    /// <summary>
    ///   Convert the current hyperlink to a label
    /// </summary>
    /// <returns>The converted label</returns>
    public IExtendedHtmlString ToLabel()
    {
      HtmlComponent label = new HtmlComponent(EHtmlTag.Label)
      {
        InnerHtml = InnerHtml
      };
      label.AppendTags.AddRange(AppendTags);
      label.PrependTags.AddRange(PrependTags);

      foreach (string key in Attributes.Keys)
        label.Attributes.Add(key, Attributes[key]);

      label.Attributes.Remove("href");
      label.CssClasses.AddRange(CssClasses);

      return new ExtendedHtmlString(label);
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