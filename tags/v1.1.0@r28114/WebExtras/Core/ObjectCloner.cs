using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WebExtras.Core
{
  /// <summary>
  /// Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
  /// Provides a method for performing a deep copy of an object.
  /// Binary Serialization is used to perform the copy.
  /// </summary>
  public static class ObjectCloner
  {
    /// <summary>
    /// Perform a deep Copy of the object. Note that the object to be cloned
    /// must be seriablizable i.e it and all it's children must be decorated
    /// the the [Serialize] decorator
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>The copied object.</returns>
    public static T Clone<T>(T source)
    {
      if (!typeof(T).IsSerializable)
      {
        throw new ArgumentException("The type must be serializable.", "source");
      }

      // Don't serialize a null object, simply return the default for that object
      if (Object.ReferenceEquals(source, null))
      {
        return default(T);
      }

      IFormatter formatter = new BinaryFormatter();
      Stream stream = new MemoryStream();
      using (stream)
      {
        formatter.Serialize(stream, source);
        stream.Seek(0, SeekOrigin.Begin);
        return (T)formatter.Deserialize(stream);
      }
    }
  }
}
