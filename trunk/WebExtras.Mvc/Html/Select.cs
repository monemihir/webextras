// 
// This file is part of - ExpenseLogger application
// Copyright (C) 2015 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebExtras.Core;

namespace WebExtras.Mvc.Html
{
  /// <summary>
  ///   HTML Select tag
  /// </summary>
  public class Select : HtmlElement
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Select(object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="options">List of options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Select(string[] options, object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      Array.ForEach(options, f =>
      {
        var option = new HtmlElement(EHtmlTag.Option, new {value = f})
        {
          InnerHtml = f
        };
        Append(option);
      });
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="options">List of options</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public Select(IEnumerable<SelectListItem> options, object htmlAttributes = null)
      : base(EHtmlTag.Select, htmlAttributes)
    {
      if (options == null)
        throw new ArgumentNullException("options", "Select list options cannot be null");

      Array.ForEach(options.ToArray(), f =>
      {
        var option = new HtmlElement(EHtmlTag.Option, new {value = f.Value})
        {
          InnerHtml = f.Text
        };

        if (f.Selected)
          option["selected"] = "true";

        Append(option);
      });
    }
  }
}