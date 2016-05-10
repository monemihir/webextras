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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nancy.ViewEngines.Razor;
using WebExtras.Core;
using WebExtras.Html;
using WebExtras.Nancy.Html;

namespace WebExtras.Nancy.Core
{
  /// <summary>
  ///   HTML helpers
  /// </summary>
  public static class HtmlHelpersExtension
  {
    #region Image extensions

    /// <summary>
    ///   Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelpers html,
      string src,
      object htmlAttributes = null)
    {
      return html.Image(src, string.Empty, string.Empty, htmlAttributes);
    }

    /// <summary>
    ///   Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelpers html,
      string src,
      string altText,
      object htmlAttributes = null)
    {
      return html.Image(src, altText, string.Empty, htmlAttributes);
    }

    /// <summary>
    ///   Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelpers html,
      string src,
      string altText,
      string title,
      object htmlAttributes = null)
    {
      HtmlComponent img = new HtmlComponent(EHtmlTag.Img, htmlAttributes);
      img.Attributes["src"] = src;
      img.Attributes["title"] = title;
      img.Attributes["alt"] = altText;

      return new ExtendedHtmlString(img);
    }

    #endregion Image extensions

    #region Label extensions

    /// <summary>
    ///   Create a label with the required field asterix
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>A label with the required field asterix</returns>
    public static IExtendedHtmlString RequiredFieldLabelFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
      return RequiredFieldLabelFor(html, expression, string.Empty, htmlAttributes);
    }

    /// <summary>
    ///   Create a label with the required field asterix
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="labelText">Label text to be shown</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>A label with the required field asterix</returns>
    public static IExtendedHtmlString RequiredFieldLabelFor<TModel, TValue>(this HtmlHelpers<TModel> html,
      Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes = null)
    {
      if (expression == null)
        throw new ArgumentNullException("expression");

      MemberExpression exp = expression.Body as MemberExpression;
      if (exp == null)
        throw new ArgumentException("Unable to parse property lambda expression", "expression");

      HtmlComponent label = new HtmlComponent(EHtmlTag.Label, htmlAttributes);
      label.Attributes["id"] = WebExtrasUtil.GetFieldIdFromExpression(exp);
      label.Attributes["name"] = WebExtrasUtil.GetFieldNameFromExpression(exp);
      label.InnerHtml = labelText;

      if (exp.Member.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
      {
        HtmlComponent span = new HtmlComponent(EHtmlTag.Span);
        span.CssClasses.Add("required");
        span.InnerHtml = " *";

        label.AppendTags.Add(span);
      }

      return new ExtendedHtmlString(label);
    }

    #endregion Label extensions

    #region Hyperlink extensions

    /// <summary>
    ///   Creates a HTML hyperlink from given text and URL
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlString Hyperlink(
      this HtmlHelpers html,
      string linkText,
      string url,
      object htmlAttributes = null)
    {
      HtmlComponent a = new HtmlComponent(EHtmlTag.A, htmlAttributes);
      a.Attributes["href"] = url;
      a.InnerHtml = linkText;

      return new ExtendedHtmlString(a);
    }

    #endregion Hyperlink extensions

    #region AuthHyperlink extensions

    /// <summary>
    ///   Creates a HTML hyperlink from given text and URL
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML Hyperlink</returns>
    public static IExtendedHtmlString AuthHyperlink(
      this HtmlHelpers html,
      string linkText,
      string url,
      object htmlAttributes = null)
    {
      return html.IsAuthenticated
        ? html.Hyperlink(linkText, url, htmlAttributes)
        : ExtendedHtmlString.Empty;
    }

    #endregion AuthHyperlink extensions

    #region Imagelink extensions

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelpers html,
      string src,
      string url,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, string.Empty, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelpers html,
      string src,
      string altText,
      string url,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, altText, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString Imagelink(
      this HtmlHelpers html,
      string src,
      string altText,
      string title,
      string url,
      object htmlAttributes = null)
    {
      object linkAttributes = null, imgAttributes = null;

      if (htmlAttributes != null)
      {
        // try to get the html attributes for the link and img
        IDictionary<string, object> attr = htmlAttributes
          .GetType()
          .GetProperties(BindingFlags.Public | BindingFlags.Instance)
          .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(htmlAttributes, null)))
          .ToDictionary(k => k.Key, v => v.Value);

        if (attr.ContainsKey("a"))
          linkAttributes = attr["a"];
        if (attr.ContainsKey("img"))
          imgAttributes = attr["img"];
      }

      // create <img> tag
      HtmlComponent img = new HtmlComponent(EHtmlTag.Img, imgAttributes);
      img.Attributes["src"] = src;
      img.Attributes["alt"] = altText;
      img.Attributes["title"] = title;

      // create <a> tag
      HtmlComponent link = new HtmlComponent(EHtmlTag.A, linkAttributes);
      link.Attributes["href"] = url;
      link.AppendTags.Add(img);

      return new ExtendedHtmlString(link);
    }

    #endregion Imagelink extensions

    #region AuthImagelink extensions

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(this HtmlHelpers html, string src, string url,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, src, string.Empty, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(this HtmlHelpers html, string src, string altText, string url,
      object htmlAttributes = null)
    {
      return AuthImagelink(html, src, altText, string.Empty, url, htmlAttributes);
    }

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
    /// <returns>HTML image hyperlink</returns>
    public static IExtendedHtmlString AuthImagelink(this HtmlHelpers html, string src, string altText, string title,
      string url, object htmlAttributes = null)
    {
      return html.IsAuthenticated
        ? Imagelink(html, src, altText, title, url, htmlAttributes)
        : ExtendedHtmlString.Empty;
    }

    #endregion AuthImagelink extensions
  }
}