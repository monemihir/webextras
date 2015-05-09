// 
// This file is part of - WebExtras
// Copyright (C) 2015 Mihir Mone
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

using System;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   A list of WebExtras constants
  /// </summary>
  [Serializable]
  public sealed class WebExtrasMvcConstants
  {
    /// <summary>
    ///   Flag indicating whether to enable the generation of
    ///   automatic IDs for all HTML elements rendered by
    ///   the WebExtras.Mvc library
    /// </summary>
    public static bool EnableAutoIdGeneration { get; set; }

    /// <summary>
    ///   The version of Bootstrap whose extensions you want to use
    /// </summary>
    public static EBootstrapVersion BootstrapVersion = EBootstrapVersion.None;

    /// <summary>
    ///   Gumby theme to use
    /// </summary>
    public static EGumbyTheme GumbyTheme = EGumbyTheme.None;

    /// <summary>
    ///   The version of the FontAwesome icon library you want to use
    /// </summary>
    public static EFontAwesomeVersion FontAwesomeVersion = EFontAwesomeVersion.None;

    /// <summary>
    ///   The CSS framework you want to use
    /// </summary>
    public static ECssFramework CssFramework = ECssFramework.None;

    /// <summary>
    ///   Represents an HTML SPACE as unicode
    /// </summary>
    public static string HTMLSpace = "&nbsp;";

    /// <summary>
    ///   The default tag to use when encapsulating text in an HTML tag
    /// </summary>
    public static EHtmlTag DefaultTagForTextEncapsulation = EHtmlTag.Div;

    /// <summary>
    /// Default datetime picker options for bootstrap
    /// </summary>
    public static Bootstrap.DateTimePicker.PickerOptions BootstrapDateTimePickerOptions = new Bootstrap.DateTimePicker.PickerOptions();
  }
}