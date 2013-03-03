/*
* This file is part of - Code Library
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

namespace WebExtras.Html
{
  /// <summary>
  /// This class represents a CheckBox
  /// </summary>
  public class CheckBox
  {
    /// <summary>
    /// Value for check box
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Text to be displayed for the check box
    /// </summary>
    public string DisplayText { get; private set; }

    /// <summary>
    /// Flag indicating whether the check box is checked
    /// </summary>
    public bool IsChecked { get; private set; }

    /// <summary>
    /// Flag indicating whether the check box is enabled
    /// </summary>
    public bool IsEnabled { get; private set; }

    /// <summary>
    /// Constructor to create a CheckBox with given parameters
    /// </summary>
    /// <param name="value">Value for check box</param>
    /// <param name="displayText">Text to be displayed for the check box</param>
    /// <param name="isChecked">[Optional] Flag indicating whether the check box is checked</param>
    /// <param name="isEnabled">[Optional] Flag indicating whether the check box is enabled</param>
    public CheckBox(string value, string displayText, bool isChecked = false, bool isEnabled = true)
    {
      Value = value;
      DisplayText = displayText;
      IsChecked = isChecked;
      IsEnabled = isEnabled;
    }
  }
}