/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Text;
using System.Web.Mvc;
using WebExtras.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// A class to store and retrieve messages for display after an action has occurred
  /// Provides ControllerBase and HtmlHelper extensions
  /// </summary>
  public static class ActionMessageControllerExtension
  {
    /// <summary>
    /// The key used to store the message in the TempData object
    /// </summary>
    public const string TempDataMessageKey = "<Bootstrap_LastActionMessage>";

    /// <summary>
    /// The key used to store the message type i.e success/failure in the TempData object
    /// </summary>
    public const string TempDataMessageTypeKey = "<Bootstrap_LastActionMessageType>";

    /// <summary>
    /// Overload of the RedirectToAction method, which allows the saving of an action message
    /// before the redirect is executed
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="result">The redirect result to execute</param>
    /// <param name="message">The action message to display</param>
    /// <param name="type">Action message type</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>A RedirectToRouteResult result</returns>
    public static RedirectToRouteResult RedirectToAction(this ControllerBase c, ActionResult result, string message, EActionMessage type = EActionMessage.Success, params object[] args)
    {
      SaveActionMessage(c, message, type, args);

      var callInfo = result.GetT4MVCResult();
      return new RedirectToRouteResult(null, callInfo.RouteValueDictionary);
    }

    /// <summary>
    /// Overload of the View method, which allows the saving of an action message
    /// before the View is returned
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="viewName">The view name to show</param>
    /// <param name="model">Model data associated with the view</param>
    /// <param name="message">The action message to display</param>
    /// <param name="type">Action message type</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>a ViewResult result</returns>
    public static ViewResult View(this ControllerBase c, string viewName, object model, string message, EActionMessage type = EActionMessage.Success, params object[] args)
    {
      SaveActionMessage(c, message, type, args);

      c.ViewData.Model = model;
      return new ViewResult
      {
        ViewName = viewName,
        ViewData = c.ViewData,
        TempData = c.TempData
      };
    }

    /// <summary>
    /// ControllerBase extension method to save a message to the Controller.TempData session store using the key denoted by
    /// 'TempDataMessageKey' variable.
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="message">The action message to display</param>
    /// <param name="type">Action message type</param>
    /// <param name="args">Any message formatting arguments</param>
    private static void SaveActionMessage(this ControllerBase c, string message, EActionMessage type, params object[] args)
    {
      // store data in temp key, will be alive for one request only
      c.TempData[TempDataMessageKey] = string.Format(message, args);
      c.TempData[TempDataMessageTypeKey] = type;
    }

    /// <summary>
    /// HtmlHelper extension method to save a message to the Controller.TempData session cache using the key: TempDataMessageKey.
    /// TempData is only alive for one request only before being wiped.
    /// </summary>
    /// <param name="helper">HtmlHelper</param>
    /// <returns>The last message if available in a div object</returns>
    public static MvcHtmlString GetLastActionMessage(this HtmlHelper helper)
    {
      if (helper.ViewContext.TempData.ContainsKey(TempDataMessageKey))
      {
        // get message
        string message = helper.ViewContext.TempData[TempDataMessageKey].ToString();
        EActionMessage type = (EActionMessage)helper.ViewContext.TempData[TempDataMessageTypeKey];
        string controlId = "actionmessage";

        // create the dismiss button
        //<button type="button" class="close" data-dismiss="alert">&times;</button>
        TagBuilder dismissBtn = new TagBuilder("button");
        dismissBtn.AddCssClass("close");
        dismissBtn.Attributes["data-dismiss"] = "alert";
        dismissBtn.Attributes["aria-hidden"] = "true";
        dismissBtn.InnerHtml = "&times;";

        // create action message div
        TagBuilder builder = new TagBuilder("div");
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
          case EActionMessage.Success:
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

      return MvcHtmlString.Empty;
    }
  }
}