using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Hyperlink extension methods
  /// </summary>
  public static class HyperlinkExtension
  {
    /// <summary>
    /// Converts the current hyperlink to a javascript link
    /// </summary>
    /// <param name="html">Hyperlink to be converted</param>
    /// <returns>Converted hyperlink</returns>
    public static Hyperlink AsJavascriptLink(this Hyperlink html)
    {
      html.Url = "javascript:" + (html.Url.EndsWith("()") ? html.Url : html.Url + "()");

      return html;
    }
  }
}
