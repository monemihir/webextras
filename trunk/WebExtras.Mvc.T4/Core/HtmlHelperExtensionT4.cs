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

using System.Security.Principal;
using System.Web.Mvc;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   Generic HTML helper extension methods
  /// </summary>
  public static class HtmlHelperExtensionT4
  {
    #region Hyperlink extensions

    /// <summary>
    ///   Creates a HTML hyperlink from given text and action
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlStringLegacy Hyperlink(
      this HtmlHelper html,
      string linkText,
      ActionResult result,
      object htmlAttributes = null)
    {
      string link = WebExtrasMvcUtilT4.GetUrl(html, result);

      return html.Hyperlink(linkText, link, htmlAttributes);
    }

    #endregion Hyperlink extensions

    #region AuthHyperlink extensions

    /// <summary>
    ///   Creates a HTML hyperlink from given text and action
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlStringLegacy AuthHyperlink(
      this HtmlHelper html,
      IPrincipal user,
      string linkText,
      ActionResult result,
      object htmlAttributes = null)
    {
      if (!user.Identity.IsAuthenticated)
        return HtmlElement.Empty;

      string url = WebExtrasMvcUtilT4.GetUrl(html, result);

      return html.Hyperlink(linkText, url, htmlAttributes);
    }

    #endregion AuthHyperlink extensions

    #region Imagelink extensions

    /// <summary>
    ///   Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlStringLegacy Imagelink(
      this HtmlHelper html,
      string src,
      ActionResult result,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, string.Empty, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlStringLegacy Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      ActionResult result,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, altText, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlStringLegacy Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      string title,
      ActionResult result,
      object htmlAttributes = null)
    {
      string url = WebExtrasMvcUtilT4.GetUrl(html, result);

      return html.Imagelink(src, altText, title, url, htmlAttributes);
    }

    #endregion Imagelink extensions

    #region AuthImagelink extensions

    /// <summary>
    ///   Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlStringLegacy AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      ActionResult result,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, user, src, string.Empty, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlStringLegacy AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      string altText,
      ActionResult result,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, user, src, altText, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlStringLegacy AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      string altText,
      string title,
      ActionResult result,
      object htmlAttributes = null)
    {
      return user.Identity.IsAuthenticated
        ? Imagelink(html, src, altText, title, result, htmlAttributes)
        : HtmlElement.Empty;
    }

    #endregion AuthImagelink extensions
  }
}