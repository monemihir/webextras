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

namespace WebExtras.Html
{
  /// <summary>
  ///   Denotes a HTML select list option
  /// </summary>
  [Serializable]
  public class SelectListOption
  {
    /// <summary>
    ///   Display text
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///   Option value
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    ///   Whether this select list option is selected
    /// </summary>
    public bool Selected { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    public SelectListOption()
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Display text</param>
    /// <param name="value">Option value</param>
    /// <param name="selected">[Optional] Whether this option is selected</param>
    public SelectListOption(string text, string value, bool selected = false)
    {
      Text = text;
      Value = value;
      Selected = selected;
    }
  }
}