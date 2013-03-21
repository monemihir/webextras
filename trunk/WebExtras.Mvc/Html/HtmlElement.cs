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

using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Represents an HTML element
  /// </summary>
  public class HtmlElement : IExtendedHtmlString
  {
    /// <summary>
    /// Random number generator
    /// </summary>
    private static Random m_rand;

    /// <summary>
    /// MVC HTML tag builder object
    /// </summary>
    public TagBuilder Tag { get; set; }

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
    public HtmlElement(HtmlTag tag)
    {
      Tag = new TagBuilder(tag.ToString().ToLowerInvariant());
      m_rand = new Random(DateTime.Now.Millisecond);

      AppendTags = new List<IExtendedHtmlString>();
      PrependTags = new List<IExtendedHtmlString>();
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
      AppendTags.Add(html);
    }

    /// <summary>
    /// Prepends the given HTML element at the beginning of
    /// the current element
    /// </summary>
    /// <param name="html">HTML element to be added</param>
    public void PrependElement(IExtendedHtmlString html)
    {
      PrependTags.Add(html);
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
      if (!Tag.Attributes.ContainsKey("id"))
        this["id"] = string.Format("auto_{0}", m_rand.Next(1, 9999).ToString());
      
      Tag.InnerHtml =
        string.Join("", PrependTags.Select(f => f.ToHtmlString())) +
        Tag.InnerHtml +
        string.Join("", AppendTags.Select(f => f.ToHtmlString()));

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
