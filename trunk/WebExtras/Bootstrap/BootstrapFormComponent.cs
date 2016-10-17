// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Html;

namespace WebExtras.Bootstrap
{
  /// <summary>
  ///   A bootstrap form control which allows appending and prepending of elements
  /// </summary>
  [Serializable]
  public class BootstrapFormComponent<TModel, TValue> : IBootstrapFormComponent<TModel, TValue>
  {
    /// <summary>
    /// Property expression
    /// </summary>
    private MemberExpression m_propertyExpression;

    /// <summary>
    ///   Select list items (populated if we are creating a SELECT control)
    /// </summary>
    private readonly IEnumerable<SelectListOption> m_selectListItems;

    /// <summary>
    ///   Text area row/column count (populated if we are creating a TEXTAREA control)
    /// </summary>
    private readonly int[] m_textAreaDimensions;

    /// <summary>
    ///   The rendering behavior of this form control component
    /// </summary>
    public EFormControlBehavior RenderBehavior { get; private set; }

    /// <summary>
    ///   The input element created
    /// </summary>
    public HtmlComponent Input { get; private set; }

    /// <summary>
    ///   The input group div that contains all other tags
    /// </summary>
    public HtmlComponent InputGroup { get; private set; }

    /// <summary>
    ///   The label for the control
    /// </summary>
    public HtmlComponent Label { get; private set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapFormComponent(Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
      Init(expression, htmlAttributes);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="options">Select list options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapFormComponent(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListOption> options,
      object htmlAttributes = null)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      m_selectListItems = options;

      Init(expression, htmlAttributes);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="rows">No. of rows</param>
    /// <param name="columns">No. of columns</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapFormComponent(Expression<Func<TModel, TValue>> expression, int rows, int columns,
      object htmlAttributes = null)
    {
      if (rows <= 0 || columns <= 0)
        throw new InvalidOperationException("Invalid dimensions given. rows/columns must be greater than 0");

      m_textAreaDimensions = new[] { rows, columns };

      Init(expression, htmlAttributes);
    }

    #region Implementation of IBootstrapFormComponent<TModel,TValue>

    /// <inheritdoc />
    public IFormComponent<TModel, TValue> AddText(bool append = true)
    {
      DisplayNameAttribute[] customAttributes = (DisplayNameAttribute[]) m_propertyExpression.Member.GetCustomAttributes(typeof(DisplayNameAttribute), false);

      if (customAttributes.Length > 0)
        AddText(customAttributes[0].DisplayName, append);
      else
        AddText(m_propertyExpression.Member.Name.SplitCamelCase(), append);

      return this;
    }

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

    /// <inheritdoc />
    public IFormComponent<TModel, TValue> SetValue(string value)
    {
      if (Input == null)
        return this;

      switch (Input.Tag)
      {
        case EHtmlTag.Input:
          if (Input.Attributes["type"] != "password")
            Input.Attributes["value"] = value;
          break;

        case EHtmlTag.Select:
          foreach (var subComponent in Input.AppendTags.Concat(Input.PrependTags))
          {
            if (subComponent.Tag != EHtmlTag.Option)
              continue;

            if (subComponent.Attributes["value"] == value)
              subComponent.Attributes["selected"] = "true";
            else
              subComponent.Attributes.Remove("selected");
          }
          break;

        case EHtmlTag.TextArea:
          Input.InnerHtml = value;
          break;
      }

      return this;
    }

    /// <summary>
    ///   Changes render behavior to default
    /// </summary>
    /// <returns>The updated form control</returns>
    public IBootstrapFormComponent<TModel, TValue> WithDefaultBehavior()
    {
      RenderBehavior = EFormControlBehavior.Default;

      return this;
    }

    /// <summary>
    ///   Changes render behavior to add on
    /// </summary>
    /// <returns>The updated form control</returns>
    public IBootstrapFormComponent<TModel, TValue> WithAddonBehavior()
    {
      RenderBehavior = EFormControlBehavior.WithAddon;

      return this;
    }

    #endregion Implementation of IBootstrapFormComponent<TModel,TValue>

    #region Implementation of IHtmlRenderer

    /// <summary>
    ///   Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public string ToHtml()
    {
      HtmlComponent tag = new HtmlComponent(EHtmlTag.Div);
      tag.CssClasses.Add("form-group");

      if (RenderBehavior == EFormControlBehavior.Default)
        tag.InnerHtml = (Label == null ? string.Empty : Label.ToHtml()) + Input.ToHtml();
      else
        tag.InnerHtml = InputGroup.ToHtml();

      return tag.ToHtml();
    }

    #endregion Implementation of IHtmlRenderer

    /// <summary>
    ///   Creates the add on
    /// </summary>
    /// <param name="data">The html to be added in the addon</param>
    /// <param name="append">Whether we are appending the addon or prepending the addon</param>
    /// <returns>The updated form control</returns>
    private IFormComponent<TModel, TValue> CreateAddOn(string data, bool append = true)
    {
      HtmlComponent e = new HtmlComponent(WebExtrasSettings.DefaultTagForTextEncapsulation);
      e.CssClasses.Add("input-group-addon");
      e.InnerHtml = data;

      if (append)
        InputGroup.AppendTags.Add(e);
      else
        InputGroup.PrependTags.Add(e);

      HtmlComponent lbl = new HtmlComponent(EHtmlTag.Label);
      lbl.Attributes["for"] = Input.Attributes["name"];

      string html = Label != null ? Label.InnerHtml : string.Empty;

      if (append)
        html += data;
      else
        html = data + html;

      lbl.InnerHtml = html;

      Label = lbl;

      return this;
    }

    /// <summary>
    ///   Init tag
    /// </summary>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    private void Init(Expression<Func<TModel, TValue>> expression, object htmlAttributes)
    {
      RenderBehavior = WebExtrasSettings.FormControlBehavior;
      m_propertyExpression = expression.Body as MemberExpression; 

      if (WebExtrasSettings.BootstrapVersion == EBootstrapVersion.V2)
        CreateBootstrap2Tags();
      else
        CreateBootstrap3Tags(htmlAttributes);
    }

    /// <summary>
    ///   Create bootstrap 3 tags
    /// </summary>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    private void CreateBootstrap3Tags( object htmlAttributes)
    {
      var defaultAttribs = new Dictionary<string, string>
      {
        {"type", "text"},
        {"id", WebExtrasUtil.GetFieldIdFromExpression(m_propertyExpression)},
        {"name", WebExtrasUtil.GetFieldNameFromExpression(m_propertyExpression)}
      };

      DataTypeAttribute[] customAttribs =
        (DataTypeAttribute[])m_propertyExpression.Member.GetCustomAttributes(typeof(DataTypeAttribute), false);
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

      Dictionary<string, string> attribs = WebExtrasUtil
        .AnonymousObjectToHtmlAttributes(htmlAttributes)
        .ToDictionary()
        .Merge(defaultAttribs)
        .ToDictionary(k => k.Key, v => v.Value);

      HtmlComponent input;

      if (m_selectListItems != null)
        input = new SelectComponent(m_selectListItems, attribs);
      else if (m_textAreaDimensions != null || attribs.ContainsValue("textarea"))
      {
        attribs.Remove("type");

        input = new HtmlComponent(EHtmlTag.TextArea, attribs);
      }
      else
        input = new HtmlComponent(EHtmlTag.Input, attribs);

      input.CssClasses.Add("form-control");

      Input = input;
      InputGroup = new HtmlComponent(EHtmlTag.Div);
      InputGroup.CssClasses.Add("input-group");
      InputGroup.AppendTags.Add(input);
    }

    /// <summary>
    ///   Create bootstrap 2 tags
    /// </summary>
    private void CreateBootstrap2Tags()
    {
      throw new NotSupportedException("Bootstrap 2 is not supported for this component anymore. Please upgrade to Bootstrap 3.");
    }
  }
}