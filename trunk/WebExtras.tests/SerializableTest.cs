using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace WebExtras.tests
{
  /// <summary>
  /// Check that all classes are marked serializable
  /// </summary>
  [TestClass]
  public class SerializableTest
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
  }
}
