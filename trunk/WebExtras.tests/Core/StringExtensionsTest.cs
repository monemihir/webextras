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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  /// String extensions unit tests
  /// </summary>
  [TestClass]
  public class StringExtensionsTest
  {
    /// <summary>
    /// Test that the ToTitlecase extension method works properly
    /// </summary>
    [TestMethod]
    public void ToTitlecase_Works_Properly()
    {
      // Act
      string result = "mihir".ToTitleCase();

      // Assert
      Assert.AreEqual("Mihir", result);
    }

    /// <summary>
    /// Test that the ContainsIgnoreCase method works properly
    /// </summary>
    [TestMethod]
    public void ContainsIgnoreCase_Works_Properly()
    {
      // Arrange
      string data = "Mihir IS AwsOMe";

      // Act
      bool result = data.ContainsIgnoreCase("ome");

      // Assert
      Assert.IsTrue(result);
    }
  }
}