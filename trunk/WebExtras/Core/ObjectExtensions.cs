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

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace WebExtras.Core
{
  /// <summary>
  ///   Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
  ///   Provides a method for performing a deep copy of an object.
  ///   Binary Serialization is used to perform the copy.
  /// </summary>
  [Serializable]
  public static class ObjectExtensions
  {
    /// <summary>
    ///   Perform a deep Copy of the object. Note that the object to be cloned
    ///   must be seriablizable i.e it and all it's children must be decorated
    ///   the the [Serialize] decorator
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>The copied object.</returns>
    public static T DeepClone<T>(this T source)
    {
      if (!typeof(T).IsSerializable)
      {
        throw new ArgumentException("The type must be serializable.", "source");
      }

      // Don't serialize a null object, simply return the default for that object
      if (ReferenceEquals(source, null))
      {
        return default(T);
      }

      IFormatter formatter = new BinaryFormatter();
      Stream stream = new MemoryStream();
      using (stream)
      {
        formatter.Serialize(stream, source);
        stream.Seek(0, SeekOrigin.Begin);
        return (T) formatter.Deserialize(stream);
      }
    }

    /// <summary>
    ///   Convert current object to it's JSON representation
    /// </summary>
    /// <param name="source">Current object</param>
    /// <returns>JSON object</returns>
    public static string ToJson(this object source)
    {
      return ToJson(source, WebExtrasConstants.JsonSerializerSettings);
    }

    /// <summary>
    ///   Convert current object to it's JSON representation
    /// </summary>
    /// <param name="source">Current object</param>
    /// <param name="settings">JSON serialisation settings</param>
    /// <returns>JSON object</returns>
    public static string ToJson(this object source, JsonSerializerSettings settings)
    {
      return JsonConvert.SerializeObject(source, settings);
    }
  }
}