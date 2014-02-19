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
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Indicates the type of HTML button to be rendered
  /// </summary>
  [Serializable]
  public enum EButton
  {
    /// <summary>
    /// Regular button
    /// </summary>
    [StringValue("button")]
    Regular,

    /// <summary>
    /// Reset button
    /// </summary>
    [StringValue("reset")]
    Reset,

    /// <summary>
    /// Submit button
    /// </summary>
    [StringValue("submit")]
    Submit
  }
}