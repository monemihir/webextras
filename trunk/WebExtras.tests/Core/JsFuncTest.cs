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

using Newtonsoft.Json;
using NUnit.Framework;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  ///   JsFunc unit tests
  /// </summary>
  [TestFixture]
  public class JsFuncTest
  {
    /// <summary>
    ///   Test that an anonymous JsFunc gets serialized properly
    /// </summary>
    [Test]
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
    ///   Test that an anonymous JsFunc with parameters gets
    ///   serialized properly
    /// </summary>
    [Test]
    public void Anonymous_JsFunc_With_Parameters_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.ParameterNames = new[] {"test_param1", "test_param2"};
      js.Body = "alert(test_param1 + test_param2);";

      string expected = "function (test_param1, test_param2) { alert(test_param1 + test_param2); }";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    ///   Test that an named JsFunc gets serialized properly
    /// </summary>
    [Test]
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
    ///   Test that an named JsFunc with parameters gets
    ///   serialized properly
    /// </summary>
    [Test]
    public void Named_JsFunc_With_Parameters_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.Name = "foo";
      js.ParameterNames = new[] {"test_param1", "test_param2"};
      js.Body = "alert(test_param1 + test_param2);";

      string expected = "function foo(test_param1, test_param2) { alert(test_param1 + test_param2); }";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    ///   Test that an named JsFunc with parameters and OnDocmentReady flag set
    ///   gets serialized properly
    /// </summary>
    [Test]
    public void Named_JsFunc_With_Parameters_With_OnDocumentReady_Serializes_Properly()
    {
      // Arrange
      JsFunc js = new JsFunc();
      js.Name = "foo";
      js.ParameterNames = new[] {"test_param1", "test_param2"};
      js.Body = "alert(test_param1 + test_param2);";
      js.OnDocumentReady = true;

      string expected =
        "$(document).ready(function() { function foo(test_param1, test_param2) { alert(test_param1 + test_param2); } });";

      // Act
      string result = JsonConvert.SerializeObject(js);

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(expected, result);
    }
  }
}