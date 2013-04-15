/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML Checkbox element
  /// </summary>
  [Serializable]
  public class CheckBox : HtmlElement
  {
    /// <summary>
    /// Checkbox value
    /// </summary>
    public string Value { get { return this["value"]; } set { this["value"] = value; } }

    /// <summary>
    /// Checkbox text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Flag indicating whether the check box is checked
    /// </summary>
    public bool IsChecked { get; set; }

    /// <summary>
    /// Flag indicating whether the check box is disabled
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    public CheckBox(string text, string value)
      : this(text, value, false, false, null)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public CheckBox(string text, string value, object htmlAttributes = null)
      : this(text, value, false, false, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    public CheckBox(string text, string value, bool isChecked)
      : this(text, value, isChecked, false, null)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public CheckBox(string text, string value, bool isChecked, object htmlAttributes = null)
      : this(text, value, isChecked, false, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    /// <param name="isDisabled">Flag indicating whether the check box is disabled</param>
    public CheckBox(string text, string value, bool isChecked, bool isDisabled)
      : this(text, value, isChecked, isDisabled, null)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the check box</param>
    /// <param name="value">Value for check box</param>
    /// <param name="isChecked">Flag indicating whether the check box is checked</param>
    /// <param name="isDisabled">Flag indicating whether the check box is disabled</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public CheckBox(string text, string value, bool isChecked, bool isDisabled, object htmlAttributes = null)
      : base(EHtmlTag.Input, htmlAttributes)
    {
      this["type"] = "checkbox";
      Value = value;
      Text = text;
      IsChecked = isChecked;
      IsDisabled = isDisabled;
    }

    /// <summary>
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    public override string ToHtmlString(TagRenderMode renderMode)
    {
      if (IsChecked)
        this["checked"] = "";
      if (IsDisabled)
        this["disabled"] = "";

      return base.ToHtmlString(TagRenderMode.SelfClosing) + " " + Text;
    }
  }
}