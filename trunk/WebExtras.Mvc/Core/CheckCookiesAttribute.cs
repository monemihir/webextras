/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
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
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// Ensures that cookies are enabled.
  /// </summary>
  /// <exception cref="CookiesNotEnabledException" />
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
  public class CheckCookiesAttribute : FilterAttribute, IAuthorizationFilter
  {
    #region Attributes & Ctor

    private readonly string m_cookieName;
    private readonly bool m_specificCookie;

    /// <summary>
    /// Cookie check query string parameter name
    /// </summary>
    public const string CookieCheck = "checkCookies";

    /// <summary>
    /// The name of the cookie to use to ensure cookies are enabled.
    /// </summary>
    public static string DefaultCookieName { get; set; }
    
    /// <summary>
    /// The name of the cookie to check for.
    /// </summary>
    public string CookieName { get { return m_cookieName; } }

    /// <summary>
    /// The querystring parameter to use to see if a test cookie has been set.
    /// </summary>
    public string QueryString { get; set; }

    /// <summary>
    /// Checks to make sure cookies are generally enabled.
    /// </summary>
    public CheckCookiesAttribute()
      : this(null)
    {
      // nothing to do here
    }

    /// <summary>
    /// Checks to make sure a cookie with the given name exists
    /// </summary>
    /// <param name="cookieName">The name of the cookie</param>
    public CheckCookiesAttribute(string cookieName)
    {
      QueryString = CookieCheck;
      DefaultCookieName = "ApplicationSupportsCookies";

      if (string.IsNullOrEmpty(cookieName))
        cookieName = DefaultCookieName;
      else
        m_specificCookie = true;

      m_cookieName = cookieName;
    }

    #endregion Attributes & Ctor

    #region IAuthorizationFilter members

    /// <summary>
    /// Called when authorization is required.
    /// </summary>
    /// <param name="filterContext">The filter context.</param>
    public void OnAuthorization(AuthorizationContext filterContext)
    {
      if (filterContext == null)
        throw new ArgumentNullException("filterContext");

      var request = filterContext.HttpContext.Request;
      var response = filterContext.HttpContext.Response;

      if (!request.Browser.Cookies)
        throw new CookiesNotEnabledException("Your browser does not support cookies.");

      string currentUrl = request.RawUrl;

      var noCookie = (request.Cookies[CookieName] == null);
      if (!m_specificCookie && noCookie && request.QueryString[QueryString] == null)
      {
        try
        {
          // make it expire a long time from now, that way there's no need for redirects in the future if it already exists
          var c = new HttpCookie(CookieName, "true") { Expires = DateTime.Today.AddYears(50), HttpOnly = true };
          response.Cookies.Add(c);

          currentUrl = currentUrl + (currentUrl.Contains('?') ? "&" : "?") + QueryString + "=true";

          filterContext.Result = new RedirectResult(currentUrl);
          return;
        }
        catch { 
          // we want to catch and ignore all exceptions if the the cookie can't be set since THAT IS
          // the whole purpose of this authorization filter
        }
      }

      if (noCookie)
        throw new CookiesNotEnabledException("You do not have cookies enabled.");
    }

    #endregion IAuthorizationFilter members
  }

}
