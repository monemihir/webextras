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
  ///   CssClassList unit tests
  /// </summary>
  [TestFixture]
  public class CssClassesListTest
  {
    /// <summary>
    ///   Test that Add method adds individual classes
    /// </summary>
    [Test]
    public void Add_Method_Adds_Individual_Classes()
    {
      // arrange
      string classes = "test1 test2 test3";

      // act
      CssClassList collection = new CssClassList();
      collection.Add(classes);

      // assert
      Assert.AreEqual(3, collection.Count);
      Assert.AreEqual("test1", collection[0]);
      Assert.AreEqual("test2", collection[1]);
      Assert.AreEqual("test3", collection[2]);
    }

    /// <summary>
    ///   Test that the AddRange method adds individual classes
    /// </summary>
    [Test]
    public void AddRange_Method_Adds_Individual_Classes()
    {
      // arrange
      string[] classes = {"test1 test2 test3", "test4"};

      // act
      CssClassList collection = new CssClassList();
      collection.AddRange(classes);

      // assert
      Assert.AreEqual(4, collection.Count);
      Assert.AreEqual("test1", collection[0]);
      Assert.AreEqual("test2", collection[1]);
      Assert.AreEqual("test3", collection[2]);
      Assert.AreEqual("test4", collection[3]);
    }
  }
}