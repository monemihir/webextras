using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents a HTML LIST element
  /// </summary>
  public class HtmlList : HtmlElement
  {
    /// <summary>
    /// List type
    /// </summary>
    public ListType Type { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of list</param>
    /// <param name="listItems">A collection of items</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlList(ListType type, IEnumerable<HtmlListItem> listItems, object htmlAttributes = null)
      : base(HtmlTag.List, htmlAttributes)
    {
      Tag = new TagBuilder(type.GetStringValue());
      AppendTags.AddRange(listItems);
    }
  }
}
