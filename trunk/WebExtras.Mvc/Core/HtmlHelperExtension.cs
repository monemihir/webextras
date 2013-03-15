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
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Routing;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Core
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

    #region Imagelink extensions

    /// <summary>
    /// Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      string url,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, string.Empty, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      string url,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, altText, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      ActionResult result,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, string.Empty, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      ActionResult result,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, altText, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      string title,
      ActionResult result,
      object htmlAttributes = null)
    {
      VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(html.ViewContext.RequestContext, result.GetRouteValueDictionary());
      string url = vpd.VirtualPath;

      return Imagelink(html, src, altText, title, url, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      string title,
      string url,
      object htmlAttributes = null)
    {
      Hyperlink link = new Hyperlink(string.Empty, url, htmlAttributes);
      Image img = new Image(src, altText, title, new { style = "border: 0; vertical-align: top" });

      link.AppendTags.Add(img);

      return link;
    }

    #endregion Imagelink extensions

    #region AuthImagelink extensions

    /// <summary>
    /// Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      string url,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, user, src, string.Empty, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      string altText,
      string url,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, user, src, altText, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      ActionResult result,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, user, src, string.Empty, string.Empty, result, htmlAttributes);
    }

    /// <summary>
    /// Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(
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
    /// Create a HTML hyperlink with an image and given action
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      string altText,
      string title,
      ActionResult result,
      object htmlAttributes = null)
    {
      if (user.Identity.IsAuthenticated)
      {

        VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(html.ViewContext.RequestContext, result.GetRouteValueDictionary());
        string url = vpd.VirtualPath;

        return Imagelink(html, src, altText, title, url, htmlAttributes);
      }

      return HtmlElement.Empty;
    }

    /// <summary>
    /// Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes for the image link. Note.
    /// These attributes will be applied to the A tag only.</param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(
      this HtmlHelper html,
      IPrincipal user,
      string src,
      string altText,
      string title,
      string url,
      object htmlAttributes = null)
    {
      if (user.Identity.IsAuthenticated)
      {
        Hyperlink link = new Hyperlink(string.Empty, url, htmlAttributes);
        Image img = new Image(src, altText, title, new { style = "border: 0; vertical-align: top" });

        link.AppendTags.Add(img);

        return link;
      }

      return HtmlElement.Empty;
    }

    #endregion AuthImagelink extensions

    #region Hyperlink extensions

    /// <summary>
    /// Creates a HTML hyperlink from given text and URL
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlString Hyperlink(
      this HtmlHelper html,
      string linkText,
      string url,
      object htmlAttributes = null)
    {
      Hyperlink h = new Hyperlink(linkText, url, htmlAttributes);

      return h;
    }

    /// <summary>
    /// Creates a HTML hyperlink from given text and action
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlString Hyperlink(
      this HtmlHelper html,
      string linkText,
      ActionResult result,
      object htmlAttributes = null)
    {
      VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(html.ViewContext.RequestContext, result.GetRouteValueDictionary());
      string url = vpd.VirtualPath;

      return Hyperlink(html, linkText, url, htmlAttributes);
    }

    #endregion Hyperlink extensions

    #region AuthHyperlink extensions

    /// <summary>
    /// Creates a HTML hyperlink from given text and URL
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>HTML Hyperlink</returns>
    public static IExtendedHtmlString AuthHyperlink(
      this HtmlHelper html,
      IPrincipal user,
      string linkText, 
      string url, 
      object htmlAttributes = null)
    {
      if (user.Identity.IsAuthenticated)
        return new Hyperlink(linkText, url, htmlAttributes);

      return HtmlElement.Empty;
    }

    /// <summary>
    /// Creates a HTML hyperlink from given text and action
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlString AuthHyperlink(
      this HtmlHelper html, 
      IPrincipal user, 
      string linkText, 
      ActionResult result, 
      object htmlAttributes = null)
    {
      if (user.Identity.IsAuthenticated)
      {
        VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(html.ViewContext.RequestContext, result.GetRouteValueDictionary());
        string url = vpd.VirtualPath;

        return Hyperlink(html, linkText, url, htmlAttributes);
      }

      return HtmlElement.Empty;
    }

    #endregion AuthHyperlink extensions

    #region Image extensions

    /// <summary>
    /// Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelper html,
      string src,
      object htmlAttributes = null)
    {
      return new Image(src, string.Empty, string.Empty, htmlAttributes);
    }

    /// <summary>
    /// Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelper html,
      string src,
      string altText,
      object htmlAttributes = null)
    {
      return new Image(src, altText, string.Empty, htmlAttributes);
    }

    /// <summary>
    /// Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelper html,
      string src,
      string altText,
      string title,
      object htmlAttributes = null)
    {
      return new Image(src, altText, title, htmlAttributes);
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
  }
}