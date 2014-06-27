using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  /// Test class to facilitate unit tests
  /// </summary>
  public class DatatableTestClass
  {
    [AOColumn(Index = 3, sTitle = "My Double Column", sWidth = "10%", sType = EAOColumn.Numeric)]
    public double MyDoubleColumn { get; set; }

    [AOColumn(bSearchable = true)]
    public string MyStringColumn { get; set; }

    [AOColumn(bSortable = true, sClass = "myCssClass", ValueFormatter = typeof(ValueFormatterTestClass))]
    public int MyIntegerColumn { get; set; }

    public bool MyNonColumn { get; set; }

    public static DatatableTestClass[] CreateData()
    {
      return new[] { 
        new DatatableTestClass{ MyDoubleColumn = 1, MyIntegerColumn = 2, MyNonColumn = false, MyStringColumn = "Row 1" },
        new DatatableTestClass{ MyDoubleColumn = 3, MyIntegerColumn = 4, MyNonColumn = false, MyStringColumn = "Row 2" },
        new DatatableTestClass{ MyDoubleColumn = 5, MyIntegerColumn = 6, MyNonColumn = false, MyStringColumn = "Row 3" },
        new DatatableTestClass{ MyDoubleColumn = 7, MyIntegerColumn = 8, MyNonColumn = false, MyStringColumn = "Row 4" },
        new DatatableTestClass{ MyDoubleColumn = 9, MyIntegerColumn = 10, MyNonColumn = false, MyStringColumn = "Row 5" }
      };
    }
  }
}
