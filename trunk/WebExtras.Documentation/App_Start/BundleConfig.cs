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

using Links;
using SquishIt.Framework;
using WebExtras.Documentation.Models.Helpers;

namespace WebExtras.Documentation
{
  /// <summary>
  /// CSS and JS bundles
  /// </summary>
  public static class BundleConfig
  {
    /// <summary>
    /// Register all bundles
    /// </summary>
    public static void RegisterBundles()
    {
      Bundle.Css()
        .AddMinified(Content.css.materialize.materialize_min_css)
        .AddMinified(Content.css.style_min_css)
        .AsCached(ContentBundle.CssMain);

      Bundle.JavaScript()
        .AddMinified(Scripts.jquery_3_1_1_slim_min_js)
        .Add(Scripts.modernizr_2_8_3_js)
        .AddMinified(Scripts.materialize.materialize_min_js)
        .AsCached(ContentBundle.JsMain);
    }
  }
}