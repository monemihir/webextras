// 
// This file is part of - WebExtras
// Copyright (C) 2015 Mihir Mone
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   A bootstrap form control which allows appending and prepending of elements
  /// </summary>
  public class BootstrapFormControl<TModel, TValue> : IFormControl<TModel, TValue>
  {
    /// <summary>
    ///   The input group div that contains all other tags
    /// </summary>
    public Div InputGroup { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapFormControl(Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
      : this(expression, null, htmlAttributes)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">Select list options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapFormControl(Expression<Func<TModel, TValue>> expression, string[] options,
      object htmlAttributes = null)
    {
      MemberExpression exp = expression.Body as MemberExpression;

      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.V2)
        CreateBootstrap2Tags();
      else
        CreateBootstrap3Tags(exp, options, htmlAttributes);
    }

    /// <summary>
    ///   Create bootstrap 3 tags
    /// </summary>
    /// <param name="exp">Member expression</param>
    /// <param name="options">Select list options</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    private void CreateBootstrap3Tags(MemberExpression exp, string[] options, object htmlAttributes)
    {
      var defaultAttribs = new Dictionary<string, object>
      {
        {"type", "text"},
        {"id", WebExtrasMvcUtil.GetFieldIdFromExpression(exp)},
        {"name", WebExtrasMvcUtil.GetFieldNameFromExpression(exp)}
      };

      DataTypeAttribute[] customAttribs =
        (DataTypeAttribute[]) exp.Member.GetCustomAttributes(typeof (DataTypeAttribute), false);
      if (customAttribs != null && customAttribs.Length > 0)
      {
        switch (customAttribs[0].DataType)
        {
          case DataType.EmailAddress:
            defaultAttribs["type"] = "email";
            break;

          case DataType.Password:
            defaultAttribs["type"] = "password";
            break;

          default:
            break;
        }
      }

      var attribs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes).Merge(defaultAttribs);
      HtmlElement input = null;
      if (options == null)
        input = new HtmlElement(EHtmlTag.Input, attribs);
      else
        input = new Select(options, attribs);

      input.AddCssClass("form-control");

      InputGroup = new Div().AddCssClass("input-group");
      InputGroup.Append(input);
    }

    /// <summary>
    ///   Create bootstrap 2 tags
    /// </summary>
    private void CreateBootstrap2Tags()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Creates the add on
    /// </summary>
    /// <param name="data">The html to be added in the addon</param>
    /// <param name="append">Whether we are appending the addon or prepending the addon</param>
    /// <returns>The updated form control</returns>
    private IFormControl<TModel, TValue> CreateAddOn(string data, bool append = true)
    {
      var e = new HtmlElement(WebExtrasMvcConstants.DefaultTagForTextEncapsulation).AddCssClass("input-group-addon");
      e.InnerHtml = data;

      if (append)
        InputGroup.Append(e);
      else
        InputGroup.Prepend(e);

      return this;
    }

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
      return CreateAddOn(BootstrapUtil.CreateIcon(icon).ToHtmlString(), append);
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
  }
}