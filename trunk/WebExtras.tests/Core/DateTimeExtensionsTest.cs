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

using System;
using NUnit.Framework;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  ///   DateTime extensions unit tests
  /// </summary>
  [TestFixture]
  public class DateTimeExtensionsTest
  {
    /// <summary>
    ///   Test that the ToJavaScriptDate extension method returns
    ///   expected results
    /// </summary>
    [Test]
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
    ///   Test that the AsLocal extension method returns expected
    ///   results
    /// </summary>
    [Test]
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
    ///   Test that the AsUtc extension method returns expected
    ///   results
    /// </summary>
    [Test]
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