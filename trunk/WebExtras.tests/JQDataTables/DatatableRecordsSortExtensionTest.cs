/*
* This file is part of - Code Library
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

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  /// Datatable records unit tests
  /// </summary>
  [TestClass]
  public class DatatableRecordsSortExtensionTest
  {
    private DatatableRecords m_records;

    /// <summary>
    /// Test setup
    /// </summary>
    [TestInitialize]
    public void Initialize()
    {
      m_records = new DatatableRecords();
      m_records.aaData = new List<string[]> {
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" },
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" }
      };
      m_records.iTotalDisplayRecords = m_records.aaData.Count();
      m_records.iTotalRecords = m_records.aaData.Count();
    }

    /// <summary>
    /// Test that the constructor initializes
    /// the properties properly
    /// </summary>
    [TestMethod]
    public void Ctor_Test()
    {
      // Act
      m_records = new DatatableRecords();

      // Assert
      Assert.AreEqual("1", m_records.sEcho);
      Assert.AreEqual(0, m_records.iTotalRecords);
      Assert.AreEqual(0, m_records.iTotalDisplayRecords);
      Assert.IsNotNull(m_records.aaData);
      Assert.AreEqual(0, m_records.aaData.Count());
    }

    /// <summary>
    /// Test that ascending sort works properly
    /// </summary>
    [TestMethod]
    public void Sort_Ascending_Works_Properly()
    {
      // Arrange
      // sorted on numeric column 0
      string[][] expected1 = new List<string[]> {
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" },
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" },
      }.ToArray();

      // sorted on string column 1
      string[][] expected2 = new List<string[]> {
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" },
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" }
      }.ToArray();

      // sorted on date time column 2
      string[][] expected3 = new List<string[]> {
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" },
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" }
      }.ToArray();

      // Act
      // sort on numeric column
      IEnumerable<IEnumerable<string>> result = m_records.aaData.Sort(0, SortType.Ascending);

      // Assert
      AssertSortedAAData(expected1, result);

      // Act
      // sort on string column
      result = m_records.aaData.Sort(1, SortType.Ascending);

      // Assert      
      AssertSortedAAData(expected2, result);

      // Act
      // sort on date time column
      result = m_records.aaData.Sort(2, SortType.Ascending);

      // Assert      
      AssertSortedAAData(expected3, result);
    }

    /// <summary>
    /// Test that descending sort works properly
    /// </summary>
    [TestMethod]
    public void Sort_Descending_Works_Properly()
    {
      // Arrange
      // sorted on numeric column 0
      string[][] expected1 = new List<string[]> {
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" },
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" }
      }.ToArray();

      // sorted on string column 1
      string[][] expected2 = new List<string[]> {
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" },
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" }
      }.ToArray();

      // sorted on date time column 2
      string[][] expected3 = new List<string[]> {
        new string[] { "<a href='/displayplan/16'>2</a>", "swati", "29May13" },
        new string[] { "<a href='/displayplan/11'>1</a>", "mohan", "20-Mar-13" },
        new string[] { "<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12" },
        new string[] { "<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13" }
      }.ToArray();

      // Act
      // sort on numeric column
      IEnumerable<IEnumerable<string>> result = m_records.aaData.Sort(0, SortType.Descending);

      // Assert
      AssertSortedAAData(expected1, result);

      // Act
      // sort on string column
      result = m_records.aaData.Sort(1, SortType.Descending);

      // Assert      
      AssertSortedAAData(expected2, result);

      // Act
      // sort on date time column
      result = m_records.aaData.Sort(2, SortType.Descending);

      // Assert      
      AssertSortedAAData(expected3, result);
    }

    /// <summary>
    /// Test that the ToString method JSON converts the DatatableRecords
    /// object properly
    /// </summary>
    [TestMethod]
    public void ToString_Works_Properly()
    {
      // Arrange
      string expected = "{\"iTotalDisplayRecords\":4,\"iTotalRecords\":4,\"sEcho\":\"1\",\"aaData\":[[\"mihir\"]]}";
      m_records.aaData = new List<string[]> { new string[] { "mihir" } };

      // Act
      string result = m_records.ToString();

      // Assert
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Assert that the 2 given collections are equals
    /// </summary>
    /// <param name="expected">Expected collection</param>
    /// <param name="actual">Actual collection as result of the Act phase</param>
    public void AssertSortedAAData(IEnumerable<IEnumerable<string>> expected, IEnumerable<IEnumerable<string>> actual)
    {
      string[][] expectedArr = expected.Select(f => f.ToArray()).ToArray();
      string[][] actualArr = actual.Select(f => f.ToArray()).ToArray();

      for (int i = 0; i < expectedArr.Length; i++)
      {
        for (int j = 0; j < expectedArr[0].Length; j++)
        {
          Assert.AreEqual(expectedArr[i][j], actualArr[i][j]);
        }
      }
    }
  }
}