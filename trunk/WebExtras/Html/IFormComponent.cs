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

namespace WebExtras.Html
{
  /// <summary>
  ///   Generic interface implemented by form control elements
  /// </summary>
  /// <typeparam name="TModel">Type to be scanned</typeparam>
  /// <typeparam name="TValue">Property to be scanned</typeparam>
  public interface IFormComponent<TModel, TValue>
  {
    /// <summary>
    ///   Add text addon to the form control
    /// </summary>
    /// <param name="text">Text to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddText(string text, bool append = true);

    /// <summary>
    ///   Add icon addon to the form control
    /// </summary>
    /// <param name="icon">Icon to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddIcon(EFontAwesomeIcon icon, bool append = true);

    /// <summary>
    ///   Add html addon to the form control
    /// </summary>
    /// <param name="html">HTML to be added</param>
    /// <param name="append">[Optional] Whether to append or prepend the addon</param>
    /// <returns>The updated form control</returns>
    IFormComponent<TModel, TValue> AddHtml(IHtmlComponent html, bool append = true);

    /// <summary>
    ///   Converts current HTML component as a string
    /// </summary>
    /// <returns>Current HTML component as a string</returns>
    string ToHtml();
  }
}