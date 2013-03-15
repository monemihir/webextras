using System.Collections.Generic;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML element
  /// </summary>
  public class HtmlElement : IExtendedHtmlString
  {
    /// <summary>
    /// MVC HTML tag builder object
    /// </summary>
    public TagBuilder Tag { get; set; }

    /// <summary>
    /// Inner HTML tags
    /// </summary>
    public List<IExtendedHtmlString> InnerTags { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    public HtmlElement(HtmlTag tag)
    {
      Tag = new TagBuilder(tag.ToString().ToLowerInvariant());
      InnerTags = new List<IExtendedHtmlString>();
    }

    /// <summary>
    /// Constructor to specify a dictionary of extra HTML attributes
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlElement(HtmlTag tag, IDictionary<string, object> htmlAttributes)
      : this(tag)
    {
      if (htmlAttributes != null)
        Tag.MergeAttributes<string, object>(htmlAttributes);
    }

    /// <summary>
    /// Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="htmlAttributes"></param>
    public HtmlElement(HtmlTag tag, object htmlAttributes)
      : this(tag)
    {
      if (htmlAttributes != null)
        Tag.MergeAttributes<string, object>(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Gets or sets the value for the attribute specified
    /// </summary>
    /// <param name="attribute">Attribute to get or set value</param>
    /// <returns>Value of attribute if available, else null</returns>
    public string this[string attribute]
    {
      get { return Tag.Attributes.ContainsKey(attribute) ? Tag.Attributes[attribute].ToString() : null; }
      set
      {
        if (Tag.Attributes.ContainsKey(attribute))
          Tag.Attributes[attribute] += " " + value;
        else
          Tag.Attributes.Add(attribute, value);
      }
    }

    /// <summary>
    /// Appends the given HTML element at the end of the current 
    /// element
    /// </summary>
    /// <param name="html">HTML element to be added</param>
    public void AppendElement(IExtendedHtmlString html)
    {
      InnerTags.Add(html);
    }

    /// <summary>
    /// Prepends the given HTML element at the beginning of
    /// the current element
    /// </summary>
    /// <param name="html">HTML element to be added</param>
    public void PrependElement(IExtendedHtmlString html)
    {
      InnerTags.Insert(0, html);
    }

    /// <summary>
    /// Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public virtual string ToHtmlString()
    {
      return ToHtmlString(TagRenderMode.Normal);
    }

    /// <summary>
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    public virtual string ToHtmlString(TagRenderMode renderMode)
    {
      return Tag.ToString(renderMode);
    }

    /// <summary>
    /// Empty string
    /// </summary>
    public static IExtendedHtmlString Empty
    {
      get { return new Empty(); }
    }
  }
}
