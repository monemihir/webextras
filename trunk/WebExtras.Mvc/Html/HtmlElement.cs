/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML element
  /// </summary>
  [Serializable]
  public class HtmlElement : IExtendedHtmlString
  {
    /// <summary>
    /// Random number generator
    /// </summary>
    private static Random m_rand;

    /// <summary>
    /// MVC HTML tag builder object
    /// </summary>
    private TagBuilder m_tag;

    /// <summary>
    /// CSS classes of this element
    /// </summary>
    public CssClassesCollection CSSClasses { get; private set; }

    /// <summary>
    /// HTML attribute list for this element
    /// </summary>
    public IDictionary<string, string> Attributes { get { return m_tag.Attributes; } }

    /// <summary>
    /// Inner HTML of the element
    /// </summary>
    public string InnerHtml { get { return m_tag.InnerHtml; } set { m_tag.InnerHtml = value; } }

    /// <summary>
    /// Inner HTML tags to be appended
    /// </summary>
    public List<IExtendedHtmlString> AppendTags { get; private set; }

    /// <summary>
    /// Inner HTML tags to be prepended
    /// </summary>
    public List<IExtendedHtmlString> PrependTags { get; private set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    public HtmlElement(EHtmlTag tag)
    {
      string tagName = tag.GetStringValue();

      m_tag = new TagBuilder(string.IsNullOrEmpty(tagName) ? tag.ToString().ToLowerInvariant() : tagName);
      m_rand = new Random(DateTime.Now.Millisecond);

      CSSClasses = new CssClassesCollection();
      AppendTags = new List<IExtendedHtmlString>();
      PrependTags = new List<IExtendedHtmlString>();
    }

    /// <summary>
    /// Constructor to specify a dictionary of extra HTML attributes
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlElement(EHtmlTag tag, IDictionary<string, object> htmlAttributes)
      : this(tag)
    {
      if (htmlAttributes != null)
        m_tag.MergeAttributes(htmlAttributes);
    }

    /// <summary>
    /// Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlElement(EHtmlTag tag, object htmlAttributes)
      : this(tag)
    {
      if (htmlAttributes != null)
        m_tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Gets or sets the value for the attribute specified
    /// </summary>
    /// <param name="attribute">Attribute to get or set value</param>
    /// <returns>Value of attribute if available, else null</returns>
    public string this[string attribute]
    {
      get { return Attributes.ContainsKey(attribute) ? Attributes[attribute] : string.Empty; }
      set { Attributes[attribute] = value; }
    }

    /// <summary>
    /// Appends the given HTML element at the end of the current 
    /// element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    public void Append(IExtendedHtmlString element)
    {
      AppendTags.Add(element);
    }

    /// <summary>
    /// Appends the given HTML elements at the end of the current 
    /// element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    public void Append(IEnumerable<IExtendedHtmlString> elements)
    {
      AppendTags.AddRange(elements);
    }

    /// <summary>
    /// Prepends the given HTML element at the beginning of
    /// the current element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    public void Prepend(IExtendedHtmlString element)
    {
      PrependTags.Add(element);
    }

    /// <summary>
    /// Prepends the given HTML elements at the beginning of
    /// the current element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    public void Prepend(IEnumerable<IExtendedHtmlString> elements)
    {
      PrependTags.AddRange(elements);
    }

    /// <summary>
    /// Converts current element to a MVC HTML string
    /// </summary>
    /// <returns>MVC HTML string representation of current element</returns>
    public string ToHtmlString()
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
      if (!Attributes.ContainsKey("id") && WebExtrasMvcConstants.EnableAutoIdGeneration)
        this["id"] = string.Format("auto_{0}", m_rand.Next(1, 9999));

      if (CSSClasses.Count > 0)
        this["class"] += " " + string.Join(" ", CSSClasses.Distinct());

      m_tag.InnerHtml =
        string.Join("", PrependTags.Select(f => f.ToHtmlString())) +
        m_tag.InnerHtml +
        string.Join("", AppendTags.Select(f => f.ToHtmlString()));

      string result = m_tag.ToString(renderMode);

      return result;
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
