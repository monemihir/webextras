using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML IMG element
  /// </summary>
  public class Image : HtmlElement
  {
    /// <summary>
    /// Image location
    /// </summary>
    public string Src { get { return Tag.Attributes["src"]; } set { Tag.Attributes["src"] = value; } }

    /// <summary>
    /// Image Alt text
    /// </summary>
    public string AltText { get { return Tag.Attributes["alt"]; } set { Tag.Attributes["alt"] = value; } }

    /// <summary>
    /// Image title text
    /// </summary>
    public string Title { get { return Tag.Attributes["title"]; } set { Tag.Attributes["title"] = value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, object htmlAttributes = null)
      : this(href, "", "", htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, string altText, object htmlAttributes = null)
      : this(href, altText, "", htmlAttributes)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="href">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Image(string href, string altText, string title, object htmlAttributes = null)
      : base(HtmlTag.IMG, htmlAttributes)
    {
      Src = href;
      AltText = altText;
      Title = title;
    }

    /// <summary>
    /// Converts current hyperlink element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current hyperlink element</returns>
    public override string ToHtmlString(TagRenderMode renderMode)
    {
      return base.ToHtmlString(TagRenderMode.SelfClosing);
    }
  }
}
