using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

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
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    public override string ToHtmlString(TagRenderMode renderMode)
    {
      return string.Empty;
    }
  }
}
