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
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebExtras.tests
{
  /// <summary>
  ///   Generic tests across all classes of WebExtras.dll
  /// </summary>
  [TestFixture]
  public class GenericTest
  {
    /// <summary>
    ///   Test that all classes are marked serializable
    /// </summary>
    [Test]
    public void All_Classes_Are_Serializable()
    {
      // Arrange
      string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Assembly a = Assembly.LoadFrom(location + "\\WebExtras.dll");

      string[] ignoredTypes =
      {
        ""
      };

      // Assert
      foreach (Type type in a.GetTypes())
      {
        if (!type.IsSealed && type.IsVisible && !type.IsInterface && !ignoredTypes.Contains(type.FullName))
          Assert.IsTrue(type.IsSerializable, type.FullName + " is not marked as serializable");
      }
    }

    /// <summary>
    ///   Test that all user facing properties which are collections are
    ///   either arrays or lists
    /// </summary>
    [Test]
    public void All_User_Facing_Collections_Are_Arrays_Or_Lists()
    {
      // Arrange
      string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Assembly a = Assembly.LoadFrom(location + "\\WebExtras.dll");

      string[] ignoredTypes =
      {
        "CssClassList",
        "HtmlComponentList"
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

          List<Type> ifaces = pType.GetInterfaces().Where(x => x.Name == typeof(ICollection).Name).ToList();

          if (ifaces.Count > 0 && !pType.IsAssignableFrom(typeof(IDictionary)))
          {
            Assert.IsTrue(pType.IsArray || pType.Name == "List`1",
              t.FullName + "." + prop.Name + " must be either an array or a list");
          }
        }
      }
    }

    /// <summary>
    ///   Test that all Enum properties of all types have custom
    ///   JsonConverter objects attached
    /// </summary>
    [Test]
    public void All_Enums_Have_JsonConverters_Attached()
    {
      // Arrange
      string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      Assembly a = Assembly.LoadFrom(location + "\\WebExtras.dll");
      const string namespaceToSearch = "WebExtras";
      List<Type> knownEnumTypes = a.GetTypes()
        .Where(t => !string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(namespaceToSearch))
        .ToList();

      string[] ignoredNamespaces =
      {
        "WebExtras.Html",
        "WebExtras.Bootstrap",
        "WebExtras.Bootstrap.v2",
        "WebExtras.Bootstrap.v3"
      };

      string[] ignoredPropertyTypes =
      {
        "WebExtras.JQDataTables.ESort",
        "WebExtras.JQDataTables.EPagination"
      };

      string[] ignoredPropertyNames =
      {
        "WebExtras.JQDataTables.AOColumnAttribute.sType"
      };

      // Act & Assert
      foreach (Type t in knownEnumTypes)
      {
        List<PropertyInfo> props = t.GetProperties().ToList();

        foreach (var prop in props)
        {
          Type actualType = prop.PropertyType.Name.StartsWith("Nullable")
            ? prop.PropertyType.GetGenericArguments()[0]
            : prop.PropertyType;

          if (!actualType.IsEnum)
            continue;

          if (ignoredPropertyTypes.Contains(actualType.FullName) ||
              ignoredPropertyNames.Contains(t.FullName + "." + prop.Name) ||
              ignoredNamespaces.Contains(t.Namespace))
            continue;

          object[] arr = prop.GetCustomAttributes(typeof(JsonConverterAttribute), false);

          Assert.IsTrue(arr.Length == 1,
            "Property: " + t.FullName + "." + prop.Name + " is not decorated with a custom JsonConverter");
        }
      }
    }
  }
}