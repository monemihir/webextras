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
  ///   Represents an HTML A element
  /// </summary>
  [Serializable]
  public class Hyperlink : HtmlElement
  {
    /// <summary>
    ///   Link URL
    /// </summary>
    public string Url
    {
      get { return this["href"]; }
      set { this["href"] = value; }
    }

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
    public HtmlLabel ToLabel()
    {
      HtmlLabel label = new HtmlLabel(InnerHtml);
      label.Append(AppendTags);
      label.Prepend(PrependTags);

      foreach (string key in Attributes.Keys)
        label.Attributes.Add(key, Attributes[key]);

      label.Attributes.Remove("href");

      CSSClasses.ForEach(f => label.AddCssClass(f));

      return label;
    }
  }
}