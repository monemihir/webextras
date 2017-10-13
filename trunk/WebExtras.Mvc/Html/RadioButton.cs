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
  ///   Represents a HTML RADIO button element
  /// </summary>
  [Serializable]
  public class RadioButton : HtmlComponent, IExtendedHtmlString
  {
    /// <summary>
    ///   Radio button text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///   Radio button value
    /// </summary>
    public string Value { get { return Attributes["value"]; } set { Attributes["value"] = value; } }

    /// <summary>
    ///   Flag indicating whether the radio button is checked
    /// </summary>
    public bool IsChecked { get; set; }

    /// <summary>
    ///   Flag indicating whether the radio button is disabled
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the radio button</param>
    /// <param name="value">Value for radio button</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public RadioButton(string text, string value, object htmlAttributes = null)
      : this(text, value, false, false, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the radio button</param>
    /// <param name="value">Value for radio button</param>
    /// <param name="isChecked">Flag indicating whether the radio button is checked</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public RadioButton(string text, string value, bool isChecked, object htmlAttributes = null)
      : this(text, value, isChecked, false, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the radio button</param>
    /// <param name="value">Value for radio button</param>
    /// <param name="isChecked">Flag indicating whether the radio button is checked</param>
    /// <param name="isDisabled">Flag indicating whether the radio button is disabled</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public RadioButton(string text, string value, bool isChecked, bool isDisabled, object htmlAttributes = null)
      : base(EHtmlTag.Input, htmlAttributes)
    {
      Attributes["type"] = "radio";
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