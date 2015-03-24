// 
// This file is part of - WebExtras
// Copyright (C) 2015 Mihir Mone
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
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   Utility methods
  /// </summary>
  public static class WebExtrasMvcUtil
  {
    /// <summary>
    ///   Check whether we can actually display as button
    /// </summary>
    /// <param name="html">Current HTML element</param>
    /// <returns>True if can display as button, else False</returns>
    public static bool CanDisplayAsButton(IExtendedHtmlString html)
    {
      // We can only display hyperlinks and button as buttons
      Type t = html.GetType();

      return t == typeof (Hyperlink) || t == typeof (Button);
    }

    /// <summary>
    ///   Get the url from given action result
    /// </summary>
    /// <param name="html">Current HTML helper instance</param>
    /// <param name="result">Action to be parsed</param>
    /// <returns>The URL the action points to</returns>
    public static string GetUrl(HtmlHelper html, ActionResult result)
    {
      UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);

      RouteValueDictionary rvd = result.GetRouteValueDictionary();
      string link = urlHelper.RouteUrl(rvd);

      return link;
    }

    /// <summary>
    ///   Get a HTML field ID based on a member expression. This supports nested member expressions
    /// </summary>
    /// <param name="expression">Member lamba expression</param>
    /// <returns>HTML field ID for member</returns>
    public static string GetFieldIdFromExpression(MemberExpression expression)
    {
      return string.Join("_", GetComponents(expression));
    }

    /// <summary>
    ///   Get a HTML field name based on a member expression. This supports nested member expressions
    /// </summary>
    /// <param name="expression">Member lamba expression</param>
    /// <returns>HTML field name for member</returns>
    public static string GetFieldNameFromExpression(MemberExpression expression)
    {
      return string.Join(".", GetComponents(expression));
    }

    /// <summary>
    ///   Gets the usable components from the expression. For eg. f.Model.Member
    ///   will return Model and Member as usable components.
    /// </summary>
    /// <param name="expression">Member expression to process</param>
    /// <returns>
    ///   A collection of components that can be used to make
    ///   a field ID or field Name
    /// </returns>
    private static IEnumerable<string> GetComponents(MemberExpression expression)
    {
      List<string> components = new List<string>();
      List<string> split = expression.Expression.ToString().Split('.').ToList();

      if (split.Count > 1)
      {
        split.RemoveAt(0);
        components.AddRange(split);
      }

      components.Add(expression.Member.Name);
      return components;
    }
  }
}