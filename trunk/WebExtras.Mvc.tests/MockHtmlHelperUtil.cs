// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace WebExtras.Mvc.tests
{
  /// <summary>
  ///   Mock HtmlHelper utility methods
  /// </summary>
  public static class MockHtmlHelperUtil
  {
    /// <summary>
    ///   Create a mock HtmlHelper object
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
    ///   Create a mock HtmlHelper object
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