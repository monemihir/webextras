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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
  public class FormControl<TModel, TValue> : AbstractFormControl<TModel, TValue>
  {
    /// <summary>
    ///   Select list items (populated if we are creating a SELECT control)
    /// </summary>
    private readonly IEnumerable<SelectListItem> m_selectListItems;

    /// <summary>
    ///   Text area row/column count (populated if we are creating a TEXTAREA control)
    /// </summary>
    private readonly int[] m_textAreaDimensions;

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public FormControl(Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
      CreateTags(expression, htmlAttributes);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">Select list options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public FormControl(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> options,
      object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      m_selectListItems = options;

      CreateTags(expression, htmlAttributes);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="rows">No. of rows</param>
    /// <param name="columns">No. of columns</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public FormControl(Expression<Func<TModel, TValue>> expression, int rows, int columns, object htmlAttributes = null)
    {
      if (rows <= 0 || columns <= 0)
        throw new InvalidOperationException("Invalid dimensions given. rows/columns must be greater than 0");

      m_textAreaDimensions = new[] {rows, columns};

      CreateTags(expression, htmlAttributes);
    }

    /// <summary>
    ///   Create tags
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    private void CreateTags(Expression<Func<TModel, TValue>> expression, object htmlAttributes)
    {
      MemberExpression exp = expression.Body as MemberExpression;
      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.V2)
        CreateBootstrap2Tags();
      else
        CreateBootstrap3Tags(exp, htmlAttributes);
    }

    /// <summary>
    ///   Create bootstrap 3 tags
    /// </summary>
    /// <param name="exp">Member expression</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    private void CreateBootstrap3Tags(MemberExpression exp, object htmlAttributes)
    {
      var defaultAttribs = new Dictionary<string, object>
      {
        {"type", "text"},
        {"id", WebExtrasMvcUtil.GetFieldIdFromExpression(exp)},
        {"name", WebExtrasMvcUtil.GetFieldNameFromExpression(exp)}
      };

      DataTypeAttribute[] customAttribs =
        (DataTypeAttribute[]) exp.Member.GetCustomAttributes(typeof (DataTypeAttribute), false);
      if (customAttribs.Length > 0)
      {
        switch (customAttribs[0].DataType)
        {
          case DataType.EmailAddress:
            defaultAttribs["type"] = "email";
            break;

          case DataType.Password:
            defaultAttribs["type"] = "password";
            break;

          case DataType.MultilineText:
            defaultAttribs["type"] = "textarea";
            break;
        }
      }

      Dictionary<string, object> attribs = HtmlHelper
        .AnonymousObjectToHtmlAttributes(htmlAttributes)
        .Merge(defaultAttribs)
        .ToDictionary(k => k.Key, v => v.Value);

      HtmlElement input;

      if (m_selectListItems != null)
        input = new Select(m_selectListItems, attribs);
      else if (m_textAreaDimensions != null || attribs.ContainsValue("textarea"))
      {
        attribs.Remove("type");

        input = new HtmlElement(EHtmlTag.TextArea, attribs);
      }
      else
        input = new HtmlElement(EHtmlTag.Input, attribs);

      input.AddCssClass("form-control");

      Input = input;
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
  }
}