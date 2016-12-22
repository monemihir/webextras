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

using System.Web.Mvc;
using System.Web.Routing;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   Utility methods
  /// </summary>
  public static class WebExtrasMvcUtilT4
  {
    /// <summary>
    ///   Get the url from given action result
    /// </summary>
    /// <param name="html">Current HTML helper instance</param>
    /// <param name="result">Action to be parsed</param>
    /// <returns>The URL the action points to</returns>
    public static string GetUrl(HtmlHelper html, ActionResult result)
    {
      UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);

      RouteValueDictionary rvd = result.GetRouteValueDictionary();
      string link = urlHelper.RouteUrl(rvd);

      return link;
    }
  }
}