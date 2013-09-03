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

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  /// NameValueCollection extensions unit tests
  /// </summary>
  [TestClass]
  public class NameValueCollectionExtensionsTest
  {
    /// <summary>
    /// Test that the ToDictionary extension method returns 
    /// expected results
    /// </summary>
    [TestMethod]
    public void ToDictionary_Works_Properly()
    {
      // Arrange
      NameValueCollection collection = new NameValueCollection();
      collection.Add("key1", "value1");
      collection.Add("key2", "value2");

      // Act
      IDictionary<string, string> result = collection.ToDictionary();

      // Assert
      Assert.IsTrue(result.ContainsKey("key1"));
      Assert.IsTrue(result.ContainsKey("key2"));
      Assert.AreEqual("value1", result["key1"]);
      Assert.AreEqual("value2", result["key2"]);
    }
  }
}
