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

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  /// <summary>
  ///   Datatable records unit tests
  /// </summary>
  [TestFixture]
  public class DatatableRecordsSortExtensionTest
  {
    private DatatableRecords m_records;

    /// <summary>
    ///   Test setup
    /// </summary>
    [SetUp]
    public void Initialize()
    {
      m_records = new DatatableRecords();
      m_records.aaData = new List<string[]>
      {
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"}
      }.ToArray();
      m_records.iTotalDisplayRecords = m_records.aaData.Count();
      m_records.iTotalRecords = m_records.aaData.Count();
    }

    /// <summary>
    ///   Test that the constructor initializes
    ///   the properties properly
    /// </summary>
    [Test]
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
    ///   Test that ascending sort works properly
    /// </summary>
    [Test]
    public void Sort_Ascending_Works_Properly()
    {
      // Arrange
      // sorted on numeric column 0
      string[][] expected0 = new List<string[]>
      {
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"}
      }.ToArray();

      // sorted on string column 1
      string[][] expected1 = new List<string[]>
      {
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"}
      }.ToArray();

      // sorted on date time column 2
      string[][] expected2 = new List<string[]>
      {
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"}
      }.ToArray();

      // sorted on currency column 3
      string[][] expected3 = new List<string[]>
      {
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"}
      }.ToArray();

      // Act
      // sort on numeric column
      IEnumerable<IEnumerable<string>> result = m_records.aaData.Sort(0, ESort.Ascending);

      // Assert
      AssertSortedAAData(expected0, result);

      // Act
      // sort on string column
      result = m_records.aaData.Sort(1, ESort.Ascending);

      // Assert      
      AssertSortedAAData(expected1, result);

      // Act
      // sort on date time column
      result = m_records.aaData.Sort(2, ESort.Ascending);

      // Assert      
      AssertSortedAAData(expected2, result);

      // Act
      // sort on currency column
      result = m_records.aaData.Sort(3, ESort.Ascending);

      // Assert      
      AssertSortedAAData(expected3, result);
    }

    /// <summary>
    ///   Test that ascending sort with a custom parser works properly.
    /// </summary>
    [Test]
    public void Sort_Ascending_With_Custom_Parser_Works_Properly()
    {
      // Arrange
      // Setup a custom parser for the first column to parse as follows:
      // <a href='/displayplan/16'>2</a> should return 16
      Func<string, object> parser = str =>
      {
        int val = int.Parse(str.Split('\'')[1].Split('/').Last());
        return val;
      };
      Dictionary<int, Func<string, object>> parsers = new Dictionary<int, Func<string, object>>();
      parsers.Add(0, parser);

      // sorted with the custom parser
      string[][] expected = new List<string[]>
      {
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"}
      }.ToArray();

      // Act
      // sort based on the custom parser
      IEnumerable<IEnumerable<string>> result = m_records.aaData.Sort(0, ESort.Ascending, parsers);

      // Assert
      AssertSortedAAData(expected, result);
    }

    /// <summary>
    ///   Test that descending sort works properly
    /// </summary>
    [Test]
    public void Sort_Descending_Works_Properly()
    {
      // Arrange
      // sorted on numeric column 0
      string[][] expected0 = new List<string[]>
      {
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"}
      }.ToArray();

      // sorted on string column 1
      string[][] expected1 = new List<string[]>
      {
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"}
      }.ToArray();

      // sorted on date time column 2
      string[][] expected2 = new List<string[]>
      {
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"}
      }.ToArray();

      // sorted on currency column 3
      string[][] expected3 = new List<string[]>
      {
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"},
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"}
      }.ToArray();

      // Act
      // sort on numeric column
      IEnumerable<IEnumerable<string>> result = m_records.aaData.Sort(0, ESort.Descending);

      // Assert
      AssertSortedAAData(expected0, result);

      // Act
      // sort on string column
      result = m_records.aaData.Sort(1, ESort.Descending);

      // Assert      
      AssertSortedAAData(expected1, result);

      // Act
      // sort on date time column
      result = m_records.aaData.Sort(2, ESort.Descending);

      // Assert      
      AssertSortedAAData(expected2, result);

      // Act
      // sort on currency column
      result = m_records.aaData.Sort(3, ESort.Descending);

      // Assert      
      AssertSortedAAData(expected3, result);
    }

    /// <summary>
    ///   Test that descending sort with a custom parser works properly.
    /// </summary>
    [Test]
    public void Sort_Descending_With_Custom_Parser_Works_Properly()
    {
      // Arrange
      // Setup a custom parser for the first column to parse as follows:
      // <a href='/displayplan/16'>2</a> should return 16
      Func<string, object> parser = str =>
      {
        int val = int.Parse(str.Split('\'')[1].Split('/').Last());
        return val;
      };
      Dictionary<int, Func<string, object>> parsers = new Dictionary<int, Func<string, object>>();
      parsers.Add(0, parser);

      // sorted with the custom parser
      string[][] expected = new List<string[]>
      {
        new[] {"<a href='/displayplan/24'>3</a>", "sneha", "2013-Mar-12", "&pound;12.00"},
        new[] {"<a href='/displayplan/16'>2</a>", "swati", "29May13", "$201.00"},
        new[] {"<a href='/displayplan/11'>1</a>", "mohan", "20 Mar 13", "$151.00"},
        new[] {"<a href='/displayplan/4'>4</a>", "mihir", "02-Jan-13", "&euro;15.00"}
      }.ToArray();

      // Act
      // sort based on the custom parser
      IEnumerable<IEnumerable<string>> result = m_records.aaData.Sort(0, ESort.Descending, parsers);

      // Assert
      AssertSortedAAData(expected, result);
    }

    /// <summary>
    ///   Assert that the 2 given collections are equals
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