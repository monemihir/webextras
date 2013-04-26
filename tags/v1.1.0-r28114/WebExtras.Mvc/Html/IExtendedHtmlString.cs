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

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  /// Base interface to be implemented by an HTML element
  /// </summary>
  public interface IExtendedHtmlString : IHtmlString
  {
    /// <summary>
    /// An MVC tag builder
    /// </summary>
    TagBuilder Tag { get; set; }

    /// <summary>
    /// Inner tags
    /// </summary>
    List<IExtendedHtmlString> AppendTags { get; }

    /// <summary>
    /// Inner HTML tags to be prepended
    /// </summary>
    List<IExtendedHtmlString> PrependTags { get; }

    /// <summary>
    /// Appends the given HTML element at the end of the current 
    /// element
    /// </summary>
    /// <param name="element">HTML element to be added</param>    
    void Append(IExtendedHtmlString element);

    /// <summary>
    /// Appends the given HTML elements at the end of the current 
    /// element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    void Append(IEnumerable<IExtendedHtmlString> elements);
    
    /// <summary>
    /// Prepends the given HTML element at the beginning of
    /// the current element
    /// </summary>
    /// <param name="element">HTML element to be added</param>
    void Prepend(IExtendedHtmlString element);

    /// <summary>
    /// Prepends the given HTML elements at the beginning of
    /// the current element
    /// </summary>
    /// <param name="elements">HTML elements to be added</param>
    void Prepend(IEnumerable<IExtendedHtmlString> elements);

    /// <summary>
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    string ToHtmlString(TagRenderMode renderMode);
  }
}
