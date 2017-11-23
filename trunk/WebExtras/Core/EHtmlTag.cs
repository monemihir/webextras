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

using System;

namespace WebExtras.Core
{
  /// <summary>
  ///   A collection of all HTML tags available
  /// </summary>
  [Serializable]
  public enum EHtmlTag
  {
    /// <summary>
    ///   A null HTML tag
    /// </summary>
    Empty,

    /// <summary>
    ///   HTML A tag
    /// </summary>
    A,

    /// <summary>
    ///   HTML I tag
    /// </summary>
    I,

    /// <summary>
    ///   HTML B tag
    /// </summary>
    B,

    /// <summary>
    ///   HTML IMG tag
    /// </summary>
    Img,

    /// <summary>
    ///   HTML BUTTON tag
    /// </summary>
    Button,

    /// <summary>
    ///   HTML INPUT tag
    /// </summary>
    Input,

    /// <summary>
    ///   HTML TEXTAREA tag
    /// </summary>
    TextArea,

    /// <summary>
    ///   HTML UL tag
    /// </summary>
    Ul,

    /// <summary>
    ///   HTML OL tag
    /// </summary>
    Ol,

    /// <summary>
    ///   HTML LIST ITEM tag
    /// </summary>
    Li,

    /// <summary>
    ///   HTML DIV tag
    /// </summary>
    Div,

    /// <summary>
    ///   HTML SPAN tag
    /// </summary>
    Span,

    /// <summary>
    ///   HTML LABEL tag
    /// </summary>
    Label,

    /// <summary>
    ///   HTML SELECT tag
    /// </summary>
    Select,

    /// <summary>
    ///   HTML OPTION tag
    /// </summary>
    Option,

    /// <summary>
    ///   HTML SCRIPT tag
    /// </summary>
    Script,

    /// <summary>
    /// HTML P tag
    /// </summary>
    P
  }
}