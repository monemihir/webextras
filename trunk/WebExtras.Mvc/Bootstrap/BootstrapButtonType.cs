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

#pragma warning disable 1591

using System;
using WebExtras.Core;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// A collection of button display types
  /// </summary>
  [Serializable]
  public enum BootstrapButtonType
  {
    [StringValue("btn")]
    Default,

    [StringValue("btn btn-primary")]
    Primary,

    [StringValue("btn btn-success")]
    Success,

    [StringValue("btn btn-info")]
    Info,

    [StringValue("btn btn-warning")]
    Warning,

    [StringValue("btn btn-inverse")]
    Inverse
  }
}
