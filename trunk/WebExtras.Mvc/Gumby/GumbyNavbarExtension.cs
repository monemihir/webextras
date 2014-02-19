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

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  /// Gumby navbar extensions
  /// </summary>
  public static class GumbyNavbarExtension
  {
    /// <summary>
    /// Create a 'Metro' styled navbar
    /// </summary>
    /// <param name="navbar">Current navbar</param>
    /// <returns>A 'Metro' Gumby navbar</returns>
    public static GumbyNavbar AsMetro(this GumbyNavbar navbar)
    {
      navbar.CSSClasses.Add(navbar["class"]);
      navbar.Attributes.Remove("class");

      navbar.CSSClasses.Remove("pretty");
      navbar.CSSClasses.Add("metro");

      return navbar;
    }

    /// <summary>
    /// Create a 'Pretty' styled navbar
    /// </summary>
    /// <param name="navbar">Current navbar</param>
    /// <returns>A 'Pretty' Gumby navbar</returns>
    public static GumbyNavbar AsPretty(this GumbyNavbar navbar)
    {
      navbar.CSSClasses.Add(navbar["class"]);
      navbar.Attributes.Remove("class");

      navbar.CSSClasses.Remove("metro");
      navbar.CSSClasses.Add("pretty");

      return navbar;
    }

    /// <summary>
    /// Fix the navbar at the specified location and offset
    /// </summary>
    /// <param name="navbar">Current navbar</param>
    /// <param name="location">The position at which to fix the navbar. Can be either 'top', 
    /// 'bottom' or a value in pixels for e.g. '200'</param>
    /// <param name="offset">[Optional] An offset from the fixed location in pixels. 
    /// For e.g. '200'. Defaults to no offset</param>
    /// <returns>A fixed navbar</returns>
    public static GumbyNavbar FixAt(this GumbyNavbar navbar, string location, string offset = "")
    {
      navbar["gumby-fixed"] = location;

      if (!string.IsNullOrEmpty(offset))
        navbar["gumby-offset"] = offset;

      return navbar;
    }

    /// <summary>
    /// Pin the navbar at the specified location and offset
    /// </summary>
    /// <param name="navbar">Current navbar</param>
    /// <param name="location">The position at which to pin the navbar. Can be an HTML ID 
    /// specification like '#some-element' or a value in pixels like '200'</param>
    /// <param name="offset">[Optional] An offset from the pinned location in pixels.
    /// For e.g. '200'. Defaults to no offset</param>
    /// <returns>A pinned navbar</returns>
    public static GumbyNavbar PinAt(this GumbyNavbar navbar, string location, string offset = "")
    {
      navbar["gumby-pin"] = location;

      if (!string.IsNullOrEmpty(offset))
        navbar["gumby-pinoffset"] = offset;

      return navbar;
    }
  }
}
