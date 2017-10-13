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
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests.Core
{
  /// <summary>
  ///   HtmlStringUtil unit tests
  /// </summary>
  [TestFixture]
  public class WebExtrasMvcUtilTest
  {
    ///// <summary>
    /////   CanDisplayAsButton returns True for Hyperlink
    ///// </summary>
    //[Test]
    //public void CanDisplayAsButton_Returns_True_For_Hyperlink()
    //{
    //  // arrange
    //  Hyperlink link = new Hyperlink(string.Empty, string.Empty);

    //  // act
    //  bool result = WebExtrasMvcUtil.CanDisplayAsButton(link);

    //  // assert
    //  Assert.IsTrue(result);
    //}

    /// <summary>
    ///   CanDisplayAsButton returns True for Button
    /// </summary>
    [Test]
    public void CanDisplayAsButton_Returns_True_For_Button()
    {
      // arrange
      Button btn = new Button(EButton.Regular, string.Empty, string.Empty);

      // act
      bool result = WebExtrasMvcUtil.CanDisplayAsButton(btn);

      // assert
      Assert.IsTrue(result);
    }
  }
}