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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  /// StringValueAttribute unit tests
  /// </summary>
  [TestClass]
  public class StringValueAttributeTest
  {
    /// <summary>
    /// Constuctor initializes fields properly
    /// </summary>
    [TestMethod]
    public void Ctor_Test()
    {
      // Act
      StringValueAttribute sva = new StringValueAttribute("value value");

      // Assert
      Assert.AreEqual("value value", sva.Value);
    }
  }
}