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

using WebExtras.Bootstrap;
using WebExtras.Gumby;

namespace WebExtras.Core
{
  /// <summary>
  ///   Success message string value decider
  /// </summary>
  internal class MessageSuccessStringValue : IStringValueDecider<EMessage>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EMessage> args)
    {
      string css = string.Empty;

      switch (WebExtrasSettings.CssFramework)
      {
        case ECssFramework.Bootstrap:
          if (WebExtrasSettings.BootstrapVersion == EBootstrapVersion.None)
            throw new NoCssThemeException();
          css += " alert-success";
          break;

        case ECssFramework.Gumby:
          if (WebExtrasSettings.GumbyTheme == EGumbyTheme.None)
            throw new NoCssThemeException();
          css += " success";
          break;

        case ECssFramework.JQueryUI:
          css += " ui-alert-success";
          break;

        default:
          throw new NoCssFrameworkException();
      }

      return css;
    }
  }

  /// <summary>
  ///   Error message string value decider
  /// </summary>
  internal class MessageErrorStringValue : IStringValueDecider<EMessage>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EMessage> args)
    {
      string css = string.Empty;

      switch (WebExtrasSettings.CssFramework)
      {
        case ECssFramework.Bootstrap:
          if (WebExtrasSettings.BootstrapVersion == EBootstrapVersion.None)
            throw new NoCssThemeException();

          if (WebExtrasSettings.BootstrapVersion == EBootstrapVersion.V2)
            css += " alert-error";
          else
            css += " alert-danger";
          break;

        case ECssFramework.Gumby:
          if (WebExtrasSettings.GumbyTheme == EGumbyTheme.None)
            throw new NoCssThemeException();
          css += " danger";
          break;

        case ECssFramework.JQueryUI:
          css += " ui-alert-error";
          break;

        default:
          throw new NoCssFrameworkException();
      }

      return css;
    }
  }

  /// <summary>
  ///   Warning message string value decider
  /// </summary>
  internal class MessageWarningStringValue : IStringValueDecider<EMessage>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EMessage> args)
    {
      string css = string.Empty;

      switch (WebExtrasSettings.CssFramework)
      {
        case ECssFramework.Bootstrap:
          if (WebExtrasSettings.BootstrapVersion == EBootstrapVersion.None)
            throw new NoCssThemeException();
          css += " alert-warning";
          break;

        case ECssFramework.Gumby:
          if (WebExtrasSettings.GumbyTheme == EGumbyTheme.None)
            throw new NoCssThemeException();
          css += " warning";
          break;

        case ECssFramework.JQueryUI:
          css += " ui-alert-highlight";
          break;

        default:
          throw new NoCssFrameworkException();
      }

      return css;
    }
  }

  /// <summary>
  ///   Warning message string value decider
  /// </summary>
  internal class MessageInfoStringValue : IStringValueDecider<EMessage>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EMessage> args)
    {
      string css = string.Empty;

      switch (WebExtrasSettings.CssFramework)
      {
        case ECssFramework.Bootstrap:
          if (WebExtrasSettings.BootstrapVersion == EBootstrapVersion.None)
            throw new NoCssThemeException();
          css += " alert-info";
          break;

        case ECssFramework.Gumby:
          if (WebExtrasSettings.GumbyTheme == EGumbyTheme.None)
            throw new NoCssThemeException();
          css += " info";
          break;

        case ECssFramework.JQueryUI:
          css += " ui-alert-info";
          break;

        default:
          throw new NoCssFrameworkException();
      }

      return css;
    }
  }
}