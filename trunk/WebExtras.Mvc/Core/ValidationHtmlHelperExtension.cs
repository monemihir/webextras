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
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// Validation HTML helper methods
  /// </summary>
  public static class ValidationHtmlHelperExtension
  {
    #region IsValidFor extensions

    /// <summary>
    /// Gets the validation state of a property
    /// </summary>
    /// <typeparam name="TModel">Type to be scanned</typeparam>
    /// <typeparam name="TValue">Property to be scanned</typeparam>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="expression">The property lambda expression</param>
    /// <returns>True if state is valid, else False</returns>
    public static bool IsValidFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
    {
      MemberExpression exp = expression.Body as MemberExpression;
      bool result = true;

      List<string> buff = exp.ToString().Split('.').ToList();
      buff.RemoveAt(0);
      string mname = string.Join(".",buff);

      //if (html.ViewData.ModelState.ContainsKey(exp.Member.Name))
      //  result = !(html.ViewData.ModelState[exp.Member.Name].Errors.Count > 0);

      if(html.ViewData.ModelState.ContainsKey(mname))
        result = !(html.ViewData.ModelState[mname].Errors.Count > 0);

      return result;
    }

    /// <summary>
    /// Get the validation state of a property
    /// </summary>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="memberName">The member name to be checked</param>
    /// <returns>True if state is valid, else False</returns>
    public static bool IsValidFor(this HtmlHelper html, string memberName)
    {
      bool result = true;
      if (html.ViewData.ModelState.ContainsKey(memberName))
        result = !(html.ViewData.ModelState[memberName].Errors.Count > 0);

      return result;
    }

    #endregion IsValidFor extensions
  }
}