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

#pragma warning disable 1591

using System;
using WebExtras.Core;

namespace WebExtras.Bootstrap
{
  /// <summary>
  ///   A collection of button display types
  /// </summary>
  [Serializable]
  [StringValue(typeof(BootstrapButtonStringValueDecider))]
  public enum EBootstrapButton
  {
    Default,
    Primary,
    Success,
    Info,
    Warning,

    /// <summary>
    ///   Only available in Bootstrap 2.x
    /// </summary>
    Inverse,

    Danger,
    Large,

    /// <summary>
    ///   Only available in Bootstrap 2.x
    /// </summary>
    Block,

    /// <summary>
    ///   Only available in Bootstrap 2.x
    /// </summary>
    Mini,

    Small,

    /// <summary>
    ///   Only available in Bootstrap 3.x
    /// </summary>
    [StringValue("btn-xs")]
    XSmall,

    /// <summary>
    ///   Only available in Bootstrap 3.x
    /// </summary>
    Link
  }
}