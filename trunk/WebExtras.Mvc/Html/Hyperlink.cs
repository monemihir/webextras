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
    public string Text { get; set; }

    /// <summary>
    /// Link URL
    /// </summary>
    public string Url { get { return Tag.Attributes["href"]; } set { Tag.Attributes["href"] = value; } }

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

    /// <summary>
    /// Converts current hyperlink element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current hyperlink element</returns>
    public override string ToHtmlString(TagRenderMode renderMode)
    {      
      Tag.InnerHtml = string.Join("", InnerTags.Select(f => f.ToHtmlString())) + Text;

      return Tag.ToString(renderMode);
    }
  }
}
