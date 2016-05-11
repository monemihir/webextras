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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace WebExtras.Mvc.tests
{
  /// <summary>
  ///   Generic tests across all classes in WebExtras.Mvc dll
  /// </summary>
  [TestFixture]
  public class GenericTest
  {
    /// <summary>
    ///   Test that all user facing properties which are collections are
    ///   either arrays or lists
    /// </summary>
    [Test]
    public void All_User_Facing_Collections_Are_Arrays_Or_Lists()
    {
      // Arrange
      string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Assembly a = Assembly.LoadFrom(location + "\\WebExtras.Mvc.dll");

      string[] ignoredTypes =
      {
        "CssClassList"
      };

      // Act
      foreach (Type t in a.GetTypes().Where(y => !y.IsSealed))
      {
        List<PropertyInfo> props = t.GetProperties().Where(p => !p.PropertyType.IsSealed).ToList();

        foreach (PropertyInfo prop in props)
        {
          Type pType = prop.PropertyType;

          if (ignoredTypes.Contains(pType.Name))
            continue;

          List<Type> ifaces =
            pType.GetInterfaces()
              .Where(x => x.Name == typeof(ICollection).Name || x.Name == typeof(IEnumerable).Name)
              .ToList();

          if (ifaces.Count > 0 && !pType.Name.StartsWith("IDictionary"))
          {
            Assert.IsTrue(pType.IsArray || pType.Name == "List`1",
              t.FullName + "." + prop.Name + " must be either an array or a list");
          }
        }
      }
    }
  }
}