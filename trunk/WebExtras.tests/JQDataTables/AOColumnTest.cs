using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  /// AOColumn unit tests
  /// </summary>
  [TestClass]
  public class AOColumnTest
  {
    /// <summary>
    /// Test that FromType method returns correct columns
    /// </summary>
    [TestMethod]
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
