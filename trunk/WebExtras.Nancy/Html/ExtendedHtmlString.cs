using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ViewEngines.Razor;
using WebExtras.Component;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  /// Default implementation of <see cref="IExtendedHtmlString"/>
  /// </summary>
  public class ExtendedHtmlString : IExtendedHtmlString
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="component">A HTML component to initialise with</param>
    public ExtendedHtmlString(IHtmlComponent component)
    {
      Component = component;
    }

    /// <summary>Returns an HTML-encoded string.</summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      string html = Component.ToHtml();

      return new NonEncodedHtmlString(html).ToHtmlString();
    }

    /// <summary>
    /// Underlying HTML component
    /// </summary>
    public IHtmlComponent Component { get; private set; }
  }
}
