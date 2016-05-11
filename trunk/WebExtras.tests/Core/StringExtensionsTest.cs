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

using NUnit.Framework;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  ///   String extensions unit tests
  /// </summary>
  [TestFixture]
  public class StringExtensionsTest
  {
    /// <summary>
    ///   Test that the ToTitlecase extension method works properly
    /// </summary>
    [Test]
    public void ToTitlecase_Works_Properly()
    {
      // Act
      string result = "mihir".ToTitleCase();

      // Assert
      Assert.AreEqual("Mihir", result);
    }

    /// <summary>
    ///   Test that the ToCamelCase extension method works properly
    /// </summary>
    [Test]
    public void ToCamelCase_Works_Properly()
    {
      // Act
      string result = "FilledCircle".ToCamelCase();

      // Assert
      Assert.AreEqual("filledCircle", result);

      // Act
      result = "FilledCircle OneTwoThree".ToCamelCase();

      // Assert
      Assert.AreEqual("filledCircle OneTwoThree", result);

      // Act
      result = "FilledCircle OneTwoThree".ToCamelCase(true);

      // Assert
      Assert.AreEqual("filledCircle oneTwoThree", result);
    }

    /// <summary>
    ///   Test that the ContainsIgnoreCase method works properly
    /// </summary>
    [Test]
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