using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  /// DatatableRecords unit tests
  /// </summary>
  [TestClass]
  public class DatatableRecordsTest
  {
    /// <summary>
    /// Test that From method returns correct records
    /// </summary>
    [TestMethod]
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
