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
  ///   Represents a HTML Checkbox element
  /// </summary>
  [Serializable]
  public class CheckBox : HtmlComponent, IExtendedHtmlString
  {
    /// <summary>
    ///   Checkbox value
    /// </summary>
    public string Value { get { return Attributes["value"]; } set { Attributes["value"] = value; } }

    /// <summary>
    ///   Checkbox text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///   Flag indicating whether the check box is checked
    /// </summary>
    public bool IsChecked { get; set; }

    /// <summary>
    ///   Flag indicating whether the check box is disabled
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    public CheckBox(string text, string value)
      : this(text, value, false, false, null)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public CheckBox(string text, string value, object htmlAttributes = null)
      : this(text, value, false, false, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    public CheckBox(string text, string value, bool isChecked)
      : this(text, value, isChecked, false, null)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public CheckBox(string text, string value, bool isChecked, object htmlAttributes)
      : this(text, value, isChecked, false, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    /// <param name="isDisabled">Flag indicating whether the check box is disabled</param>
    public CheckBox(string text, string value, bool isChecked, bool isDisabled)
      : this(text, value, isChecked, isDisabled, null)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    /// <param name="isDisabled">Flag indicating whether the check box is disabled</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public CheckBox(string text, string value, bool isChecked, bool isDisabled, object htmlAttributes)
      : base(EHtmlTag.Input, htmlAttributes)
    {
      Attributes["type"] = "checkbox";
      Value = value;
      Text = text;
      IsChecked = isChecked;
      IsDisabled = isDisabled;
    }

    /// <inheritdoc />
    public string ToHtmlString()
    {
      if (IsChecked)
        Attributes["checked"] = "";
      if (IsDisabled)
        Attributes["disabled"] = "";

      return ToHtml() + " " + Text;
    }

    /// <inheritdoc />
    public IHtmlComponent Component { get { return this; } }
  }
}