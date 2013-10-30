using System;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML DIV element
  /// </summary>
  [Serializable]
  public class Span : HtmlElement
  {
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
    /// <param name="innerHtml">Inner HTML to be displayed</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Span(string innerHtml, object htmlAttributes = null)
      : base(EHtmlTag.Span, htmlAttributes)
    {
      InnerHtml = innerHtml;
    }
  }
}
