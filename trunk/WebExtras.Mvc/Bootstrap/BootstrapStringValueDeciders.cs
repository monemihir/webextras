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
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// FontAwesome large icon CSS class value decider based on 
  /// the FontAwesome library version
  /// </summary>
  internal class FontAwesomeLargeIconStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      string css;

      switch (WebExtrasMvcConstants.FontAwesomeVersion)
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
  /// Bootstrap large button CSS class value decider based on
  /// the Bootstrap version decider
  /// </summary>
  internal class BootstrapLargeButtonStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      string css;

      switch (WebExtrasMvcConstants.BootstrapVersion)
      {
        case EBootstrapVersion.None:
          throw new BootstrapVersionException();
        case EBootstrapVersion.V2:
          css = "btn-large";
          break;
        default:
          css = "btn-lg";
          break;
      }

      return css;
    }
  }

  /// <summary>
  /// Bootstrap small button CSS class value decider based on
  /// the Bootstrap version decider
  /// </summary>
  internal class BootstrapSmallButtonStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <param name="sender">[Optional] Sender object that can contain extra data
    /// which can then be used to decide the value</param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(object sender = null)
    {
      string css;

      switch (WebExtrasMvcConstants.BootstrapVersion)
      {
        case EBootstrapVersion.None:
          throw new BootstrapVersionException();
        case EBootstrapVersion.V2:
          css = "btn-small";
          break;
        default:
          css = "btn-sm";
          break;
      }

      return css;
    }
  }
}
