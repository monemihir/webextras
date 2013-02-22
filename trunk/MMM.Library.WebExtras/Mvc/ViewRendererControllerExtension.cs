/*
* This file is part of - Code Library
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

using System.IO;
using System.Web.Mvc;

namespace MMM.Library.WebExtras.Mvc
{
  /// <summary>
  /// Offline rendering of MVC views
  /// </summary>
  public static class ViewRendererControllerExtension
  {
    #region GetRenderedPartialView

    /// <summary>
    /// Renders a given partial view with the given model and returns
    /// it's generated HTML content
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="partialViewName">Partial View to be rendered</param>
    /// <param name="model">View model</param>
    /// <returns>Rendered HTML content</returns>
    public static MvcHtmlString GetRenderedPartialView(this ControllerBase c, string partialViewName, object model)
    {
      c.ViewData.Model = model;

      var content = string.Empty;
      var view = ViewEngines.Engines.FindPartialView(c.ControllerContext, partialViewName);
      using (var writer = new StringWriter())
      {
        var context = new ViewContext(c.ControllerContext, view.View, c.ViewData, c.TempData, writer);
        view.View.Render(context, writer);
        writer.Flush();
        content = writer.ToString();
      }

      return MvcHtmlString.Create(content);
    }

    #endregion GetRenderedPartialView

    #region GetRenderedView

    /// <summary>
    /// Renders a given view with the given master page and view model and returns
    /// the generated HTML content
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="viewName">View to be rendered</param>
    /// <param name="masterPageName">Master page to be used to render the view</param>
    /// <param name="model">View model</param>
    /// <returns>Rendered HTML content</returns>
    public static MvcHtmlString GetRenderedView(this ControllerBase c, string viewName, string masterPageName, object model)
    {
      c.ViewData.Model = model;

      var content = string.Empty;
      var view = ViewEngines.Engines.FindView(c.ControllerContext, viewName, masterPageName);
      using (var writer = new StringWriter())
      {
        var context = new ViewContext(c.ControllerContext, view.View, c.ViewData, c.TempData, writer);
        view.View.Render(context, writer);
        writer.Flush();
        content = writer.ToString();
      }

      return MvcHtmlString.Create(content);
    }

    /// <summary>
    /// Renders a view with the given view model and returns the 
    /// generated HTML content
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="viewName">View to be rendered</param>
    /// <param name="model">View mode</param>
    /// <returns>Rendered HTML content</returns>
    public static MvcHtmlString GetRenderedView(this ControllerBase c, string viewName, object model)
    {
      c.ViewData.Model = model;

      var content = string.Empty;
      var view = ViewEngines.Engines.FindView(c.ControllerContext, viewName, null);
      using (var writer = new StringWriter())
      {
        var context = new ViewContext(c.ControllerContext, view.View, c.ViewData, c.TempData, writer);
        view.View.Render(context, writer);
        writer.Flush();
        content = writer.ToString();
      }

      return MvcHtmlString.Create(content);
    }

    #endregion GetRenderedView
  }
}