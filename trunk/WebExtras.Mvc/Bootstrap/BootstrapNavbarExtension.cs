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


namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap navigation bar extensions
  /// </summary>
  public static class BootstrapNavbarExtension
  {
    /// <summary>
    /// Create an inverse bootstrap navigation bar
    /// </summary>
    /// <param name="navbar">Bootstrap navigation bar to convert</param>
    /// <returns>An inverse bootstrap navigation bar</returns>
    public static BootstrapNavBar AsInverse(this BootstrapNavBar navbar)
    {
      navbar.CSSClasses.Add("navbar-inverse");

      return navbar;
    }
  }
}
