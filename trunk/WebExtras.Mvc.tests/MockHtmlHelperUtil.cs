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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace WebExtras.Mvc.tests
{
  /// <summary>
  /// Mock HtmlHelper utility methods
  /// </summary>
  public static class MockHtmlHelperUtil
  {
    /// <summary>
    /// Create a mock HtmlHelper object
    /// </summary>
    /// <typeparam name="T">Type of model for which to create the mock</typeparam>
    /// <param name="viewData">View data dictionary</param>
    /// <returns>A mocked HtmlHelper object</returns>
    public static HtmlHelper<T> CreateHtmlHelper<T>(ViewDataDictionary viewData = null) where T : new()
    {
      var vd = viewData ?? new ViewDataDictionary(new T());

      var controllerContext = new ControllerContext(new Mock<HttpContextBase>().Object,
                                                    new RouteData(),
                                                    new Mock<ControllerBase>().Object);

      var viewContext = new ViewContext(controllerContext,
        new Mock<IView>().Object,
        vd,
        new TempDataDictionary(),
        new Mock<TextWriter>().Object);

      var mockViewDataContainer = new Mock<IViewDataContainer>();
      mockViewDataContainer.Setup(v => v.ViewData).Returns(vd);

      return new HtmlHelper<T>(viewContext, mockViewDataContainer.Object);
    }

    /// <summary>
    /// Create a mock HtmlHelper object
    /// </summary>
    /// <param name="viewData">View data dictionary</param>
    /// <returns>A mocked HtmlHelper object</returns>
    public static HtmlHelper CreateHtmlHelper(ViewDataDictionary viewData = null)
    {
      var vd = viewData ?? new ViewDataDictionary();

      var controllerContext = new ControllerContext(new Mock<HttpContextBase>().Object,
                                                    new RouteData(),
                                                    new Mock<ControllerBase>().Object);

      var viewContext = new ViewContext(controllerContext,
        new Mock<IView>().Object,
        vd,
        new TempDataDictionary(),
        new Mock<TextWriter>().Object);

      var mockViewDataContainer = new Mock<IViewDataContainer>();
      mockViewDataContainer.Setup(v => v.ViewData).Returns(vd);

      return new HtmlHelper(viewContext, mockViewDataContainer.Object);
    }
  }
}