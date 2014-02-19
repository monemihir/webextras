/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Globalization;
using System.Reflection;

namespace WebExtras.Core
{
  /// <summary>
  /// Enum extenstions
  /// </summary>
  public static class EnumExtentions
  {
    /// <summary>
    /// Convert a given enum value to titlecase
    /// </summary>
    /// <param name="val">Enum value to be converted</param>
    /// <returns>Titlecase converted value</returns>
    public static string ToTitleCase(this Enum val)
    {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(val.ToString().ToLowerInvariant());
    }

    /// <summary>
    /// Gets the Enum value's string value which is decorated by using
    /// StringValue attribute
    /// </summary>
    /// <param name="value">Enum value to be checked</param>
    /// <param name="sender">[Optional] The sender object to be sent to the 
    /// WebExtras.Core.IStringValueDecider.Decide() in order to assist in deciding the value</param>
    /// <returns>Associated string value, else null</returns>
    public static string GetStringValue(this Enum value, object sender = null)
    {
      string output = null;
      Type type = value.GetType();
      FieldInfo fi = type.GetField(value.ToString());
      StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
      if (attrs != null && attrs.Length > 0)
      {
        if (attrs[0].HasCustomDecider)
        {
          var obj = Activator.CreateInstance(attrs[0].ValueDeciderType);

          MethodInfo decideMethod = obj.GetType().GetMethod("Decide");

          output = (string)decideMethod.Invoke(obj, new object[] { sender });
        }
        else
        {
          output = attrs[0].Value;
        }
      }



      





      return output;
    }
  }
}