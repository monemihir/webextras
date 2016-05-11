using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests
{
  /// <summary>
  /// Generic tests across all classes in WebExtras.Mvc dll
  /// </summary>
  [TestClass]
  public class GenericTest
  {
    /// <summary>
    /// Test that all user facing properties which are collections are
    /// either arrays or lists
    /// </summary>
    [TestMethod]
    public void All_User_Facing_Collections_Are_Arrays_Or_Lists()
    {
      // Arrange
      Assembly a = Assembly.LoadFrom("WebExtras.Mvc.dll");

      string[] ignoredTypes = new[] { 
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

          List<Type> ifaces = pType.GetInterfaces().Where(x => x.Name == typeof(ICollection).Name || x.Name == typeof(IEnumerable).Name).ToList();

          if (ifaces.Count > 0 && !pType.Name.StartsWith("IDictionary"))
          {
            Assert.IsTrue(pType.IsArray || pType.Name == "List`1", t.FullName + "." + prop.Name + " must be either an array or a list");
          }
        }
      }
    }
  }
}
