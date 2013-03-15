using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Generic extension for an extended html string
  /// </summary>
  public static class ExtendedHtmlStringExtension
  {
    /// <summary>
    /// Converts the current hyperlink to a javascript link
    /// </summary>
    /// <param name="html">Hyperlink to be converted</param>
    /// <returns>Converted hyperlink</returns>
    public static IExtendedHtmlString AsJavascriptLink(this IExtendedHtmlString html)
    {
      if (html.Tag.Attributes.ContainsKey("href"))
      {
        string url = html.Tag.Attributes["href"];
        html.Tag.Attributes["href"] = "javascript:" + (url.EndsWith("()") ? url : url + "()");
      }

      return html;
    }
  }
}
