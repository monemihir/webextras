using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  public class Hyperlink : HtmlElement
  {
    public string Text { get; set; }

    public string Url { get; set; }

    public Hyperlink(string linkText, string url, object htmlAttributes)
      : base(HtmlTag.A, htmlAttributes)
    {
      Text = linkText;
      Url = url;      
    }

    public Hyperlink(string linkText, string url, IDictionary<string, object> htmlAttributes)
      : base(HtmlTag.A, htmlAttributes)
    {
      Text = linkText;
      Url = url;
    }

    public override string ToHtmlString()
    {
      return ToHtmlString(TagRenderMode.Normal);
    }

    public override string ToHtmlString(TagRenderMode renderMode)
    {
      Tag.Attributes["href"] = Url;
      Tag.InnerHtml = string.Join("", InnerTags.Select(f => f.ToHtmlString())) + Text;

      return Tag.ToString(renderMode);
    }
  }  
}
