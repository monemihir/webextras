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
  ///   DatatableRecords unit tests
  /// </summary>
  [TestFixture]
  public class DatatableRecordsTest
  {
    /// <summary>
    ///   Test that From method returns correct records
    /// </summary>
    [Test]
    public void From_Returns_Correct_Records()
    {
      // Arrange
      DatatableTestClass[] records = DatatableTestClass.CreateData();

      // Act
      DatatableRecords result = DatatableRecords.From(records);

      // Assert
      Assert.AreEqual(5, result.aaData.Length);
    }
  }
}