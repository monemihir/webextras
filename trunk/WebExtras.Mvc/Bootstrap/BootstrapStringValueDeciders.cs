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

using WebExtras.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// FontAwesome large icon CSS class value decider based on 
  /// the FontAwesome library version
  /// </summary>
  public sealed class FontAwesomeLargeIconStringValue : IStringValueDecider
  {
    /// <summary>
    /// The string value decider function
    /// </summary>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide()
    {
      string css = string.Empty;

      switch (WebExtrasMvcConstants.FontAwesomeVersion)
      {
        case EFontAwesomeVersion.None:
          throw new FontAwesomeVersionException();

        case EFontAwesomeVersion.V3:
          css = "large";
          break;

        case EFontAwesomeVersion.V4:
          css = "lg";
          break;
      }

      return css;
    }
  }
}
