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

using WebExtras.Component;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   <see cref="IHtmlComponent" /> extensions
  /// </summary>
  public static class IHtmlComponentExtension
  {
    /// <summary>
    ///   Converts current HTMl component to a <see cref="HtmlElement" />
    /// </summary>
    /// <param name="component">Component to convert</param>
    /// <returns>Converted element</returns>
    public static HtmlElement ToHtmlElement(this IHtmlComponent component)
    {
      return new HtmlElement(component);
    }
  }
}