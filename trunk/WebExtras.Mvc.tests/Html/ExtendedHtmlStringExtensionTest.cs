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
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests.Html
{
  /// <summary>
  ///   ExtendedHtmlStringExtension unit tests
  /// </summary>
  [TestFixture]
  public class ExtendedHtmlStringExtensionTest
  {
    /// <summary>
    ///   Test that AddCssClass extension method returns
    ///   expected results
    /// </summary>
    [Test]
    public void AddCssClass_Works_Properly()
    {
      // arrange
      Hyperlink link = new Hyperlink(string.Empty, string.Empty);

      // act
      link.AddCssClass("test-css-classes");

      // assert
      Assert.AreEqual("test-css-classes", link.CSSClasses[0]);
    }
  }
}