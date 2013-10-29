/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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

#pragma warning disable 1591

using System;
using System.Web.Mvc;
using SquishIt.Framework;

namespace WebExtras.DemoApp.Controllers
{
  /// <summary>
  /// Controller to handle static content (e.g. CSS and JS) bundles
  /// via SquishIt
  /// </summary>
  public partial class AssetsController : Controller
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    public AssetsController()
    { }

    /// <summary>
    /// Get JS content for website
    /// </summary>
    /// <param name="id">JS Bundle Id</param>
    /// <returns>Minified JS if in production, else individual JS files</returns>
    public virtual ActionResult Js(string id)
    {
      // Set max-age to a year from now
      Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
      return Content(Bundle.JavaScript().RenderCached(id), "text/javascript");
    }

    /// <summary>
    /// Get CSS content
    /// </summary>
    /// <param name="id">CSS Bundle Id</param>
    /// <returns>Minified CSS if in production, else individual CSS files</returns>
    public virtual ActionResult Css(string id)
    {
      // Set max-age to a year from now
      Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
      return Content(Bundle.Css().RenderCached(id), "text/css");
    }
  }
}
