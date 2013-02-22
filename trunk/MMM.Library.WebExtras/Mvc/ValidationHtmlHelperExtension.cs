using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MMM.Library.WebExtras.Helpers
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
      if (html.ViewData.ModelState.ContainsKey(exp.Member.Name))
        result = !(html.ViewData.ModelState[exp.Member.Name].Errors.Count > 0);

      return result;
    }

    /// <summary>
    /// Get the validation state of a property
    /// </summary>
    /// <param name="html">Htmlhelper extension</param>
    /// <param name="memberName">The member name to be checked</param>
    /// <returns>True if state is valid, else False</returns>
    public static bool ValidFor(this HtmlHelper html, String memberName)
    {
      bool result = true;
      if (html.ViewData.ModelState.ContainsKey(memberName))
        result = !(html.ViewData.ModelState[memberName].Errors.Count > 0);

      return result;
    }

    #endregion IsValidFor extensions
  }
}
