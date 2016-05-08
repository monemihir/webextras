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

using System.Collections.Generic;
using WebExtras.Core;

namespace WebExtras.Component
{
  /// <summary>
  ///   Represents an <see cref="IHtmlComponent" /> collection
  /// </summary>
  public class HtmlComponentList : List<IHtmlComponent>
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    public HtmlComponentList()
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="components">A collection of components to initialise with</param>
    public HtmlComponentList(IEnumerable<IHtmlComponent> components)
    {
      AddRange(components);
    }

    /// <summary>
    ///   Add given text as a component
    /// </summary>
    /// <param name="text">Text to add</param>
    public void Add(string text)
    {
      HtmlComponent c = new HtmlComponent(WebExtrasConstants.DefaultTagForTextEncapsulation)
      {
        InnerHtml = text
      };

      Add(c);
    }
  }
}