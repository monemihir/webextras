/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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

using WebExtras.Core;

namespace WebExtras.DemoApp.App_Start
{
  /// <summary>
  /// A list of all content bundles available
  /// </summary>
  public enum ContentBundle
  {
    /// <summary>
    /// Main bundle
    /// </summary>
    [StringValue("css-main")]
    CSSMain,

    /// <summary>
    /// Core jQuery, jQuery UI and any other core libraries
    /// </summary>
    [StringValue("js-base")]
    JSBase,
  }
}