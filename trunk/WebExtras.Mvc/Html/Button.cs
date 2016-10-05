// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
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
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Represents a HTML BUTTON element
  /// </summary>
  [Serializable]
  public class Button : HtmlElement
  {
    /// <summary>
    ///   Button onclick event
    /// </summary>
    public string OnClick { get { return this["onclick"]; } set { this["onclick"] = value; } }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Button(EButton type, string text, object htmlAttributes = null)
      : this(type, text, string.Empty, null)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="onclick">Javascript onclick event of the button</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Button(EButton type, string text, string onclick, object htmlAttributes = null)
      : this(type, text, onclick, false, htmlAttributes)
    {
      // Nothing to do here
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Button type</param>
    /// <param name="text">Button text</param>
    /// <param name="onclick">Javascript onclick event of the button</param>
    /// <param name="isNavigation">Whether the onclick specified is url navigation</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Button(EButton type, string text, string onclick, bool isNavigation, object htmlAttributes = null)
      : base(EHtmlTag.Button, htmlAttributes)
    {
      InnerHtml = text;
      this["type"] = type.GetStringValue();

      if (type == EButton.Cancel || type == EButton.Back)
      {
        OnClick = "javascript:window.history.back()";
        return;
      }

      if (string.IsNullOrWhiteSpace(onclick))
        return;

      if (isNavigation)
        OnClick = "window.location='" + onclick + "'";
      else
        OnClick = "javascript:" + onclick;
    }
  }
}