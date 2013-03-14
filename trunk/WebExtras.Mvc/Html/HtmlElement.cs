using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace WebExtras.Mvc.Html
{
  public class HtmlElement : IHtmlString
  {
    /// <summary>
    /// Html tag
    /// </summary>
    public TagBuilder Tag { get; set; }

    public List<IHtmlString> InnerTags { get; set; }

    protected IDictionary<string, object> Attributes;

    public HtmlElement(HtmlTag element)
    {
      Tag = new TagBuilder(element.ToString().ToLowerInvariant());
      InnerTags = new List<IHtmlString>();
    }

    public HtmlElement(HtmlTag element, IDictionary<string, object> htmlAttributes)
      : this(element)
    {
      Attributes = htmlAttributes != null ? htmlAttributes : new Dictionary<string, object>();
    }

    public HtmlElement(HtmlTag element, object htmlAttributes)
      : this(element)
    {
      Attributes = htmlAttributes != null ? (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) : new Dictionary<string, object>();
    }

    public string this[string attribute]
    {
      get { return Attributes.ContainsKey(attribute) ? Attributes[attribute].ToString() : null; }
      set
      {
        if (Attributes.ContainsKey(attribute))
          Attributes[attribute] += " " + value;
        else
          Attributes.Add(attribute, value);
      }
    }

    public bool HasAttribute(string attribute)
    {
      return Attributes.ContainsKey(attribute);
    }

    protected void SetAttribute(string attribute, string value, bool overwrite = false)
    {
      if (Attributes.ContainsKey(attribute))
      {
        if (overwrite)
          Attributes[attribute] = " " + value;
        else
          Attributes[attribute] += " " + value;
      }
      else
        Attributes.Add(attribute, value);
    }

    public void AppendElement(IHtmlString html)
    {
      InnerTags.Add(html);
    }

    public void PrependElement(IHtmlString html)
    {
      InnerTags.Insert(0, html);
    }
        
    public virtual string ToHtmlString()
    {
      return ToHtmlString(TagRenderMode.Normal);
    }

    public virtual string ToHtmlString(TagRenderMode renderMode)
    {
      Tag.MergeAttributes<string, object>(Attributes);

      return Tag.ToString(renderMode);
    }
  }
}
