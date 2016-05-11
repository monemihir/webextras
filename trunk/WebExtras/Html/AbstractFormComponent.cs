// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using WebExtras.Bootstrap;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   Abstract bootstrap form control
  /// </summary>
  /// <typeparam name="TModel">Object model</typeparam>
  /// <typeparam name="TValue">Model property</typeparam>
  [Serializable]
  public abstract class AbstractFormComponent<TModel, TValue> : IFormComponent<TModel, TValue>
  {
    /// <summary>
    ///   The input element created
    /// </summary>
    public HtmlComponent Input { get; set; }

    /// <summary>
    ///   The input group div that contains all other tags
    /// </summary>
    public HtmlComponent InputGroup { get; set; }

    /// <summary>
    ///   Add text addon to the form control
    /// </summary>
    /// <param name="text">Text to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormComponent<TModel, TValue> AddText(string text, bool append = true)
    {
      return CreateAddOn(text, append);
    }

    /// <summary>
    ///   Add icon addon to the form control
    /// </summary>
    /// <param name="icon">Icon to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormComponent<TModel, TValue> AddIcon(EFontAwesomeIcon icon, bool append = true)
    {
      return CreateAddOn(BootstrapUtil.CreateIcon(icon).ToHtml(), append);
    }

    /// <summary>
    ///   Add html addon to the form control
    /// </summary>
    /// <param name="html">HTML to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormComponent<TModel, TValue> AddHtml(IHtmlComponent html, bool append = true)
    {
      return CreateAddOn(html.ToHtml(), append);
    }

    /// <summary>
    ///   Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public string ToHtml()
    {
      HtmlComponent tag = new HtmlComponent(EHtmlTag.Div);
      tag.CssClasses.Add("form-group");
      tag.InnerHtml = InputGroup.ToHtml();

      return tag.ToHtml();
    }

    /// <summary>
    ///   Creates the add on
    /// </summary>
    /// <param name="data">The html to be added in the addon</param>
    /// <param name="append">Whether we are appending the addon or prepending the addon</param>
    /// <returns>The updated form control</returns>
    private IFormComponent<TModel, TValue> CreateAddOn(string data, bool append = true)
    {
      HtmlComponent e = new HtmlComponent(WebExtrasConstants.DefaultTagForTextEncapsulation);
      e.CssClasses.Add("input-group-addon");
      e.InnerHtml = data;

      if (append)
        InputGroup.AppendTags.Add(e);
      else
        InputGroup.PrependTags.Add(e);

      return this;
    }
  }
}