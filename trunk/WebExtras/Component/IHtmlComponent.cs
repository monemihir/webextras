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

using System.Collections.Generic;
using WebExtras.Core;

namespace WebExtras.Component
{
  /// <summary>
  ///   A generic interface implemented by HTML components
  /// </summary>
  public interface IHtmlComponent
  {
    /// <summary>
    ///   The HTML tag representing this component
    /// </summary>
    EHtmlTag Tag { get; }

    /// <summary>
    ///   CSS classes of this component
    /// </summary>
    CssClassList CssClasses { get; }

    /// <summary>
    ///   HTML attribute list for this component
    /// </summary>
    IDictionary<string, string> Attributes { get; }

    /// <summary>
    ///   Inner HTML of the component
    /// </summary>
    string InnerHtml { get; set; }

    /// <summary>
    ///   Tags to appended to the current component. Note these tags are
    ///   appended before the <see cref="InnerHtml" /> when the component
    ///   gets serialized to a HTML string
    /// </summary>
    HtmlComponentList PrependTags { get; }

    /// <summary>
    ///   Tags to appended to the current component. Note these tags are
    ///   appended after the <see cref="InnerHtml" /> when the component
    ///   gets serialized to a HTML string
    /// </summary>
    HtmlComponentList AppendTags { get; }

    /// <summary>
    ///   Converts current HTML component as a string
    /// </summary>
    /// <returns>Current HTML component as a string</returns>
    string ToHtml();
  }
}