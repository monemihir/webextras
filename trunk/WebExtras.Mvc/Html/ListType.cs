using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// A collection of list types
  /// </summary>
  public enum ListType
  {
    /// <summary>
    /// An ordered list
    /// </summary>
    [StringValue("ol")]
    Ordered,

    /// <summary>
    /// An unordered list
    /// </summary>
    [StringValue("ul")]
    Unordered,
  }
}
