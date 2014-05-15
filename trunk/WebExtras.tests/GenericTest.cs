using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

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
  }
}
