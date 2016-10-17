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

using WebExtras.Core;

namespace WebExtras.FontAwesome
{
  /// <summary>
  ///   FontAwesome large icon CSS class value decider based on
  ///   the FontAwesome library version
  /// </summary>
  internal class FontAwesomeLargeIconStringValueDecider : IStringValueDecider<EFontAwesomeIconSize>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EFontAwesomeIconSize> args)
    {
      string css;

      switch (WebExtrasSettings.FontAwesomeVersion)
      {
        case EFontAwesomeVersion.None:
          throw new FontAwesomeVersionException();
        case EFontAwesomeVersion.V3:
          css = "large";
          break;
        default:
          css = "lg";
          break;
      }

      return css;
    }
  }

  /// <summary>
  ///   FontAwesome large icon CSS class value decider based on
  ///   the FontAwesome library version
  /// </summary>
  internal class FontAwesomeIconStringValueDecider : IStringValueDecider<EFontAwesomeIcon>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EFontAwesomeIcon> args)
    {
      string css;

      switch (WebExtrasSettings.FontAwesomeVersion)
      {
        case EFontAwesomeVersion.None:
          throw new FontAwesomeVersionException();
        case EFontAwesomeVersion.V3:
          css = "icon-" + args.Value;
          break;
        default:
          css = "fa-" + args.Value;
          break;
      }

      css = css.Replace("_", "-").ToLowerInvariant();

      return css;
    }
  }
}