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

using System.Web.Mvc;
using WebExtras.Gumby;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Gumby
{
  /// <summary>
  ///   Gumby HTML extensions
  /// </summary>
  public static class HtmlHelperExtensionT4
  {
    /// <summary>
    ///   Create a icon only link
    /// </summary>
    /// <param name="html">Current HTML helper object</param>
    /// <param name="icon">Icon to display</param>
    /// <param name="result">Link action</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    /// <returns>A icon only link</returns>
    public static IExtendedHtmlStringLegacy Hyperlink(this HtmlHelper html, EGumbyIcon icon, ActionResult result,
      object htmlAttributes = null)
    {
      string link = WebExtrasMvcUtilT4.GetUrl(html, result);

      return new GumbyIconLink(icon, link, htmlAttributes);
    }
  }
}