using System;
using System.Linq;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML BUTTON element
  /// </summary>
  public class Button : HtmlElement
  {
    /// <summary>
    /// Button text
    /// </summary>
    public string Text
    {
      get { return Tag.InnerHtml; }
      set { Tag.InnerHtml = value; }
    }

    /// <summary>
    /// Button onclick event
    /// </summary>
    public string OnClick
    {
      get { return this["onclick"]; }
      set { this["onclick"] = "javascript:" + value; }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="onclick">Javascript onclick event of the button</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public Button(ButtonOfType type, string text, string onclick, object htmlAttributes = null)
      : base(HtmlTag.Button, htmlAttributes)
    {
      Text = text;

      if (!string.IsNullOrEmpty(onclick))
        OnClick = onclick;

      this["type"] = type.GetStringValue();      
    }
  }
}
