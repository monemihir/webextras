// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2015 Mihir Mone
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

using System.Web.Mvc;
using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   Abstract bootstrap form control
  /// </summary>
  /// <typeparam name="TModel">Object model</typeparam>
  /// <typeparam name="TValue">Model property</typeparam>
  public abstract class AbstractFormControl<TModel, TValue> : IFormControl<TModel, TValue>
  {
    /// <summary>
    ///   The input element created
    /// </summary>
    public HtmlElement Input { get; set; }

    /// <summary>
    ///   The input group div that contains all other tags
    /// </summary>
    public Div InputGroup { get; set; }

    /// <summary>
    ///   Add text addon to the form control
    /// </summary>
    /// <param name="text">Text to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormControl<TModel, TValue> AddText(string text, bool append = true)
    {
      return CreateAddOn(text, append);
    }

    /// <summary>
    ///   Add icon addon to the form control
    /// </summary>
    /// <param name="icon">Icon to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormControl<TModel, TValue> AddIcon(EFontAwesomeIcon icon, bool append = true)
    {
      return CreateAddOn(BootstrapUtil.CreateIcon(icon).ToHtml(), append);
    }

    /// <summary>
    ///   Add html addon to the form control
    /// </summary>
    /// <param name="html">HTML to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    public IFormControl<TModel, TValue> AddHtml(IExtendedHtmlString html, bool append = true)
    {
      return CreateAddOn(html.ToHtmlString(), append);
    }

    /// <summary>
    ///   Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public string ToHtmlString()
    {
      TagBuilder tag = new TagBuilder("div");
      tag.AddCssClass("form-group");
      tag.InnerHtml = InputGroup.ToHtmlString();

      return tag.ToString(TagRenderMode.Normal);
    }

    /// <summary>
    ///   Creates the add on
    /// </summary>
    /// <param name="data">The html to be added in the addon</param>
    /// <param name="append">Whether we are appending the addon or prepending the addon</param>
    /// <returns>The updated form control</returns>
    private IFormControl<TModel, TValue> CreateAddOn(string data, bool append = true)
    {
      var e = new HtmlElement(WebExtrasConstants.DefaultTagForTextEncapsulation).AddCssClass("input-group-addon");
      e.InnerHtml = data;

      if (append)
        InputGroup.Append(e);
      else
        InputGroup.Prepend(e);

      return this;
    }
  }
}