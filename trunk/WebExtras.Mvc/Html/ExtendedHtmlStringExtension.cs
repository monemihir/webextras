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
    /// Converts the current HTML element to a javascript hyperlink link if possible
    /// </summary>
    /// <param name="html">HTML element to be converted</param>
    /// <returns>Converted hyperlink</returns>
    public static IExtendedHtmlString AsJavascriptLink(this IExtendedHtmlString html)
    {
      if (html.Tag.Attributes.ContainsKey("href"))
      {
        html.Tag.Attributes["href"] = "javascript:" + html.Tag.Attributes["href"];
      }

      return html;
    }

    /// <summary>
    /// Adds given CSS class(es) to the current HTML element
    /// </summary>
    /// <param name="html">HTML element to add class to</param>
    /// <param name="css">CSS class(es) to be added</param>
    /// <returns>Current HTML element with classes added</returns>
    public static IExtendedHtmlString AddCssClass(this IExtendedHtmlString html, string css)
    {
      html.Tag.AddCssClass(css);

      return html;
    }
  }
}
