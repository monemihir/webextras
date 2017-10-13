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

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   Generic extension for an extended html string
  /// </summary>
  public static class ExtendedHtmlStringExtension
  {
    /// <summary>
    ///   Adds given CSS class(es) to the current HTML element
    /// </summary>
    /// <param name="html">HTML element to add class to</param>
    /// <param name="css">CSS class(es) to be added</param>
    /// <returns>Current HTML element with classes added</returns>
    public static T AddCssClass<T>(this T html, string css) where T : IExtendedHtmlString
    {
      if (!string.IsNullOrWhiteSpace(css))
        html.Component.CssClasses.AddRange(css.Trim().Split(' '));

      return html;
    }

    /// <summary>
    ///   Set an attribute value
    /// </summary>
    /// <param name="html">HTML element to add class to</param>
    /// <param name="name">Attribute name</param>
    /// <param name="value">Attribute value</param>
    /// <param name="overwrite">[Optional] Whether to overwrite an existing value. Defaults to false</param>
    /// <returns>Updated element</returns>
    public static T SetAttribute<T>(this T html, string name, string value, bool overwrite = false)
      where T : IExtendedHtmlStringLegacy
    {
      if (overwrite)
        html.Attributes[name] = value;
      else if (!html.Attributes.ContainsKey(name))
        html.Attributes[name] = value;

      return html;
    }
  }
}