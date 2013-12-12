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

namespace WebExtras.Core
{
  /// <summary>
  /// A generic interface used to decide the StringValue of an enum value
  /// at run time
  /// </summary>
  public interface IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <returns>The string value to be used for the enum value</returns>
    string Decide();
  }
}
