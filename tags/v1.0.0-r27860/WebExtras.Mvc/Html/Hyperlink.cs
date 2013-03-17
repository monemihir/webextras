using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML A element
  /// </summary>
  public class Hyperlink : HtmlElement
  {
    /// <summary>
    /// Link text
    /// </summary>
    public string Text { get { return Tag.InnerHtml; } set { Tag.InnerHtml = value; } }

    /// <summary>
    /// Link URL
    /// </summary>
    public string Url { get { return this["href"]; } set { this["href"] = value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Hyperlink(string linkText, string url, object htmlAttributes = null)
      : base(HtmlTag.A, htmlAttributes)
    {
      Text = linkText;
      Url = url;
    }
  }
}
