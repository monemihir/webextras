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
using System.Collections.Specialized;
using System.Linq;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   An abstract HTML component
  /// </summary>
  public class HtmlComponent : IHtmlComponent
  {
    /// <summary>
    ///   A collection of all supported HTML tags
    /// </summary>
    public static readonly List<string> SupportedTags;

    /// <summary>
    ///   Empty HTML component
    /// </summary>
    public static IHtmlComponent Empty { get { return new HtmlComponent(EHtmlTag.Empty); } }

    #region ctors

    /// <summary>
    ///   Static constructor to initialise static/readonly fields
    /// </summary>
    static HtmlComponent()
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
    /// <param name="tag">The HTML tag to initialise with</param>
    public HtmlComponent(EHtmlTag tag)
      : this(tag, null)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public HtmlComponent(EHtmlTag tag, object htmlAttributes)
    {
      Tag = tag;
      Attributes = new Dictionary<string, string>();
      CssClasses = new CssClassList();

      AppendTags = new HtmlComponentList();
      PrependTags = new HtmlComponentList();

      if (htmlAttributes == null)
        return;

      bool isDict = (htmlAttributes as IDictionary<string, string>) != null;

      if (isDict)
      {
        Attributes = (IDictionary<string, string>) htmlAttributes;

        return;
      }

      NameValueCollection attribs = WebExtrasUtil.AnonymousObjectToHtmlAttributes(htmlAttributes);

      foreach (string key in attribs.Keys)
        Attributes[key] = attribs[key];
    }

    #endregion ctors

    #region Implementation of IHtmlComponent

    /// <summary>
    ///   The HTML tag representing this component
    /// </summary>
    public EHtmlTag Tag { get; private set; }

    /// <summary>
    ///   CSS classes of this component
    /// </summary>
    public CssClassList CssClasses { get; private set; }

    /// <summary>
    ///   HTML attribute list for this component
    /// </summary>
    public IDictionary<string, string> Attributes { get; private set; }

    /// <summary>
    ///   Inner HTML of the component
    /// </summary>
    public string InnerHtml { get; set; }

    /// <summary>
    ///   Tags to appended to the current component. Note these tags are
    ///   appended before the <see cref="IHtmlComponent.InnerHtml" /> when the component
    ///   gets serialized to a HTML string
    /// </summary>
    public HtmlComponentList PrependTags { get; private set; }

    /// <summary>
    ///   Tags to appended to the current component. Note these tags are
    ///   appended after the <see cref="IHtmlComponent.InnerHtml" /> when the component
    ///   gets serialized to a HTML string
    /// </summary>
    public HtmlComponentList AppendTags { get; private set; }

    /// <summary>
    ///   Converts current HTML component to a HTML encoded string
    /// </summary>
    /// <returns></returns>
    public virtual string ToHtml()
    {
      if (Tag == EHtmlTag.Empty)
        return string.Empty;

      if (Attributes.ContainsKey("class"))
        CssClasses.Add(Attributes["class"]);

      if (CssClasses.Count > 0)
        Attributes["class"] = string.Join(" ", CssClasses.Distinct());

      string innerHtml = string.Empty;

      if (Tag != EHtmlTag.Img)
      {
        innerHtml =
          string.Join("", PrependTags.Select(f => f.ToHtml())) +
          InnerHtml +
          string.Join("", AppendTags.Select(f => f.ToHtml()));
      }

      List<string> parts = new List<string>();
      parts.Add("<" + Tag.ToString().ToLowerInvariant());
      parts.AddRange(Attributes.Select(f => string.Format("{0}=\"{1}\"", f.Key, f.Value)));

      if (Tag == EHtmlTag.Img || Tag == EHtmlTag.Input)
        parts.Add("/>");
      else
      {
        parts.Add(">");

        if (!string.IsNullOrWhiteSpace(innerHtml))
          parts.Add(innerHtml);

        parts.Add("</" + Tag.ToString().ToLowerInvariant() + ">");
      }

      string result = string.Join(" ", parts);

      return result;
    }

    #endregion Implementation of IHtmlComponent
  }
}