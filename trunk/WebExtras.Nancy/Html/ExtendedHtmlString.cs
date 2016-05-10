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

using Nancy.ViewEngines.Razor;
using WebExtras.Html;

namespace WebExtras.Nancy.Html
{
  /// <summary>
  ///   Default implementation of <see cref="IExtendedHtmlString" />
  /// </summary>
  public class ExtendedHtmlString : IExtendedHtmlString
  {
    /// <summary>
    ///   Empty HTML string
    /// </summary>
    public static IExtendedHtmlString Empty { get { return new ExtendedHtmlString(HtmlComponent.Empty); } }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="component">A HTML component to initialise with</param>
    public ExtendedHtmlString(IHtmlComponent component)
    {
      Component = component;
    }

    #region Implementation of IExtendedHtmlString 

    /// <summary>
    ///   Underlying HTML component
    /// </summary>
    public IHtmlComponent Component { get; private set; }

    /// <summary>Returns an HTML-encoded string.</summary>
    /// <returns>An HTML-encoded string.</returns>
    public string ToHtmlString()
    {
      string html = Component.ToHtml();

      return new NonEncodedHtmlString(html).ToHtmlString();
    }

    #endregion Implementation of IExtendedHtmlString 
  }
}