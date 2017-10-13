// 
// This file is part of - WebExtras
// Copyright 2017 Mihir Mone
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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   A class to store and retrieve messages for display after an action has occurred
  ///   Provides ControllerBase and HtmlHelper extensions
  /// </summary>
  public static class ActionMessageControllerExtension
  {
    /// <summary>
    ///   The key used to store the message in the TempData object
    /// </summary>
    public const string TempDataMessageKey = "<WebExtras_LastActionMessage>";

    /// <summary>
    ///   The key used to store the message type i.e success/failure in the TempData object
    /// </summary>
    public const string TempDataMessageTypeKey = "<WebExtras_LastActionMessageType>";

    /// <summary>
    ///   The key used to store user alerts in the TempData object
    /// </summary>
    public const string UserAlertsKey = "<WebExtras_UserAlerts>";

    /// <summary>
    ///   Overload of the View method, which allows the saving of an action message
    ///   before the View is returned
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="viewName">The view name to show</param>
    /// <param name="model">Model data associated with the view</param>
    /// <param name="message">The action message to display</param>
    /// <param name="type">Action message type</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>a ViewResult result</returns>
    public static ViewResult View(this ControllerBase c, string viewName, object model, string message,
      EMessage type = EMessage.Success, params object[] args)
    {
      SaveLastActionMessage(c, message, type, args);

      c.ViewData.Model = model;
      return new ViewResult
      {
        ViewName = viewName,
        ViewData = c.ViewData,
        TempData = c.TempData
      };
    }

    /// <summary>
    ///   ControllerBase extension method to save a user alert to Controller.TempData session store
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="alert">The user alert to be saved</param>
    public static void SaveUserAlert(this ControllerBase c, Alert alert)
    {
      ICollection<Alert> store = c.TempData[UserAlertsKey] as ICollection<Alert>;

      if (store == null)
        c.TempData[UserAlertsKey] = (store = new List<Alert>());

      store.Add(alert);
    }

    /// <summary>
    ///   Get the stored user alerts
    /// </summary>
    /// <param name="html">Current HtmlHelper object</param>
    /// <param name="type">Alert message type</param>
    /// <returns>A collection of notifications</returns>
    public static IExtendedHtmlString[] GetUserAlerts(this HtmlHelper html, EMessage? type = null)
    {
      IEnumerable<Alert> store = html.ViewContext.Controller.TempData[UserAlertsKey] as ICollection<Alert> ??
                                 new Alert[0];

      if (type.HasValue)
        store = store.Where(f => f.Type == type);

      return store.Select(a => new ExtendedHtmlString(a)).ToArray<IExtendedHtmlString>();
    }

    /// <summary>
    ///   ControllerBase extension method to save the last action message to the Controller.TempData session store using the
    ///   key denoted by
    ///   'TempDataMessageKey' variable.
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="message">The action message to display</param>
    /// <param name="type">Action message type</param>
    /// <param name="args">Any message formatting arguments</param>
    public static void SaveLastActionMessage(this ControllerBase c, string message, EMessage type, params object[] args)
    {
      // store data in temp key, will be alive for one request only
      c.TempData[TempDataMessageKey] = string.Format(message, args);
      c.TempData[TempDataMessageTypeKey] = type;
    }

    /// <summary>
    ///   HtmlHelper extension method to save a message to the Controller.TempData session cache using the key:
    ///   TempDataMessageKey.
    ///   TempData is only alive for one request only before being wiped.
    /// </summary>
    /// <param name="helper">HtmlHelper</param>
    /// <returns>The last message if available in a div object</returns>
    public static MvcHtmlString GetLastActionMessage(this HtmlHelper helper)
    {
      if (!helper.ViewContext.TempData.ContainsKey(TempDataMessageKey))
        return MvcHtmlString.Empty;

      // get message
      string message = helper.ViewContext.TempData[TempDataMessageKey].ToString();
      EMessage type = (EMessage) helper.ViewContext.TempData[TempDataMessageTypeKey];
      const string controlId = "actionmessage";

      // create the dismiss button
      //<button type="button" class="close" data-dismiss="alert">&times;</button>
      TagBuilder dismissBtn = new TagBuilder("button");
      dismissBtn.AddCssClass("close");
      dismissBtn.Attributes["data-dismiss"] = "alert";
      dismissBtn.Attributes["aria-hidden"] = "true";
      dismissBtn.InnerHtml = "&times;";

      // create action message div
      TagBuilder builder = new TagBuilder("span");
      builder.Attributes["class"] = "alert alert-dismissable keep-center strong";
      builder.GenerateId(controlId);
      builder.AddCssClass(type.GetStringValue());
      builder.InnerHtml = dismissBtn.ToString(TagRenderMode.Normal) + message;

      // create the script tag
      TagBuilder script = new TagBuilder("script");
      script.Attributes["type"] = "text/javascript";

      StringBuilder sb = new StringBuilder();
      sb.Append("$(document).ready(function () { ");
      sb.Append("\n");
      sb.Append("var control = $('#" + controlId + "');");
      sb.Append("\n");

      switch (type)
      {
        case EMessage.Success:
          sb.Append("control.delay(3000).fadeOut('500');");
          break;

        default:
          sb.Append("control.fadeIn('500');");
          break;
      }
      sb.Append("\n");
      sb.Append("});");

      script.InnerHtml = sb.ToString();

      return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal) + script.ToString(TagRenderMode.Normal));
    }
  }
}