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
      get { return Tag.Attributes["onclick"]; }
      set { Tag.Attributes["onclick"] = "javascript:" + (value.EndsWith("()") ? value : value + "()"); }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="onclick">Onclick event of the button</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public Button(ButtonOfType type, string text, string onclick, object htmlAttributes = null)
      : base(HtmlTag.Button, htmlAttributes)
    {
      Text = text;

      if (!string.IsNullOrEmpty(onclick))
        OnClick = onclick;

      Tag.Attributes["type"] = type.GetStringValue();
      Tag.Attributes["id"] = string.Format("autogen-{0}", new Random(DateTime.Now.Millisecond).Next(1, 9999).ToString());      
    }
  }
}
