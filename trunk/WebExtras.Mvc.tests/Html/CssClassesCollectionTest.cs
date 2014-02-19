/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests.Html
{
  /// <summary>
  /// CssClassesCollection unit tests
  /// </summary>
  [TestClass]
  public class CssClassesCollectionTest
  {
    /// <summary>
    /// Test that Add method adds individual classes
    /// </summary>
    [TestMethod]
    public void Add_Method_Adds_Individual_Classes()
    {
      // arrange
      string classes = "test1 test2 test3";

      // act
      CssClassesCollection collection = new CssClassesCollection();
      collection.Add(classes);

      // assert
      Assert.AreEqual(3, collection.Count);
      Assert.AreEqual("test1", collection[0]);
      Assert.AreEqual("test2", collection[1]);
      Assert.AreEqual("test3", collection[2]);
    }

    /// <summary>
    /// Test that the AddRange method adds individual classes
    /// </summary>
    [TestMethod]
    public void AddRange_Method_Adds_Individual_Classes()
    {
      // arrange
      string[] classes = new[] { "test1 test2 test3", "test4" };

      // act
      CssClassesCollection collection = new CssClassesCollection();
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
