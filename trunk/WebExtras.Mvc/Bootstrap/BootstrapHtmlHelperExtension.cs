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
using System.Text;
using System.Web.Mvc;
using WebExtras.Mvc.Core;
using System.Security.Principal;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap Html Helper extension methods
  /// </summary>
  public static class BootstrapHtmlHelperExtension
  {
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
      MvcHtmlString link = html.HyperLink(linkText, url, isJavascriptLink, html);

      string iconLink = link.ToHtmlString().Replace(string.Format(">{0}", linkText), string.Format("><i class='{0}'></i>{1}", iconClass, linkText));

      return MvcHtmlString.Create(iconLink);
    }

    public static Hyperlink Hyperlink(
      this HtmlHelper html,
      string linkText,
      string url,
      object htmlAttributes)
    {
      Hyperlink h = new Hyperlink(linkText, url, htmlAttributes);

      return h;
    }


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
  }
}
