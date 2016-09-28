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
using System.Collections.Specialized;
using System.Linq;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   An abstract HTML component
  /// </summary>
  [Serializable]
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

    /// <summary>
    ///   Hook into the rendering pipeline just before the render operation starts
    /// </summary>
    protected virtual void PreRender()
    {
      // nothing to do here
    }

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
      PreRender();

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

      List<string> parts = new List<string> {"<" + Tag.ToString().ToLowerInvariant()};

      string attribs = " " + string.Join(" ", Attributes.Select(f => string.Format("{0}=\"{1}\"", f.Key, f.Value)));

      parts.Add(attribs);

      if (Tag == EHtmlTag.Img || Tag == EHtmlTag.Input)
        parts.Add("/>");
      else
      {
        parts.Add(">");

        if (!string.IsNullOrWhiteSpace(innerHtml))
          parts.Add(innerHtml);

        parts.Add("</" + Tag.ToString().ToLowerInvariant() + ">");
      }

      string result = string.Join(string.Empty, parts);

      return result;
    }

    #endregion Implementation of IHtmlComponent
  }
}