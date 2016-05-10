// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  ///   Test enum
  /// </summary>
  [StringValue(typeof(TestStringValueDecider))]
  public enum TestEnum
  {
    [StringValue("test me")] testvalue,

    [StringValue(typeof(TestStringValueDecider))] customdecider,

    typeleveldecider
  }

  /// <summary>
  ///   Test string value decider
  /// </summary>
  public class TestStringValueDecider : IStringValueDecider<TestEnum>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<TestEnum> args)
    {
      if (args.Sender != null)
        return args.Sender.ToString() + " " + args.Value;
      
      if (args.Value == TestEnum.typeleveldecider)
      {
        return args.Value + " from type level attribute";
      }

      return args.Value.ToString();
    }
  }

  /// <summary>
  ///   Enum extensions unit tests
  /// </summary>
  [TestClass]
  public class EnumExtensionsTest
  {
    /// <summary>
    ///   Test that the ToTitlecase method works properly
    /// </summary>
    [TestMethod]
    public void ToTitlecase_Works_Properly()
    {
      // Act
      string result = TestEnum.testvalue.ToTitleCase();

      // Assert
      Assert.AreEqual("Testvalue", result);
    }

    /// <summary>
    ///   Test that the GetStringValue method works properly
    /// </summary>
    [TestMethod]
    public void GetStringValue_Works_Properly()
    {
      // Act
      string result = TestEnum.testvalue.GetStringValue();

      // Assert
      Assert.AreEqual("test me", result);
    }

    /// <summary>
    ///   Test that the GetStringValue method for an enum value
    ///   with a field level custom string value decider works 
    /// as expected
    /// </summary>
    [TestMethod]
    public void GetStringValue_With_FieldLevel_CustomDecider_Works_Properly()
    {
      // act
      string result = TestEnum.customdecider.GetStringValue();

      // assert
      Assert.AreEqual("customdecider", result);

      // act
      result = TestEnum.customdecider.GetStringValue("blah blah");

      // assert
      Assert.AreEqual("blah blah customdecider", result);
    }

    /// <summary>
    ///   Test that the GetStringValue method for an enum value
    ///   with a type level custom string value decider works 
    /// as expected
    /// </summary>
    [TestMethod]
    public void GetStringValue_With_TypeLevel_CustomDecider_Works_Properly()
    {
      // act
      string result = TestEnum.typeleveldecider.GetStringValue();

      // assert
      Assert.AreEqual("typeleveldecider from type level attribute", result);
    }
  }
}