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
using System.ComponentModel;
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
    ///   StringValue attribute. <see cref="StringValueAttribute"/> placed
    /// at an individual Enum value supersedes one placed at Enum level
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

      if (attrs.Length > 0)
      {
        if (attrs[0].HasCustomDecider)
        {
          // create the value decider args instance
          Type valueDeciderArgsBaseType = typeof(StringValueDeciderArgs<>);
          Type[] templateTypeArgs = { enumType };

          Type argsType = valueDeciderArgsBaseType.MakeGenericType(templateTypeArgs);
          object args = Activator.CreateInstance(argsType, new[] { value, sender });
          
          // create value decider instance
          object obj = Activator.CreateInstance(attrs[0].ValueDeciderType);

          MethodInfo decideMethod = obj.GetType().GetMethod("Decide", new[] { argsType });

          output = (string)decideMethod.Invoke(obj, new[] { args });
        }
        else
        {
          output = attrs[0].Value;
        }
      }
      else
        throw new InvalidUsageException("Cannot have multiple decorations of [StringValue] attribute");

      return output;
    }
  }
}