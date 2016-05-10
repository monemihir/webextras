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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   Generic HTML helper extension methods
  /// </summary>
  public static class HtmlHelperExtension
  {
    /// <summary>
    ///   Default separator used to join stuff
    /// </summary>
    private const string DefaultSeparator = " | ";

    #region GenerateId extensions

    /// <summary>
    ///   Generate ID for a model property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="expression">Member expression</param>
    /// <returns>Generated HTML ID</returns>
    public static string GenerateIdFor<TModel, TValue>(this HtmlHelper html, Expression<Func<TModel, TValue>> expression)
    {
      string propertyName = WebExtrasUtil.GetFieldNameFromExpression(expression.Body as MemberExpression);
      return html.GenerateId(propertyName);
    }

    /// <summary>
    ///   Generate ID for a given field name
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="name">[Optional] Field name. Defaults to the current template info retrieved from ViewData</param>
    /// <returns>Generated HTML ID</returns>
    public static string GenerateId(this HtmlHelper html, string name = "")
    {
      string htmlNamePrefix = html.ViewData.TemplateInfo.HtmlFieldPrefix;
      if (htmlNamePrefix.Length > 0 && name.Length > 0) htmlNamePrefix += ".";
      return GenerateId(htmlNamePrefix + name);
    }

    /// <summary>
    ///   Generate ID for a given field name
    /// </summary>
    /// <param name="name">Field name</param>
    /// <returns>Generated HTML ID</returns>
    public static string GenerateId(string name)
    {
      TagBuilder t = new TagBuilder("a");
      t.GenerateId(name);
      return t.Attributes["id"];
    }

    #endregion GenerateId extensions

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
      this HtmlHelper html,
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
      this HtmlHelper html,
      string src,
      string altText,
      string url,
      object htmlAttributes = null)
    {
      return Imagelink(html, src, altText, string.Empty, url, htmlAttributes);
    }

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
    public static IExtendedHtmlString Imagelink(
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
    public static IExtendedHtmlString Imagelink(
      this HtmlHelper html,
      string src,
      string altText,
      string title,
      ActionResult result,
      object htmlAttributes = null)
    {
      string url = WebExtrasMvcUtil.GetUrl(html, result);

      return Imagelink(html, src, altText, title, url, htmlAttributes);
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
      this HtmlHelper html,
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

      Hyperlink link = new Hyperlink(string.Empty, url, linkAttributes);
      Image img = new Image(src, altText, title, imgAttributes);

      link.Append(img);

      return link;
    }

    #endregion Imagelink extensions

    #region AuthImagelink extensions

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
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
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
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
    public static IExtendedHtmlString AuthImagelink(
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

    /// <summary>
    ///   Create a HTML hyperlink with an image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="src">Image location</param>
    /// <param name="altText">Image alt text</param>
    /// <param name="title">Image title</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">
    ///   [Optional] Extra html attributes for the image link. By default
    ///   these attributes will be applied to the A tag only.
    /// </param>
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
      return user.Identity.IsAuthenticated
        ? Imagelink(html, src, altText, title, url, htmlAttributes)
        : HtmlElement.Empty;
    }

    #endregion AuthImagelink extensions

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
      this HtmlHelper html,
      string linkText,
      string url,
      object htmlAttributes = null)
    {
      Hyperlink h = new Hyperlink(linkText, url, htmlAttributes);

      return h;
    }

    /// <summary>
    ///   Creates a HTML hyperlink from given text and action
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlString Hyperlink(
      this HtmlHelper html,
      string linkText,
      ActionResult result,
      object htmlAttributes = null)
    {
      string link = WebExtrasMvcUtil.GetUrl(html, result);

      return Hyperlink(html, linkText, link, htmlAttributes);
    }

    #endregion Hyperlink extensions

    #region AuthHyperlink extensions

    /// <summary>
    ///   Creates a HTML hyperlink from given text and URL
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="linkText">Link text</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML Hyperlink</returns>
    public static IExtendedHtmlString AuthHyperlink(
      this HtmlHelper html,
      IPrincipal user,
      string linkText,
      string url,
      object htmlAttributes = null)
    {
      return user.Identity.IsAuthenticated
        ? new Hyperlink(linkText, url, htmlAttributes)
        : HtmlElement.Empty;
    }

    /// <summary>
    ///   Creates a HTML hyperlink from given text and action
    /// </summary>
    /// <param name="html">Current html helper object</param>
    /// <param name="user">User used to authenticate</param>
    /// <param name="linkText">Link text</param>
    /// <param name="result">Action result</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>HTML hyperlink</returns>
    public static IExtendedHtmlString AuthHyperlink(
      this HtmlHelper html,
      IPrincipal user,
      string linkText,
      ActionResult result,
      object htmlAttributes = null)
    {
      if (!user.Identity.IsAuthenticated)
        return HtmlElement.Empty;

      string url = WebExtrasMvcUtil.GetUrl(html, result);

      return Hyperlink(html, linkText, url, htmlAttributes);
    }

    #endregion AuthHyperlink extensions

    #region Image extensions

    /// <summary>
    ///   Creates an HTML image
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="src">Image location</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>An HTML image</returns>
    public static IExtendedHtmlString Image(
      this HtmlHelper html,
      string src,
      object htmlAttributes = null)
    {
      return new Image(src, string.Empty, string.Empty, htmlAttributes);
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
      this HtmlHelper html,
      string src,
      string altText,
      object htmlAttributes = null)
    {
      return new Image(src, altText, string.Empty, htmlAttributes);
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
    ///   Html Helper extension method to join html strings using the Default text seperator (|)
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
    ///   Html Helper extension method to join MVC html strings using the Default text seperator (|)
    /// </summary>
    /// <param name="htmlHelper">Html Helper object</param>
    /// <param name="links">an array of html strings</param>
    /// <returns>A single string containing the html strings seperated by the default seperator</returns>
    public static MvcHtmlString Join(this HtmlHelper htmlHelper, params MvcHtmlString[] links)
    {
      return Join(htmlHelper, links.Select(s => s.ToHtmlString()).ToArray());
    }

    #endregion Join extensions

    #region Inline extensions

    /// <summary>
    ///   Html helper to return the text contained in an external file
    ///   to enable the text to be inlined.
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

    #region List extensions

    /// <summary>
    ///   Create an HTML LIST
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="type">List type</param>
    /// <param name="listItems">A collection of list items</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A HTML LIST</returns>
    public static HtmlList List(
      this HtmlHelper html,
      EList type,
      IEnumerable<HtmlListItem> listItems,
      object htmlAttributes = null)
    {
      return new HtmlList(type, listItems, htmlAttributes);
    }

    #endregion List extensions

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
    [Obsolete("Use Html.RequiredFieldLabelFor(...)")]
    public static MvcHtmlString LabelForV2<TModel, TValue>(this HtmlHelper<TModel> html,
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
    [Obsolete("Use Html.RequiredFieldLabelFor(...)")]
    public static MvcHtmlString LabelForV2<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes = null)
    {
      return RequiredFieldLabelFor(html, expression, labelText, htmlAttributes);
    }

    /// <summary>
    ///   Create a label with the required field asterix
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lamba expression</param>
    /// <param name="htmlAttributes">[Optional] Extra html attributes</param>
    /// <returns>A label with the required field asterix</returns>
    public static MvcHtmlString RequiredFieldLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
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
    public static MvcHtmlString RequiredFieldLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes = null)
    {
      if (expression == null)
        throw new ArgumentNullException("expression");

      MemberExpression exp = expression.Body as MemberExpression;

      MvcHtmlString str = string.IsNullOrEmpty(labelText)
        ? html.LabelFor(expression, htmlAttributes)
        : html.LabelFor(expression, labelText, htmlAttributes);
      XElement xe = XElement.Parse(str.ToHtmlString());

      if (!exp.Member.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
        return MvcHtmlString.Create(xe.ToString());

      TagBuilder span = new TagBuilder("span");
      span.AddCssClass("required");
      span.SetInnerText(" *");
      xe.Add(XElement.Parse(span.ToString()));

      return MvcHtmlString.Create(xe.ToString());
    }

    #endregion Label extensions
  }
}