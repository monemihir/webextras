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

using MMM.Library.WebExtras.Core;

namespace MMM.Library.WebExtras.Mvc
{
  /// <summary>
  /// Type of action message
  /// </summary>
  public enum ActionMessageType
  {
    /// <summary>
    /// Success message
    /// </summary>
    [StringValue("success")]
    Success,

    /// <summary>
    /// Error message
    /// </summary>
    [StringValue("error")]
    Error,

    /// <summary>
    /// Warning message
    /// </summary>
    [StringValue("warning")]
    Warning,

    /// <summary>
    /// Information message
    /// </summary>
    [StringValue("info")]
    Information
  }
}