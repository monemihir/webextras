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
using System.Collections.Generic;
using System.Linq;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   HTML Select tag
  /// </summary>
  [Serializable]
  public class HtmlSelect : HtmlComponent
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlSelect(object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="options">List of options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlSelect(string[] options, object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      Array.ForEach(options, f =>
      {
        var option = new HtmlComponent(EHtmlTag.Option, new {value = f})
        {
          InnerHtml = f
        };
        AppendTags.Add(option);
      });
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="options">List of options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public HtmlSelect(IEnumerable<HtmlSelectListOption> options, object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      Array.ForEach(options.ToArray(), f =>
      {
        var option = new HtmlComponent(EHtmlTag.Option, new {value = f.Value})
        {
          InnerHtml = f.Text
        };

        if (f.Selected)
          option.Attributes["selected"] = "true";

        AppendTags.Add(option);
      });
    }
  }
}