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

using WebExtras.Core;

namespace WebExtras.Bootstrap
{
  /// <summary>
  ///   FontAwesome large icon CSS class value decider based on
  ///   the FontAwesome library version
  /// </summary>
  internal class FontAwesomeLargeIconStringValue : IStringValueDecider<EFontAwesomeIconSize>
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

      switch (WebExtrasConstants.FontAwesomeVersion)
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
  /// The string value decider for a bootstrap button
  /// </summary>
  internal class BootstrapButtonStringValueDecider : IStringValueDecider<EBootstrapButton>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EBootstrapButton> args)
    {
      if (WebExtrasConstants.BootstrapVersion == EBootstrapVersion.None)
        throw new BootstrapVersionException();

      string iconName = "btn-" + args.Value.ToString().ToLowerInvariant();

      if (WebExtrasConstants.BootstrapVersion == EBootstrapVersion.V3 &&
        args.Value == EBootstrapButton.Large)
        iconName = "btn-lg";

      if (WebExtrasConstants.BootstrapVersion == EBootstrapVersion.V3 &&
        args.Value == EBootstrapButton.Small)
        iconName = "btn-sm";

      string value = "btn " + iconName;

      return value;
    }
  }

  /// <summary>
  /// The string value decider for a bootstrap icon
  /// </summary>
  internal class BootstrapIconStringValueDecider : IStringValueDecider<EBootstrapIcon>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   [Optional] Sender object that can contain extra data
    ///   which can then be used to decide the value
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EBootstrapIcon> args)
    {
      string iconName = args.Value.ToString().ToLowerInvariant().Replace("_", "-");

      string value;
      switch (WebExtrasConstants.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          value = "icon-" + iconName;
          break;
        case EBootstrapVersion.V3:
          value = "glyphicon glyphicon-" + iconName;
          break;
        default:
          throw new BootstrapVersionException();
      }

      return value;
    }
  }
}