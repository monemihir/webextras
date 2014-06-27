using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Newtonsoft.Json;

namespace WebExtras.tests
{
  /// <summary>
  /// Generic tests across all classes of WebExtras.dll
  /// </summary>
  [TestClass]
  public class GenericTest
  {
    /// <summary>
    /// Test that all classes are marked serializable
    /// </summary>
    [TestMethod]
    public void All_Classes_Are_Serializable()
    {
      // Arrange
      Assembly a = Assembly.LoadFrom("WebExtras.dll");

      // Assert
      foreach (Type type in a.GetTypes())
      {
        if (!type.IsSealed && !type.IsInterface)
          Assert.IsTrue(type.IsSerializable, type.FullName + " is not marked as serializable");

      }
    }

    /// <summary>
    /// Test that all user facing properties which are collections are
    /// either arrays or lists
    /// </summary>
    [TestMethod]
    public void All_User_Facing_Collections_Are_Arrays_Or_Lists()
    {
      // Arrange
      Assembly a = Assembly.LoadFrom("WebExtras.dll");

      // Act
      foreach (Type t in a.GetTypes().Where(y => !y.IsSealed))
      {
        List<PropertyInfo> props = t.GetProperties().Where(p => !p.PropertyType.IsSealed).ToList();

        foreach (PropertyInfo prop in props)
        {
          Type pType = prop.PropertyType;

          List<Type> ifaces = pType.GetInterfaces().Where(x => x.Name == typeof(ICollection).Name).ToList();

          if (ifaces.Count > 0 && !pType.IsAssignableFrom(typeof(IDictionary)))
          {
            Assert.IsTrue(pType.IsArray || pType.Name == "List`1", t.FullName + "." + prop.Name + " must be either an array or a list");
          }
        }
      }
    }

    /// <summary>
    /// Test that all Enum properties of all types have custom
    /// JsonConverter objects attached
    /// </summary>
    [TestMethod]
    public void All_Enums_Have_JsonConverters_Attached()
    {
      // Arrange
      const string namespaceToSearch = "WebExtras";
      List<Type> knownEnumTypes = Assembly.LoadFrom("WebExtras.dll").GetTypes()
        .Where(t => !string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(namespaceToSearch))
        .ToList();
      string[] ignoredPropertyTypes =
      { 
        "WebExtras.JQDataTables.ESort",
        "WebExtras.JQDataTables.EPagination"
      };

      string[] ignoredPropertyNames = { "WebExtras.JQDataTables.AOColumnAttribute.sType" };

      // Act & Assert
      foreach (Type t in knownEnumTypes)
      {
        List<PropertyInfo> props = t.GetProperties().ToList();

        foreach (var prop in props)
        {
          Type actualType = prop.PropertyType.Name.StartsWith("Nullable") ? prop.PropertyType.GetGenericArguments()[0] : prop.PropertyType;

          if (!actualType.IsEnum)
            continue;

          if (ignoredPropertyTypes.Contains(actualType.FullName) ||
            ignoredPropertyNames.Contains(t.FullName + "." + prop.Name))
            continue;

          object[] arr = prop.GetCustomAttributes(typeof(JsonConverterAttribute), false);

          Assert.IsTrue(arr.Length == 1, "Property: " + t.FullName + "." + prop.Name + " is not decorated with a custom JsonConverter");
        }
      }
    }
  }
}
