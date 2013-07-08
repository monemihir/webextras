using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML DIV element
  /// </summary>
  [Serializable]
  public class Span : HtmlElement
  {
    /// <summary>
    /// Text to be displayed within the SPAN
    /// </summary>
    public string Text { get { return Tag.InnerHtml; } set { Tag.InnerHtml = value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Span(object htmlAttributes = null)
      : base(EHtmlTag.Span, htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Span(string text, object htmlAttributes = null)
      : base(EHtmlTag.Span, htmlAttributes)
    {
      Text = text;
    }
  }
}
