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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests.Html
{
  /// <summary>
  /// ExtendedHtmlStringExtension unit tests
  /// </summary>
  [TestClass]
  public class ExtendedHtmlStringExtensionTest
  {
    /// <summary>
    /// Test that AddCssClass extension method returns
    /// expected results
    /// </summary>
    [TestMethod]
    public void AddCssClass_Works_Properly()
    {
      // arrange
      Hyperlink link = new Hyperlink(string.Empty, string.Empty);

      // act
      link.AddCssClass("test-css-classes");

      // assert
      Assert.AreEqual("test-css-classes", link.CSSClasses[0]);
    }
  }
}
