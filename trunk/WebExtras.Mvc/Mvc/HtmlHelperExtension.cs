/*
* This file is part of - Code Library
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
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebExtras.Mvc.Mvc
{
  /// <summary>
  /// Generic HTML helper extension methods
  /// </summary>
  public static class HtmlHelperExtension
  {
    /// <summary>
    /// Default separator used to join stuff
    /// </summary>
    private const string DefaultSeparator = " | ";

    #region Hyperlink extensions

    /// <summary>
    /// Displays an image hyperlink
    /// </summary>
    /// <param name="html">Current HTMLHelper object</param>
    /// <param name="imageSrc">Image source</param>
    /// <param name="altText">Alternate text if the image can't be shown</param>
    /// <param name="url">URL for hyperlink</param>
    /// <param name="isJavascriptLink">[Optional] Flag indicating whether this is
    /// a javascript link</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only. Defaults to null</param>
    /// <returns>HTML ImageHyperLink</returns>
    public static MvcHtmlString ImageLink(
      this HtmlHelper html,
      string imageSrc,
      string altText,
      string url,
      bool isJavascriptLink = false,
      object htmlAttributes = null)
    {
      TagBuilder a = new TagBuilder("a");
      a.Attributes["style"] = "text-decoration: none; border: 0";
      a.Attributes["href"] = isJavascriptLink ? "javascript:" + url : url;
      a.Attributes["title"] = altText;
      a.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      TagBuilder img = new TagBuilder("img");
      img.Attributes["style"] = "border: 0; vertical-align: top";
      img.Attributes["src"] = imageSrc;
      img.Attributes["alt"] = altText;

      a.InnerHtml = img.ToString(TagRenderMode.SelfClosing);

      return MvcHtmlString.Create(a.ToString());
    }

    /// <summary>
    /// HTML hyperlink to given URL with the given
    /// text
    /// </summary>
    /// <param name="html">Current HTMLHelper object</param>
    /// <param name="linkText">Text to display for the link</param>
    /// <param name="url">URL for hyperlink. This can be either a url or a javascript event</param>
    /// <param name="isJavascriptLink">[Optional] If the value specified for the 'url' parameter is
    /// to be treated as a javascript function call, this parameter must be set to true. Defaults to
    /// false.</param>
    /// <param name="htmlAttributes">HTML attributes</param>
    /// <returns>HTML Hyperlink</returns>
    public static MvcHtmlString HyperLink(
      this HtmlHelper html,
      string linkText,
      string url,
      bool isJavascriptLink = false,
      object htmlAttributes = null)
    {
      TagBuilder a = new TagBuilder("a");
      a.SetInnerText(linkText);

      if (isJavascriptLink)
        a.Attributes["href"] = "javascript:" + (url.EndsWith("()") ? url : url + "()");
      else
        a.Attributes["href"] = url;

      a.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      return MvcHtmlString.Create(a.ToString());
    }

    /// <summary>
    /// HTML hyperlink with an icon
    /// </summary>
    /// <param name="html">Current HTMLHelper object</param>
    /// <param name="linkText">Text to display for the link</param>
    /// <param name="url">URL for hyperlink. This can be either a url or a javascript event</param>
    /// <param name="iconClass">Icon CSS class(s) to be prepended for the link. Multiple icon classes must be separated with
    /// spaces</param>
    /// <param name="isJavascriptLink">[Optional] If the value specified for the 'url' parameter is
    /// to be treated as a javascript function call, this parameter must be set to true. Defaults to
    /// false.</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes. Defaults to null</param>
    /// <returns>HTML Hyperlink</returns>
    public static MvcHtmlString IconHyperLink(
      this HtmlHelper html,
      string linkText,
      string url,
      string iconClass,
      bool isJavascriptLink = false,
      object htmlAttributes = null)
    {
      MvcHtmlString link = HyperLink(html, linkText, url, isJavascriptLink, html);

      string iconLink = link.ToHtmlString().Replace(string.Format(">{0}", linkText), string.Format("><i class='{0}'></i>{1}", iconClass, linkText));

      return MvcHtmlString.Create(iconLink);
    }

    #endregion Hyperlink extensions

    #region Image extensions

    /// <summary>
    /// Create an HTML IMG tag
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="altText">Alt text for image</param>
    /// <param name="srcUrl">Source URL of image</param>
    /// <returns>An HTML IMG tag</returns>
    public static MvcHtmlString Image(
      this HtmlHelper htmlHelper,
      string altText,
      string srcUrl)
    {
      return Image(htmlHelper, altText, srcUrl, (IDictionary<string, object>)null);
    }

    /// <summary>
    /// Create an HTML IMG tag
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="altText">Alt text for image</param>
    /// <param name="srcUrl">Source URL of image</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>An HTML IMG tag</returns>
    public static MvcHtmlString Image(
      this HtmlHelper htmlHelper,
      string altText,
      string srcUrl,
      object htmlAttributes)
    {
      TagBuilder img = new TagBuilder("img");
      img.MergeAttributes(new RouteValueDictionary(htmlAttributes));
      img.Attributes["src"] = srcUrl;
      img.Attributes["alt"] = altText;
      return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
    }

    #endregion Image extensions

    #region Join extensions

    /// <summary>
    /// Html Helper extension method to join html strings using the Default text seperator (|)
    /// </summary>
    /// <param name="htmlHelper">Html Helper object</param>
    /// <param name="links">an array of html strings</param>
    /// <returns>A single string containing the html strings seperated by the default seperator</returns>
    public static MvcHtmlString Join(this HtmlHelper htmlHelper, params string[] links)
    {
      IEnumerable<string> htmlList = links.Where(s => !string.IsNullOrEmpty(s));
      return MvcHtmlString.Create(string.Join(DefaultSeparator, htmlList));
    }

    /// <summary>
    /// Html Helper extension method to join MVC html strings using the Default text seperator (|)
    /// </summary>
    /// <param name="htmlHelper">Html Helper object</param>
    /// <param name="links">an array of html strings</param>
    /// <returns>A single string containing the html strings seperated by the default seperator</returns>
    public static MvcHtmlString Join(this HtmlHelper htmlHelper, params MvcHtmlString[] links)
    {
      return Join(htmlHelper, links.Select(s => s.ToString()).ToArray());
    }

    #endregion Join extensions

    #region Inline extensions

    /// <summary>
    /// Html helper to return the text contained in an external file
    /// to enable the text to be inlined.
    /// </summary>
    /// <param name="htmlHelper">Html helper extension</param>
    /// <param name="relativePath">Relative path to file to be inlined.</param>
    /// <returns>MVCHtmlString representation of file contents</returns>
    public static MvcHtmlString Inline(this HtmlHelper htmlHelper, string relativePath)
    {
      string fullpath = htmlHelper.ViewContext.HttpContext.Server.MapPath(relativePath);
      StreamReader reader = null;
      string result;
      try
      {
        reader = File.OpenText(fullpath);
        result = reader.ReadToEnd();
      }
      finally
      {
        if (reader != null)
          reader.Close();
      }

      return MvcHtmlString.Create(result);
    }

    #endregion Inline extensions

    #region ImageActionLink extensions

    /// <summary>
    /// Html helper to create an Action link for an image
    /// </summary>
    /// <param name="htmlHelper">html helper extension</param>
    /// <param name="imgSrc">Url to the image file to display</param>
    /// <param name="action">Action to execute in the link</param>
    /// <returns>An image link html string</returns>
    public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, string imgSrc, ActionResult action)
    {
      return ImageActionLink(htmlHelper, imgSrc, null, action, (IDictionary<string, object>)null);
    }

    /// <summary>
    /// Html helper to create an Action link for an image
    /// </summary>
    /// <param name="htmlHelper">html helper extension</param>
    /// <param name="imgSrc">Url to the image file to display</param>
    /// <param name="altText">Alternative text to display if image not found</param>
    /// <param name="action">Action to execute in the link</param>
    /// <returns>An image link html string</returns>
    public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, string imgSrc, string altText, ActionResult action)
    {
      return ImageActionLink(htmlHelper, imgSrc, altText, action, (IDictionary<string, object>)null);
    }

    /// <summary>
    /// Html helper to create an Action link for an image
    /// </summary>
    /// <param name="htmlHelper">html helper extension</param>
    /// <param name="imgSrc">Url to the image file to display</param>
    /// <param name="altText">Alternative text to display if image not found</param>
    /// <param name="action">Action to execute in the link</param>
    /// <param name="htmlAttributes">Additional html attributes to apply to the link (A) object</param>
    /// <returns>An image link html string</returns>
    public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, string imgSrc, string altText, ActionResult action, object htmlAttributes)
    {
      altText = altText ?? string.Empty;
      string img = Image(htmlHelper, altText, imgSrc, new { style = "border:0" }).ToHtmlString();
      string linkText = T4Extensions.ActionLink(htmlHelper, "{0}", action, htmlAttributes).ToHtmlString();
      MvcHtmlString a = MvcHtmlString.Create(string.Format(linkText, img));
      return a;
    }

    #endregion ImageActionLink extensions

    #region IconActionLink extensions

    /// <summary>
    /// Create an action link with an icon
    /// </summary>
    /// <param name="html">Current HtmlHelper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action to be executed</param>
    /// <param name="iconClass">Icon CSS class(s) to be prepended for the link. Multiple icon classes must be separated with
    /// spaces</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes. Defaults to null</param>
    /// <returns>An action link prepended with the icon for the given icon class(s)</returns>
    public static MvcHtmlString IconActionLink(this HtmlHelper html, string linkText, ActionResult result, string iconClass, object htmlAttributes = (IDictionary<string, object>)null)
    {
      MvcHtmlString link = html.ActionLink(linkText, result, htmlAttributes);

      string iconLink = link.ToHtmlString().Replace(string.Format(">{0}", linkText), string.Format("><i class='{0}'></i>{1}", iconClass, linkText));

      return MvcHtmlString.Create(iconLink);
    }

    #endregion IconActionLink extensions

    #region IconAuthActionLink

    /// <summary>
    /// Create a authenticated action link with an icon
    /// </summary>
    /// <param name="html">Current HtmlHelper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="user">Current user</param>
    /// <param name="result">Action to be executed</param>
    /// <param name="iconClass">Icon CSS class(s) to be prepended for the link. Multiple icon classes must be separated with
    /// spaces</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes. Defaults to null</param>
    /// <returns>Authenticated action link if user is authenticated, else
    /// empty result</returns>
    public static MvcHtmlString IconAuthActionLink(this HtmlHelper html, string linkText, IPrincipal user, ActionResult result, string iconClass, object htmlAttributes = (IDictionary<string, object>)null)
    {
      if (user.Identity.IsAuthenticated)
        return html.IconActionLink(linkText, result, iconClass, htmlAttributes);

      return MvcHtmlString.Empty;
    }

    #endregion IconAuthActionLink

    #region AuthActionLink

    /// <summary>
    /// Create a authenticated action link
    /// </summary>
    /// <param name="html">Current HtmlHelper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="user">Current user</param>
    /// <param name="result">Action to be executed</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes. Defaults to null</param>
    /// <returns>Authenticated action link if user is authenticated, else
    /// empty result</returns>
    public static MvcHtmlString AuthActionLink(this HtmlHelper html, string linkText, IPrincipal user, ActionResult result, object htmlAttributes = (IDictionary<string, object>)null)
    {
      if (user.Identity.IsAuthenticated)
        return html.ActionLink(linkText, result, htmlAttributes);

      return MvcHtmlString.Empty;
    }

    #endregion AuthActionLink

    #region ButtonActionLink

    /// <summary>
    /// Create an button look and feel action link
    /// </summary>
    /// <param name="html">Current HtmlHelper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action to be executed</param>
    /// <param name="selected">[Optional] Flag indicating whether this link should be selected. Defaults to false</param>
    /// <returns>Button look and feel action link</returns>
    public static MvcHtmlString ButtonActionLink(this HtmlHelper html, string linkText, ActionResult result, bool selected = false)
    {
      if (selected)
        return html.ActionLink(linkText, result, new { id = "sbuttonLink" + Guid.NewGuid().ToString().Replace("-", "") });
      return html.ActionLink(linkText, result, new { id = "buttonLink" + Guid.NewGuid().ToString().Replace("-", "") });
    }

    /// <summary>
    /// Create an button look and feel action link
    /// </summary>
    /// <param name="html">Current HtmlHelper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="user">Current user</param>
    /// <param name="result">Action to be executed</param>
    /// <param name="selected">[Optional] Flag indicating whether this link should be selected. Defaults to false</param>
    /// <returns>Button look and feel action link</returns>
    public static MvcHtmlString AuthButtonActionLink(this HtmlHelper html, string linkText, IPrincipal user, ActionResult result, bool selected = false)
    {
      if (user.Identity.IsAuthenticated)
      {
        if (selected)
          return html.AuthActionLink(linkText, user, result, new { id = "sbuttonLink" + Guid.NewGuid().ToString().Replace("-", "") });
        return html.AuthActionLink(linkText, user, result, new { id = "buttonLink" + Guid.NewGuid().ToString().Replace("-", "") });
      }

      return MvcHtmlString.Empty;
    }

    #endregion ButtonActionLink
  }
}