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

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// A list of WebExtras constants
  /// </summary>
  [Serializable]
  public sealed class WebExtrasMvcConstants
  {
    /// <summary>
    /// Flag indicating whether to enable the generation of
    /// automatic IDs for all HTML elements rendered by
    /// the WebExtras.Mvc library
    /// </summary>
    public static bool EnableAutoIdGeneration { get; set; }

    /// <summary>
    /// The version of Bootstrap whose extensions you want to use
    /// </summary>
    public static EBootstrapVersion BootstrapVersion = EBootstrapVersion.NONE;

    /// <summary>
    /// Gumby theme to use
    /// </summary>
    public static EGumbyTheme GumbyTheme = EGumbyTheme.None;
  }
}
