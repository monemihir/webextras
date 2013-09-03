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
using Newtonsoft.Json;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  /// JsFunc unit tests
  /// </summary>
  [TestClass]
  public class JsFuncTest
  {
    /// <summary>
    /// Test that an anonymous JsFunc gets serialized properly
    /// </summary>
    [TestMethod]
    public void Anonymous_JsFunc_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.Body = "alert(test_param1 + test_param2);";

      string expected = "function () { alert(test_param1 + test_param2); }";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test that an anonymous JsFunc with parameters gets 
    /// serialized properly
    /// </summary>
    [TestMethod]
    public void Anonymous_JsFunc_With_Parameters_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.ParameterNames = new string[] { "test_param1", "test_param2" };
      js.Body = "alert(test_param1 + test_param2);";

      string expected = "function (test_param1, test_param2) { alert(test_param1 + test_param2); }";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test that an named JsFunc gets serialized properly
    /// </summary>
    [TestMethod]
    public void Named_JsFunc_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.Name = "foo";
      js.Body = "alert(test_param1 + test_param2);";

      string expected = "function foo() { alert(test_param1 + test_param2); }";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test that an named JsFunc with parameters gets 
    /// serialized properly
    /// </summary>
    [TestMethod]
    public void Named_JsFunc_With_Parameters_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.Name = "foo";
      js.ParameterNames = new string[] { "test_param1", "test_param2" };
      js.Body = "alert(test_param1 + test_param2);";

      string expected = "function foo(test_param1, test_param2) { alert(test_param1 + test_param2); }";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test that an named JsFunc with parameters and OnDocmentReady flag set
    /// gets serialized properly
    /// </summary>
    [TestMethod]
    public void Named_JsFunc_With_Parameters_With_OnDocumentReady_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.Name = "foo";
      js.ParameterNames = new string[] { "test_param1", "test_param2" };
      js.Body = "alert(test_param1 + test_param2);";
      js.OnDocumentReady = true;

      string expected = "$(document).ready(function() { function foo(test_param1, test_param2) { alert(test_param1 + test_param2); } });";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }
  }
}
