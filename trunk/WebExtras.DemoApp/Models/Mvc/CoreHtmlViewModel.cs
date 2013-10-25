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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebExtras.DemoApp.Models.Mvc
{
  /// <summary>
  /// Basic HTML view model
  /// </summary>
  public class CoreHtmlViewModel
  {
    /// <summary>
    /// Some required property
    /// </summary>
    [Required]
    public string SomeProperty { get; set; }

    /// <summary>
    /// Some other property which has a description
    /// </summary>
    [Description("This is the second property")]
    public string SomeProperty2 { get; set; }

    /// <summary>
    /// Flag indicating whether to show the action message or not
    /// </summary>
    public bool ShowMessage { get; set; }
  }
}