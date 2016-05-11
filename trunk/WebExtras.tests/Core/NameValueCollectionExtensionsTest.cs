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

using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  ///   NameValueCollection extensions unit tests
  /// </summary>
  [TestFixture]
  public class NameValueCollectionExtensionsTest
  {
    /// <summary>
    ///   Test that the ToDictionary extension method returns
    ///   expected results
    /// </summary>
    [Test]
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