// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
  public class HtmlElement : IExtendedHtmlStringLegacy
  {
    #region Attributes

    /// <summary>
    ///   A collection of all supported HTML tags
    /// </summary>
    public static readonly List<string> SupportedTags;

    /// <summary>
    ///   CSS classes of this element
    /// </summary>
    public CssClassList CSSClasses { get { return Component.CssClasses; } }

    /// <summary>
    ///   HTML attribute list for this element
    /// </summary>
    public IDictionary<string, string> Attributes { get { return Component.Attributes; } }

    /// <summary>
    ///   Inner HTML of the element
    /// </summary>
    public string InnerHtml { get { return Component.InnerHtml; } set { Component.InnerHtml = value; } }

    /// <summary>
    ///   Underlying HTML component
    /// </summary>
    public IHtmlComponent Component { get; private set; }

    /// <summary>
    ///   The HTML tag representing this element
    /// </summary>
    public EHtmlTag Tag { get { return Component.Tag; } }

    /// <summary>
    ///   Inner HTML tags to be appended
    /// </summary>
    public List<IExtendedHtmlStringLegacy> AppendTags
    {
      get { return Component.AppendTags.Select(f => f.ToHtmlElement()).ToList<IExtendedHtmlStringLegacy>(); }
    }

    /// <summary>
    ///   Inner HTML tags to be prepended
    /// </summary>
    public List<IExtendedHtmlStringLegacy> PrependTags
    {
      get { return Component.PrependTags.Select(f => f.ToHtmlElement()).ToList<IExtendedHtmlStringLegacy>(); }
    }

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
    }

    /// <summary>
    ///   Default constructor
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    public HtmlElement(EHtmlTag tag)
    {
      Component = new HtmlComponent(tag);
    }

    /// <summary>
    ///   Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlElement(EHtmlTag tag, object htmlAttributes)
    {
      Component = new HtmlComponent(tag, htmlAttributes);
    }

    #endregion Ctors

    /// <summary>
    ///   Gets or sets the value for the attribute specified
    /// </summary>
    /// <param name="attribute">Attribute to get or set value</param>
    /// <returns>Value of attribute if available, else null</returns>
    public string this[string attribute]
    {
      get { return Component.Attributes.ContainsKey(attribute) ? Component.Attributes[attribute] : string.Empty; }
      set { Component.Attributes[attribute] = value; }
    }

    #region Append/Prepend

    /// <summary>
    ///   Appends the given text at end of current element
    /// </summary>
    /// <param name="text">Text to be added</param>
    public virtual void Append(string text)
    {
      Component.AppendTags.Add(text);
    }

    /// <summary>
    ///   Appends the given HTML element at the end of the current
    ///   element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    public virtual void Append(IExtendedHtmlStringLegacy element)
    {
      Component.AppendTags.Add(element.Component);
    }

    /// <summary>
    ///   Appends the given HTML elements at the end of the current
    ///   element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    public virtual void Append(IEnumerable<IExtendedHtmlStringLegacy> elements)
    {
      Component.AppendTags.AddRange(elements.Select(e => e.Component));
    }

    /// <summary>
    ///   Prepends the given text at the beginning of current element
    /// </summary>
    /// <param name="text">Text to be added</param>
    public virtual void Prepend(string text)
    {
      Component.PrependTags.Add(text);
    }

    /// <summary>
    ///   Prepends the given HTML element at the beginning of
    ///   the current element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    public virtual void Prepend(IExtendedHtmlStringLegacy element)
    {
      Component.PrependTags.Add(element.Component);
    }

    /// <summary>
    ///   Prepends the given HTML elements at the beginning of
    ///   the current element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    public virtual void Prepend(IEnumerable<IExtendedHtmlStringLegacy> elements)
    {
      Component.PrependTags.AddRange(elements.Select(e => e.Component));
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
      string result = MvcHtmlString.Create(Component.ToHtml()).ToHtmlString();

      return result;
    }

    #endregion ToHtmlString

    /// <summary>
    ///   Empty string
    /// </summary>
    public static IExtendedHtmlStringLegacy Empty { get { return new HtmlElement(EHtmlTag.Empty); } }

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
      IDictionary<string, string> htmlAttributes = element.Attributes()
        .ToDictionary(f => f.Name.LocalName.ToLowerInvariant(), v => v.Value);

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