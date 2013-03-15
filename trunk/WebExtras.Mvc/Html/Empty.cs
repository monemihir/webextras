using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// An empty HTML tag
  /// </summary>
  public class Empty : HtmlElement
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    public Empty()
      : base(HtmlTag.Empty)
    { }

    /// <summary>
    /// Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public override string ToHtmlString()
    {
      return string.Empty;
    }

    /// <summary>
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    public override string ToHtmlString(System.Web.Mvc.TagRenderMode renderMode)
    {
      return string.Empty;
    }
  }
}
