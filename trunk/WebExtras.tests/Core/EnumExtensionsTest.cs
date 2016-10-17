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
using WebExtras.Core;

namespace WebExtras.tests.Core
{
  /// <summary>
  ///   Test enum
  /// </summary>
  [StringValue(typeof(TestStringValueDecider))]
  public enum TestEnum
  {
    [StringValue("test me")]
    testvalue,

    [StringValue(typeof(TestStringValueDecider))]
    customdecider,

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
        return args.Sender + " " + args.Value;

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
  [TestFixture]
  public class EnumExtensionsTest
  {
    /// <summary>
    ///   Test that the ToTitlecase method works properly
    /// </summary>
    [Test]
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
    [Test]
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
    ///   as expected
    /// </summary>
    [Test]
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
    ///   as expected
    /// </summary>
    [Test]
    public void GetStringValue_With_TypeLevel_CustomDecider_Works_Properly()
    {
      // act
      string result = TestEnum.typeleveldecider.GetStringValue();

      // assert
      Assert.AreEqual("typeleveldecider from type level attribute", result);
    }
  }
}