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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  /// DateTime extensions unit tests
  /// </summary>
  [TestClass]
  public class DateTimeExtensionsTest
  {
    /// <summary>
    /// Test that the ToJavaScriptDate extension method returns 
    /// expected results
    /// </summary>
    [TestMethod]
    public void ToJavaScriptDate_Works_Properly()
    {
      // Arrange
      DateTime dt = new DateTime(2000, 1, 1, 2, 0, 0, DateTimeKind.Local);
      double expected = 946692000000;

      // Act
      double actual = dt.ToJavaScriptDate();

      // Assert
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Test that the AsLocal extension method returns expected
    /// results
    /// </summary>
    [TestMethod]
    public void AsLocal_Works_Properly()
    { 
      // Arrange
      DateTime dt = new DateTime(2000, 1, 1, 2, 0, 0);

      // Act
      DateTime actual = dt.AsLocal();

      // Assert
      Assert.AreEqual(dt.Ticks, actual.Ticks);
      Assert.AreEqual(DateTimeKind.Local, actual.Kind);
    }

    /// <summary>
    /// Test that the AsUtc extension method returns expected
    /// results
    /// </summary>
    [TestMethod]
    public void AsUtc_Works_Properly()
    {
      // Arrange
      DateTime dt = new DateTime(2000, 1, 1, 2, 0, 0);

      // Act
      DateTime actual = dt.AsUtc();

      // Assert
      Assert.AreEqual(dt.Ticks, actual.Ticks);
      Assert.AreEqual(DateTimeKind.Utc, actual.Kind);
    }
  }
}
