using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML LIST ITEM element
  /// </summary>
  public class HtmlListItem : HtmlElement
  {
    /// <summary>
    /// List item text
    /// </summary>
    public string Text { get { return Tag.InnerHtml; } set { Tag.InnerHtml = value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">List item text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlListItem(string text, object htmlAttributes = null)
      : base(HtmlTag.ListItem, htmlAttributes)
    {
      Tag = new TagBuilder("li");
      Text = text;
    }
  }
}
