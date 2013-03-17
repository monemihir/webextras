
namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML I element
  /// </summary>
  public class Italic : HtmlElement
  {
    /// <summary>
    /// Italic text
    /// </summary>
    public string Text { get { return Tag.InnerHtml; } set { Tag.InnerHtml = value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Italic(string text, object htmlAttributes = null)
      : base(HtmlTag.I, htmlAttributes)
    {
      Text = text;
    }      

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Italic(object htmlAttributes = null)
      : base(HtmlTag.I, htmlAttributes)
    { }
  }
}
