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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace WebExtras.Core
{
  /// <summary>
  ///   Enum extenstions
  /// </summary>
  public static class EnumExtentions
  {
    /// <summary>
    ///   A string value decider lookup to allow attaching of string value deciders to enum externally i.e when the enum is
    ///   declared in an assembly other than current
    /// </summary>
    internal static readonly IDictionary<Type, Type> ExternalStringValueDecidersLookup = new Dictionary<Type, Type>();

    /// <summary>
    ///   Convert a given enum value to titlecase
    /// </summary>
    /// <param name="val">Enum value to be converted</param>
    /// <returns>Titlecase converted value</returns>
    public static string ToTitleCase(this Enum val)
    {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(val.ToString().ToLowerInvariant());
    }

    /// <summary>
    ///   Gets the Enum value's string value which is decorated by using
    ///   StringValue attribute. <see cref="StringValueAttribute" /> placed
    ///   at an individual Enum value supersedes one placed at Enum level
    /// </summary>
    /// <param name="value">Enum value to be checked</param>
    /// <param name="sender">
    ///   [Optional] The sender object to be sent to the
    ///   WebExtras.Core.IStringValueDecider.Decide() in order to assist in deciding the value
    /// </param>
    /// <returns>Associated string value, else null</returns>
    public static string GetStringValue(this Enum value, object sender = null)
    {
      string output;
      Type enumType = value.GetType();

      StringValueAttribute[] attrs = enumType.GetCustomAttributes<StringValueAttribute>(false).ToArray();

      FieldInfo fi = enumType.GetField(value.ToString());
      StringValueAttribute[] fieldAttrs = fi.GetCustomAttributes<StringValueAttribute>(false).ToArray();

      // type level attributes superseded by field level attributes
      attrs = fieldAttrs.Length > 0 ? fieldAttrs : attrs;

      Type deciderType = null;

      if (attrs.Length > 0)
      {
        if (attrs[0].HasCustomDecider)
          deciderType = attrs[0].ValueDeciderType;

        output = attrs[0].Value;
      }
      else
      {
        //string name = string.Format("{0}.{1}", enumType.Name, value);
        //throw new InvalidUsageException("Cannot have multiple decorations of [StringValue] attribute for enum value: " +
        //                                name);
        output = value.ToString();
      }

      deciderType = ExternalStringValueDecidersLookup.ContainsKey(enumType)
        ? ExternalStringValueDecidersLookup[enumType]
        : deciderType;

      if (deciderType != null)
      {
        // create the value decider args instance
        Type valueDeciderArgsBaseType = typeof(StringValueDeciderArgs<>);
        Type[] templateTypeArgs = {enumType};

        Type argsType = valueDeciderArgsBaseType.MakeGenericType(templateTypeArgs);
        object args = Activator.CreateInstance(argsType, value, sender);

        // create value decider instance
        object obj = Activator.CreateInstance(deciderType);

        MethodInfo decideMethod = obj.GetType().GetMethod("Decide", new[] {argsType});

        output = (string) decideMethod.Invoke(obj, new[] {args});
      }

      return output;
    }
  }
}