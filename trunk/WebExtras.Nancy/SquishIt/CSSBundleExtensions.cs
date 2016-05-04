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
using SquishIt.Framework.CSS;

namespace WebExtras.Nancy.SquishIt
{
  /// <summary>
  ///   <see cref="CSSBundle" /> extensions
  /// </summary>
  public static class CSSBundleExtensions
  {
    /// <summary>
    /// Renders current <see cref="CSSBundle"/> to given file
    /// </summary>
    /// <param name="cssBundle">Current CSS bundle</param>
    /// <param name="renderTo">File to render to</param>
    /// <returns>Current bundle</returns>
    public static IHtmlString NancyRender(this CSSBundle cssBundle, string renderTo)
    {
      return new EncodedHtmlString(cssBundle.Render(renderTo));
    }

    /// <summary>
    ///   Renders current <see cref="CSSBundle" /> as a named tag
    /// </summary>
    /// <param name="cssBundle">Current CSS bundle</param>
    /// <param name="name">CSS bundle name</param>
    /// <returns>Current bundle</returns>
    public static IHtmlString NancyRenderNamed(this CSSBundle cssBundle, string name)
    {
      return new EncodedHtmlString(cssBundle.RenderNamed(name));
    }

    /// <summary>
    ///   Render current <see cref="CSSBundle" /> as a cached asset tag
    /// </summary>
    /// <param name="cssBundle">Current CSS bundle</param>
    /// <param name="name">CSS bundle name</param>
    /// <returns>Current bundle as a cached asset tag</returns>
    public static IHtmlString NancyRenderCachedAssetTag(this CSSBundle cssBundle, string name)
    {
      return new EncodedHtmlString(cssBundle.RenderCachedAssetTag(name));
    }
  }
}