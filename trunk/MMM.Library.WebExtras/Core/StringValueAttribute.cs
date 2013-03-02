/*
* This file is part of - Code Library
* Copyright (C) 2013 Mihir Mone
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

namespace MMM.Library.WebExtras.Core
{
  /// <summary>
  /// String value attribute which can be applied to Enumerations
  /// to resolve to STRING rather than the default INT
  /// </summary>
  public class StringValueAttribute : Attribute
  {
    /// <summary>
    /// String value
    /// </summary>
    private string m_value;

    /// <summary>
    /// String value
    /// </summary>
    public string Value { get { return m_value; } }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="value">Value to be associated with the enum attribute</param>
    public StringValueAttribute(string value)
    {
      m_value = value;
    }
  }
}