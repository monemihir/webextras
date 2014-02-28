/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
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

using WebExtras.Core;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// Success message string value decider
  /// </summary>
  internal class MessageSuccessStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.None && WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new NoCssThemeException();

      string css = string.Empty;

      if (WebExtrasMvcConstants.GumbyTheme != EGumbyTheme.None)
        css += "success";

      if (WebExtrasMvcConstants.BootstrapVersion != EBootstrapVersion.None)
        css += " alert-success";

      return css;
    }
  }

  /// <summary>
  /// Error message string value decider
  /// </summary>
  internal class MessageErrorStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.None && WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new NoCssThemeException();

      string css = string.Empty;

      if (WebExtrasMvcConstants.GumbyTheme != EGumbyTheme.None)
        css += " danger";

      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.V2)
        css += " alert-error";

      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.V3)
        css += " alert-danger";

      return css;
    }
  }

  /// <summary>
  /// Warning message string value decider
  /// </summary>
  internal class MessageWarningStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.None && WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new NoCssThemeException();

      string css = string.Empty;

      if (WebExtrasMvcConstants.GumbyTheme != EGumbyTheme.None)
        css += " warning";

      if (WebExtrasMvcConstants.BootstrapVersion != EBootstrapVersion.None)
        css += " alert-warning";

      return css;
    }
  }

  /// <summary>
  /// Warning message string value decider
  /// </summary>
  internal class MessageInfoStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      if (WebExtrasMvcConstants.BootstrapVersion == EBootstrapVersion.None && WebExtrasMvcConstants.GumbyTheme == EGumbyTheme.None)
        throw new NoCssThemeException();

      string css = string.Empty;

      if (WebExtrasMvcConstants.GumbyTheme != EGumbyTheme.None)
        css += " info";

      if (WebExtrasMvcConstants.BootstrapVersion != EBootstrapVersion.None)
        css += " alert-info";

      return css;
    }
  }
}
