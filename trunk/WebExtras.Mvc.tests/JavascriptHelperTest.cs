﻿// 
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
using System.Globalization;
using NUnit.Framework;

namespace WebExtras.Mvc.tests
{
  /// <summary>
  ///   JavascriptHelper unit tests
  /// </summary>
  [TestFixture]
  public class JavascriptHelperTest
  {
    /// <summary>
    ///   Test that the ToUtcJSDate returns expected result
    /// </summary>
    [Test]
    public void ToUtcJSDate_Test()
    {
      // arrange
      const double expected = 1357045571000;
      DateTime dt = new DateTime(2013, 01, 01, 13, 06, 11, DateTimeKind.Utc);

      // act
      double actual = JavascriptHelper.ToUtcJSDate(dt);

      // assert
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///   Test that the ToUtcCSDate returns expected result
    /// </summary>
    [Test]
    public void ToUtcCSDate_Test()
    {
      // arrange
      DateTime expected = new DateTime(2013, 01, 01, 13, 06, 11, DateTimeKind.Utc);
      const double dt = 1357045571000;

      // act
      DateTime actual = JavascriptHelper.ToUtcCSDate(dt);

      // assert
      Assert.AreEqual(expected.ToString(CultureInfo.InvariantCulture), actual.ToString(CultureInfo.InvariantCulture));
    }
  }
}