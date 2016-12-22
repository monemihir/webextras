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
using WebExtras.Core;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   A class to store and retrieve messages for display after an action has occurred
  ///   Provides ControllerBase and HtmlHelper extensions
  /// </summary>
  public static class ActionMessageControllerExtensionT4
  {
    /// <summary>
    ///   Overload of the RedirectToAction method, which allows the saving of an action message
    ///   before the redirect is executed
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="result">The redirect result to execute</param>
    /// <param name="message">The action message to display</param>
    /// <param name="type">Action message type</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>A RedirectToRouteResult result</returns>
    public static RedirectToRouteResult RedirectToAction(this ControllerBase c, ActionResult result, string message,
      EMessage type = EMessage.Success, params object[] args)
    {
      c.SaveLastActionMessage(message, type, args);

      var callInfo = result.GetT4MVCResult();
      return new RedirectToRouteResult(null, callInfo.RouteValueDictionary);
    }
  }
}