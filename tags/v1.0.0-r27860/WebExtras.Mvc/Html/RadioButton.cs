using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML RADIO button element
  /// </summary>
  public class RadioButton : HtmlElement
  {
    /// <summary>
    /// Radio button text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Radio button value
    /// </summary>
    public string Value { get { return this["value"]; } set { this["value"] = value; } }

    /// <summary>
    /// Flag indicating whether the radio button is checked
    /// </summary>
    public bool IsChecked { get; set; }

    /// <summary>
    /// Flag indicating whether the radio button is disabled
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the radio button</param>
    /// <param name="value">Value for radio button</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public RadioButton(string text, string value, object htmlAttributes = null)
      : this(text, value, false, false, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the radio button</param>
    /// <param name="value">Value for radio button</param>
    /// <param name="isChecked">Flag indicating whether the radio button is checked</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public RadioButton(string text, string value, bool isChecked, object htmlAttributes = null)
      : this(text, value, isChecked, false, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed for the radio button</param>
    /// <param name="value">Value for radio button</param>
    /// <param name="isChecked">Flag indicating whether the radio button is checked</param>
    /// <param name="isDisabled">Flag indicating whether the radio button is disabled</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public RadioButton(string text, string value, bool isChecked, bool isDisabled, object htmlAttributes = null)
      : base(HtmlTag.Input, htmlAttributes)
    {
      this["type"] = "radio";
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
