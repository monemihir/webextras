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
using SquishIt.Framework.JavaScript;

namespace WebExtras.Nancy.SquishIt
{
  /// <summary>
  ///   <see cref="JavaScriptBundle" /> extensions
  /// </summary>
  public static class JavaScriptBundleExtensions
  {
    /// <summary>
    ///   Renders current <see cref="JavaScriptBundle" /> to given file
    /// </summary>
    /// <param name="javaScriptBundle">Current javascript bundle</param>
    /// <param name="renderTo">File to render to</param>
    /// <returns>Current bundle</returns>
    public static IHtmlString MvcRender(this JavaScriptBundle javaScriptBundle, string renderTo)
    {
      return new EncodedHtmlString(javaScriptBundle.Render(renderTo));
    }

    /// <summary>
    ///   Renders current <see cref="JavaScriptBundle" /> as a named tag
    /// </summary>
    /// <param name="javaScriptBundle">Current javascript bundle</param>
    /// <param name="name">javascript bundle name</param>
    /// <returns>Current bundle</returns>
    public static IHtmlString MvcRenderNamed(this JavaScriptBundle javaScriptBundle, string name)
    {
      return new EncodedHtmlString(javaScriptBundle.RenderNamed(name));
    }

    /// <summary>
    ///   Render current <see cref="JavaScriptBundle" /> as a cached asset tag
    /// </summary>
    /// <param name="javaScriptBundle">Current javascript bundle</param>
    /// <param name="name">javascript bundle name</param>
    /// <returns>Current bundle as a cached asset tag</returns>
    public static IHtmlString MvcRenderCachedAssetTag(this JavaScriptBundle javaScriptBundle, string name)
    {
      return new EncodedHtmlString(javaScriptBundle.RenderCachedAssetTag(name));
    }
  }
}