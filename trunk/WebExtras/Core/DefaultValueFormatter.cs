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

namespace WebExtras.Core
{
  /// <summary>
  ///   The default value formatter. All integers are formatted to their string
  ///   equivalents while all precision data types are formatted to a precision
  ///   of 2 decimal places. Dates are formatted to ISO date format without the
  ///   millisecond and timezone info.
  /// </summary>
  [Serializable]
  public class DefaultValueFormatter : IValueFormatter
  {
    /// <summary>
    ///   Formats the given value to a string
    /// </summary>
    /// <param name="propertyValue">Value to format</param>
    /// <param name="formatString">String format</param>
    /// <param name="sender">Full object</param>
    /// <returns>Formatted string</returns>
    public virtual string Format(object propertyValue, string formatString, object sender)
    {
      Type type = propertyValue.GetType();
      string value = propertyValue.ToString();

      switch (type.Name)
      {
        case "Decimal":
        case "Float":
        case "Double":
          value = double.Parse(propertyValue.ToString()).ToString(formatString ?? "F02");
          break;

        case "DateTime":
          value = DateTime.Parse(propertyValue.ToString()).ToString(formatString ?? "yyyy-MM-dd hh:mm:ss");
          break;
      }

      return value;
    }
  }
}