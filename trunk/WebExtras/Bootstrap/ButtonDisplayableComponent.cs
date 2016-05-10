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
using WebExtras.Core;
using WebExtras.Html;

namespace WebExtras.Bootstrap
{
  /// <summary>
  ///   A component that can be displayed as a button
  /// </summary>
  public class ButtonDisplayableComponent : HtmlComponent, IButtonDisplayableComponent
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="tag">The HTML tag to initialise with</param>
    public ButtonDisplayableComponent(EHtmlTag tag) : base(tag)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Constructor to specify extra HTML attributes as an anonymous type
    /// </summary>
    /// <param name="tag">An HTML tag to initialise this element with</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public ButtonDisplayableComponent(EHtmlTag tag, object htmlAttributes) : base(tag, htmlAttributes)
    {
      // nothing to do here
    }

    /// <summary>
    ///   Add a bootstrap icon
    /// </summary>
    /// <param name="icon">Icon to add</param>
    /// <param name="append">[Optional] Whether to append the icon. Defaults to false</param>
    /// <returns>Updated button component</returns>
    public IButtonDisplayableComponent AddIcon(EBootstrapIcon icon, bool append = false)
    {
      HtmlComponent i = new HtmlComponent(EHtmlTag.I);
      i.CssClasses.Add(icon.GetStringValue());

      if (append)
        AppendTags.Add(i);
      else
        PrependTags.Add(i);

      return this;
    }

    /// <summary>
    ///   Add a FontAwesome icon
    /// </summary>
    /// <param name="icon">Icon to add</param>
    /// <param name="size">Icon size</param>
    /// <param name="append">[Optional] Whether to append the icon. Defaults to false</param>
    /// <returns>Updated button component</returns>
    public IButtonDisplayableComponent AddIcon(EFontAwesomeIcon icon,
      EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, bool append = false)
    {
      throw new NotImplementedException();
    }
  }
}