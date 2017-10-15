// 
// This file is part of - WebExtras
// Copyright 2017 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace WebExtras.Html
{
  /// <summary>
  ///   Denotes a HTML select list option
  /// </summary>
  [Serializable]
  public class HtmlSelectListOption
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
    public HtmlSelectListOption()
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="text">Display text</param>
    /// <param name="value">Option value</param>
    /// <param name="selected">[Optional] Whether this option is selected</param>
    public HtmlSelectListOption(string text, string value, bool selected = false)
    {
      Text = text;
      Value = value;
      Selected = selected;
    }
  }
}