/*
* This file is part of - WebExtras
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
using System.Reflection;

namespace WebExtras.Core
{
  /// <summary>
  /// String value attribute which can be applied to Enumerations
  /// to resolve to STRING rather than the default INT
  /// </summary>
  [Serializable]
  public class StringValueAttribute : Attribute
  {
    /// <summary>
    /// String value
    /// </summary>
    private readonly string m_value;

    /// <summary>
    /// Custom string value decider
    /// </summary>
    public Type ValueDeciderType { get; private set; }

    /// <summary>
    /// Flag indicating whether this attribute has a custom string value
    /// decider associated with it
    /// </summary>
    public bool HasCustomDecider { get; private set; }

    /// <summary>
    /// String value
    /// </summary>
    public string Value { get { return m_value; } }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">Value to be associated with the enum attribute</param>
    public StringValueAttribute(string value)
    {
      m_value = value;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="t">Decide the string value based on the given type. The given type MUST
    /// implement the <see cref="WebExtras.Core.IStringValueDecider"/> interface and have a 
    /// default parameterless constructor</param>
    /// <exception cref="System.InvalidOperationException">Thrown when the given type does not
    /// implement WebExtras.Core.IStringValueDecider interface</exception>
    public StringValueAttribute(Type t)
    { 
      if (!typeof(IStringValueDecider).IsAssignableFrom(t))
        throw new InvalidOperationException("The type " + t.FullName + " does not implement WebExtras.Core.IStringValueDecider");

      ValueDeciderType = t;
      HasCustomDecider = true;
    }
  }
}