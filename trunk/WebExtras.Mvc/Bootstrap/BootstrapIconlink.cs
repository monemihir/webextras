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

using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Html;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   A bootstrap icon only hyperlink
  /// </summary>
  public class BootstrapIconlink : Hyperlink
  {
    private IHtmlComponent m_icon;

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="icon">Icon to be displayed as the hypelink</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional Extra HTML attributes</param>
    public BootstrapIconlink(EBootstrapIcon icon, string url, object htmlAttributes = null) :
      base(string.Empty, url, htmlAttributes)
    {
      CssClasses.Add("icon-only-link");
      IHtmlComponent iconElement = BootstrapUtil.CreateIcon(icon);

      PrependTags.Add(iconElement);
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="icon">Icon to be displayed as the hypelink</param>
    /// <param name="url">Link URL</param>
    /// <param name="htmlAttributes">[Optional Extra HTML attributes</param>
    public BootstrapIconlink(EFontAwesomeIcon icon, string url, object htmlAttributes = null) :
      base(string.Empty, url, htmlAttributes)
    {
      CssClasses.Add("icon-only-link");
      m_icon = BootstrapUtil.CreateIcon(icon);

      PrependTags.Add(m_icon);
    }

    /// <summary>
    ///   Set the icon size
    /// </summary>
    /// <param name="size">Icon size to set</param>
    /// <returns>Updated link</returns>
    public BootstrapIconlink SetIconSize(EFontAwesomeIconSize size)
    {
      m_icon.CssClasses.Add("fa-" + size.GetStringValue());

      return this;
    }
  }
}