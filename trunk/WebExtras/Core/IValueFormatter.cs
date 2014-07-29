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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.Core
{
  /// <summary>
  /// A generic value formatter interface. The implementers of this interface MUST
  /// have a parameterless constructor
  /// </summary>
  public interface IValueFormatter
  {
    /// <summary>
    /// Formats the given value to a string
    /// </summary>
    /// <param name="propertyValue">Value to format</param>
    /// <param name="formatString">String format</param>
    /// <param name="sender">Full object</param>
    /// <returns>Formatted string</returns>
    string Format(object propertyValue, string formatString, object sender);
  }
}
