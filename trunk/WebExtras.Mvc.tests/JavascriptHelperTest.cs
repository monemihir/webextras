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

namespace WebExtras.Mvc.tests
{
  /// <summary>
  /// JavascriptHelper unit tests
  /// </summary>
  [TestClass]
  public class JavascriptHelperTest
  {
    /// <summary>
    /// Test that the ToUtcJSDate returns expected result
    /// </summary>
    [TestMethod]
    public void ToUtcJSDate_Test()
    {
      // arrange
      double expected = 1357045571000;
      DateTime dt = new DateTime(2013, 01, 01, 13, 06, 11, DateTimeKind.Utc);

      // act
      double actual = JavascriptHelper.ToUtcJSDate(dt);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Test that the ToUtcCSDate returns expected result
    /// </summary>
    [TestMethod]
    public void ToUtcCSDate_Test()
    {
      // arrange
      DateTime expected = new DateTime(2013, 01, 01, 13, 06, 11, DateTimeKind.Utc);
      double dt = 1357045571000;

      // act
      DateTime actual = JavascriptHelper.ToUtcCSDate(dt);

      // assert
      Assert.AreEqual(expected.ToString(), actual.ToString());
    }
  }
}