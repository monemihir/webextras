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

using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  ///   Test class to facilitate unit tests
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
      return new[]
      {
        new DatatableTestClass {MyDoubleColumn = 1, MyIntegerColumn = 2, MyNonColumn = false, MyStringColumn = "Row 1"},
        new DatatableTestClass {MyDoubleColumn = 3, MyIntegerColumn = 4, MyNonColumn = false, MyStringColumn = "Row 2"},
        new DatatableTestClass {MyDoubleColumn = 5, MyIntegerColumn = 6, MyNonColumn = false, MyStringColumn = "Row 3"},
        new DatatableTestClass {MyDoubleColumn = 7, MyIntegerColumn = 8, MyNonColumn = false, MyStringColumn = "Row 4"},
        new DatatableTestClass {MyDoubleColumn = 9, MyIntegerColumn = 10, MyNonColumn = false, MyStringColumn = "Row 5"}
      };
    }
  }
}