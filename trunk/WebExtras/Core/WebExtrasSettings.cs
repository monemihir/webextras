// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Newtonsoft.Json;
using WebExtras.Bootstrap;
using WebExtras.FontAwesome;
using WebExtras.Gumby;
using WebExtras.JQDataTables;

namespace WebExtras.Core
{
  /// <summary>
  ///   WebExtras library constants
  /// </summary>
  public static class WebExtrasSettings
  {
    /// <summary>
    ///   Global jQuery dataTables pagination scheme. Defaults to EPagination.Bootstrap
    /// </summary>
    public static EPagination DatatablesPaginationScheme = EPagination.Bootstrap;

    /// <summary>
    ///   Json.NET data serialization settings
    /// </summary>
    public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
    {
      Formatting = Formatting.Indented,
      NullValueHandling = NullValueHandling.Ignore
    };

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
    ///   The default behavior for rendering a form control
    /// </summary>
    public static EFormControlBehavior FormControlBehavior = EFormControlBehavior.Default;

    /// <summary>
    ///   Setup a string value decider for an enum
    /// </summary>
    /// <typeparam name="T">Type of enum</typeparam>
    /// <param name="decider">The string value decider</param>
    public static void AddStringValueDecider<T>(IStringValueDecider<T> decider) where T : struct, IConvertible
    {
      Type type = typeof(T);

      if (!type.IsEnum)
        throw new InvalidUsageException("AddStringValueDecider<> can only be invoked on enum types");

      if (EnumExtentions.ExternalStringValueDecidersLookup.ContainsKey(type))
        throw new InvalidOperationException("A custom string value decider has already been defined for: " +
                                            type.FullName);

      EnumExtentions.ExternalStringValueDecidersLookup[type] = decider.GetType();
    }
  }
}