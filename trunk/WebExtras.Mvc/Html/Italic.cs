
namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML I element
  /// </summary>
  public class Italic : HtmlElement
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text to be displayed</param>
    public Italic(string text)
      : base(HtmlTag.I)
    {
      Tag.SetInnerText(text);
    }      

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public Italic(object htmlAttributes = null)
      : base(HtmlTag.I, htmlAttributes)
    { }
  }
}
