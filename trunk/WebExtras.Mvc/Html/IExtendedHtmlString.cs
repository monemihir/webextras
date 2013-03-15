using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Base interface to be implemented by an HTML element
  /// </summary>
  public interface IExtendedHtmlString : IHtmlString
  {
    /// <summary>
    /// An MVC tag builder
    /// </summary>
    TagBuilder Tag { get; set; }

    /// <summary>
    /// Inner tags
    /// </summary>
    List<IExtendedHtmlString> AppendTags { get; }

    /// <summary>
    /// Appends the given HTML element at the end of the current 
    /// element
    /// </summary>
    /// <param name="html">HTML element to be added</param>    
    void AppendElement(IExtendedHtmlString html);

    /// <summary>
    /// Prepends the given HTML element at the beginning of
    /// the current element
    /// </summary>
    /// <param name="html">HTML element to be added</param>
    void PrependElement(IExtendedHtmlString html);

    /// <summary>
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    string ToHtmlString(TagRenderMode renderMode);
  }
}
