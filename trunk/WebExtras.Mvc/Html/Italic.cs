using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.Mvc.Html
{
  public class Italic : HtmlElement
  {
    public Italic(object htmlAttributes)
      : base(HtmlTag.I, htmlAttributes)
    { }
  }
}
