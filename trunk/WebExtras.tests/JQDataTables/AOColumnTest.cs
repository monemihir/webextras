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
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  ///   AOColumn unit tests
  /// </summary>
  [TestFixture]
  public class AOColumnTest
  {
    /// <summary>
    ///   Test that FromType method returns correct columns
    /// </summary>
    [Test]
    public void FromType_Returns_Correct_AOColumns()
    {
      // Act
      AOColumn[] result = AOColumn.FromType<DatatableTestClass>();

      // Assert
      Assert.AreEqual(3, result.Length);

      Assert.IsTrue(result[0].bSearchable.Value);

      Assert.IsTrue(result[1].bSortable.Value);
      Assert.AreEqual("myCssClass", result[1].sClass);

      Assert.AreEqual("My Double Column", result[2].sTitle);
      Assert.AreEqual("10%", result[2].sWidth);
      Assert.AreEqual(EAOColumn.Numeric, result[2].sType.Value);
    }
  }
}