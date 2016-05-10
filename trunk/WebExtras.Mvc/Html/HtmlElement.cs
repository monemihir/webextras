// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using WebExtras.Core;
using WebExtras.Html;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Represents an HTML element
  /// </summary>
  [Serializable]
  public class HtmlElement : IExtendedHtmlString
  {
    #region Attributes

    /// <summary>
    ///   A collection of all supported HTML tags
    /// </summary>
    public static readonly List<string> SupportedTags;

    /// <summary>
    ///   Random number generator
    /// </summary>
    private static Random m_rand;

    /// <summary>
    ///   MVC HTML tag builder object
    /// </summary>
    private readonly TagBuilder m_tag;

    /// <summary>
    ///   The HTML tag representing this element
    /// </summary>
    private readonly EHtmlTag m_htmlTag;

    /// <summary>
    ///   CSS classes of this element
    /// </summary>
    public CssClassList CSSClasses { get; private set; }

    /// <summary>
    ///   HTML attribute list for this element
    /// </summary>
    public IDictionary<string, string> Attributes { get { return m_tag.Attributes; } }

    /// <summary>
    ///   Inner HTML of the element
    /// </summary>
    public string InnerHtml { get { return m_tag.InnerHtml; } set { m_tag.InnerHtml = value; } }

    /// <summary>
    ///   Underlying HTML component
    /// </summary>
    public IHtmlComponent Component { get; protected set; }

    /// <summary>
    ///   The HTML tag representing this element
    /// </summary>
    public EHtmlTag Tag { get { return m_htmlTag; } }

    /// <summary>
    ///   Inner HTML tags to be appended
    /// </summary>
    public List<IExtendedHtmlString> AppendTags { get; private set; }

    /// <summary>
    ///   Inner HTML tags to be prepended
    /// </summary>
    public List<IExtendedHtmlString> PrependTags { get; private set; }

    #endregion Attributes

    #region Ctors

    /// <summary>
    ///   Static constructor to initialise static/readonly fields
    /// </summary>
    static HtmlElement()
    {
      SupportedTags = new List<string>();
      Array vals = Enum.GetValues(typeof(EHtmlTag));

      foreach (object val in vals)
      {
        if (val.ToString() != "Empty")
          SupportedTags.Add(val.ToString().ToLowerInvariant());
      }
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="component">A HTML component to initialise with</param>
    public HtmlElement(IHtmlComponent component)
    {
      Component = component;

      m_htmlTag = component.Tag;

      m_tag = new TagBuilder(m_htmlTag.ToString().ToLowerInvariant());
      m_tag.MergeAttributes(component.Attributes);

      CSSClasses = component.CssClasses;

      InnerHtml = component.InnerHtml;

      AppendTags = new List<IExtendedHtmlString>();
      AppendTags.AddRange(component.AppendTags.Select(f => f.ToHtmlElement()));

      PrependTags = new List<IExtendedHtmlString>();
      PrependTags.AddRange(component.PrependTags.Select(f => f.ToHtmlElement()));
    }

    /// <summary>
    ///   Default constructor
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    public HtmlElement(EHtmlTag tag)
    {
      m_htmlTag = tag;

      m_tag = new TagBuilder(tag.ToString().ToLowerInvariant());
      m_rand = new Random(DateTime.Now.Millisecond);

      CSSClasses = new CssClassList();
      AppendTags = new List<IExtendedHtmlString>();
      PrependTags = new List<IExtendedHtmlString>();
    }

    /// <summary>
    ///   Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlElement(EHtmlTag tag, object htmlAttributes)
      : this(tag)
    {
      if (htmlAttributes == null)
        return;

      IDictionary<string, object> attribs = null;

      try
      {
        attribs = (IDictionary<string, object>) htmlAttributes;
      }
      catch (Exception)
      {
        attribs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
      }

      if (attribs.ContainsKey("class"))
      {
        CSSClasses.Add(attribs["class"].ToString());
        attribs.Remove("class");
      }

      m_tag.MergeAttributes(attribs);
    }

    #endregion Ctors

    /// <summary>
    ///   Gets or sets the value for the attribute specified
    /// </summary>
    /// <param name="attribute">Attribute to get or set value</param>
    /// <returns>Value of attribute if available, else null</returns>
    public string this[string attribute]
    {
      get { return Attributes.ContainsKey(attribute) ? Attributes[attribute] : string.Empty; }
      set { Attributes[attribute] = value; }
    }

    #region Append/Prepend

    /// <summary>
    ///   Appends the given text at end of current element
    /// </summary>
    /// <param name="text">Text to be added</param>
    public virtual void Append(string text)
    {
      HtmlElement e = new HtmlElement(WebExtrasConstants.DefaultTagForTextEncapsulation);
      e.InnerHtml = text;
      Append(e);
    }

    /// <summary>
    ///   Appends the given HTML element at the end of the current
    ///   element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    public virtual void Append(IExtendedHtmlString element)
    {
      if (element != null)
        AppendTags.AddRange(new[] {element});
    }

    /// <summary>
    ///   Appends the given HTML elements at the end of the current
    ///   element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    public virtual void Append(IEnumerable<IExtendedHtmlString> elements)
    {
      AppendTags.AddRange(elements);
    }

    /// <summary>
    ///   Prepends the given text at the beginning of current element
    /// </summary>
    /// <param name="text">Text to be added</param>
    public virtual void Prepend(string text)
    {
      HtmlElement e = new HtmlElement(WebExtrasConstants.DefaultTagForTextEncapsulation);
      e.InnerHtml = text;
      Prepend(e);
    }

    /// <summary>
    ///   Prepends the given HTML element at the beginning of
    ///   the current element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    public virtual void Prepend(IExtendedHtmlString element)
    {
      if (element != null)
        PrependTags.AddRange(new[] {element});
    }

    /// <summary>
    ///   Prepends the given HTML elements at the beginning of
    ///   the current element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    public virtual void Prepend(IEnumerable<IExtendedHtmlString> elements)
    {
      PrependTags.AddRange(elements);
    }

    #endregion Append/Prepend

    #region ToHtmlString

    /// <summary>
    ///   Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public string ToHtmlString()
    {
      return ToHtmlString(TagRenderMode.Normal);
    }

    /// <summary>
    ///   Converts current element to a MVC HTMl string with
    ///   the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    public virtual string ToHtmlString(TagRenderMode renderMode)
    {
      if (Tag == EHtmlTag.Empty)
        return string.Empty;

      if (!Attributes.ContainsKey("id") && WebExtrasConstants.EnableAutoIdGeneration)
        this["id"] = string.Format("auto_{0}", m_rand.Next(1, 9999));

      if (m_tag.Attributes.ContainsKey("class"))
        CSSClasses.Add(m_tag.Attributes["class"]);

      if (CSSClasses.Count > 0)
        this["class"] = string.Join(" ", CSSClasses.Distinct());

      m_tag.InnerHtml =
        string.Join("", PrependTags.Select(f => f.ToHtmlString())) +
        m_tag.InnerHtml +
        string.Join("", AppendTags.Select(f => f.ToHtmlString()));

      string result = m_tag.ToString(renderMode);

      return result;
    }

    #endregion ToHtmlString

    /// <summary>
    ///   Empty string
    /// </summary>
    public static IExtendedHtmlString Empty { get { return new HtmlElement(EHtmlTag.Empty); } }

    #region Parse

    /// <summary>
    ///   Parse the given HTML to a HtmlElement. Note the HTML given
    ///   must be valid XML.
    /// </summary>
    /// <param name="html">HTML to be parsed</param>
    /// <returns>The parsed HtmlElement</returns>
    /// <exception cref="System.NotSupportedException">Thrown if an unsupported HTML tag is encountered</exception>
    public static HtmlElement Parse(string html)
    {
      return ParseElement(XElement.Parse(html));
    }

    /// <summary>
    ///   Parse an XML valid node to a HtmlElement
    /// </summary>
    /// <param name="element">Element to be parsed</param>
    /// <returns>The parsed HtmlElement</returns>
    /// <exception cref="System.NotSupportedException">Thrown if an unsupported HTML tag is encountered</exception>
    private static HtmlElement ParseElement(XElement element)
    {
      // check if we support the given parent tag
      if (!SupportedTags.Contains(element.Name.LocalName.ToLowerInvariant()))
        throw new NotSupportedException(
          string.Format("{0} tag is not supported. Only the following HTML tags are supported: {1}.",
            element.Name.LocalName.ToUpperInvariant(),
            string.Join(", ", SupportedTags.Select(f => f.ToUpperInvariant()))));

      EHtmlTag tag = (EHtmlTag) Enum.Parse(typeof(EHtmlTag), element.Name.LocalName.ToTitleCase());

      // get the attributes of the element as HTML attributes dictionary
      IDictionary<string, object> htmlAttributes = element.Attributes()
        .ToDictionary(f => f.Name.LocalName.ToLowerInvariant(), v => (object) v.Value);

      HtmlElement html = new HtmlElement(tag, htmlAttributes);

      if (!element.HasElements)
      {
        // this means that the current element does not have any child elements 
        // and that it is only a text element or an empty element
        html.InnerHtml = element.Value;
        return html;
      }

      if (!element.Nodes().Any())
        return html;

      foreach (XNode node in element.Nodes())
      {
        string text = node.ToString();

        // if the current node is a text node, enclose it in a SPAN object
        // in order to preserve the order of elements in the finally parsed
        // HtmlElement object, otherwise try to parse the node as a full 
        // fledged element and start recursion

        // TODO: check whether there are any INFINITE LOOP conditions which
        // will make the function throw OutOfMemoryException
        HtmlElement parsed = node.NodeType == XmlNodeType.Text ? new Span(text) : Parse(text);

        html.Prepend(parsed);
      }

      return html;
    }

    #endregion Parse
  }
}