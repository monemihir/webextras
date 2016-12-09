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

using SquishIt.Framework.CSS;
using SquishIt.Framework.JavaScript;

namespace WebExtras.Documentation.Models.Helpers
{
  /// <summary>
  ///   <see cref="SquishIt.Framework.Bundle" /> extensions
  /// </summary>
  public static class SquishItExtensions
  {
    /// <summary>
    ///   Save current CSS bundle as a cached resource on server
    /// </summary>
    /// <param name="cssBundle">Current CSS bundle</param>
    /// <param name="name">Name with which to store current bundle</param>
    /// <returns>Cached bundle access HTML tag</returns>
    public static string AsCached(this CSSBundle cssBundle, ContentBundle name)
    {
      return cssBundle.AsCached(name.ToString(), "~/assets/css/" + name);
    }

    /// <summary>
    ///   Save current JavaScript bundle as a cached resource on server
    /// </summary>
    /// <param name="jsBundle">Current JavaScript bundle</param>
    /// <param name="name">Name with which to store current bundle</param>
    /// <returns>Cached bundle access HTML tag</returns>
    public static string AsCached(this JavaScriptBundle jsBundle, ContentBundle name)
    {
      return jsBundle.AsCached(name.ToString(), "~/assets/js/" + name);
    }
  }
}