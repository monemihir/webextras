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
using System.Collections.Generic;
using System.Linq;
using WebExtras.Core;

namespace WebExtras.Html
{
  /// <summary>
  ///   HTML Select tag
  /// </summary>
  [Serializable]
  public class SelectComponent : HtmlComponent
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public SelectComponent(object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="options">List of options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public SelectComponent(string[] options, object htmlAttributes = null)
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
    public SelectComponent(IEnumerable<SelectListOption> options, object htmlAttributes = null)
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