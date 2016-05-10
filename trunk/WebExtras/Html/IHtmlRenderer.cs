using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtras.Html
{
  /// <summary>
  /// An HTML renderer
  /// </summary>
  public interface IHtmlRenderer
  {
    /// <summary>
    ///   Converts current HTML component as a string
    /// </summary>
    /// <returns>Current HTML component as a string</returns>
    string ToHtml();
  }
}
