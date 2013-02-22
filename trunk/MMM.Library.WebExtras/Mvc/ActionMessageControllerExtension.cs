/*
* This file is part of - Code Library
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

using System.Web.Mvc;

namespace MMM.Library.WebExtras.Mvc
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
    public const string TempDataMessageKey = "<MvcAction_LastActionMessage>";

    /// <summary>
    /// The key used to store the message type i.e success/failure in the TempData object
    /// </summary>
    public const string TempDataMessageTypeKey = "<MvcAction_LastActionMessageType>";

    /// <summary>
    /// Overload of the RedirectToAction method, which allows the saving of an action message
    /// before the redirect is executed
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="result">The redirect result to execute</param>
    /// <param name="message">The action message to display after redirection. Use a starting ! character to display as an alert message.</param>
    /// <param name="isSuccess">Flag indicating whether this action result was a success or failure</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>A RedirectToRouteResult result</returns>
    public static RedirectToRouteResult RedirectToAction(this ControllerBase c, ActionResult result, string message, bool isSuccess, params object[] args)
    {
      SaveActionMessage(c, message, isSuccess, args);

      var callInfo = result.GetT4MVCResult();
      return new RedirectToRouteResult(
        null,
        callInfo.RouteValueDictionary
        );
    }

    /// <summary>
    /// Overload of the RedirectToAction method, which allows the saving of an action message
    /// before the redirect is executed
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="result">The redirect result to execute</param>
    /// <param name="message">The action message to display after redirection. Use a starting ! character to display as an alert message.</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>A RedirectToRouteResult result</returns>
    public static RedirectToRouteResult RedirectToAction(this ControllerBase c, ActionResult result, string message, params object[] args)
    {
      SaveActionMessage(c, message, true, args);

      var callInfo = result.GetT4MVCResult();
      return new RedirectToRouteResult(
        null,
        callInfo.RouteValueDictionary
        );
    }

    /// <summary>
    /// Overload of the View method, which allows the saving of an action message
    /// before the View is returned
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="viewName">The view name to show</param>
    /// <param name="model">Model data associated with the view</param>
    /// <param name="message">The action message to display after redirection. Use a starting ! character to display as an alert message.</param>
    /// <param name="isSuccess">Flag indicating whether this action result was a success or failure</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>a ViewResult result</returns>
    public static ViewResult View(this ControllerBase c, string viewName, object model, string message, bool isSuccess, params object[] args)
    {
      SaveActionMessage(c, message, isSuccess, args);

      c.ViewData.Model = model;
      return new ViewResult
      {
        ViewName = viewName,
        ViewData = c.ViewData,
        TempData = c.TempData
      };
    }

    /// <summary>
    /// Overload of the View method, which allows the saving of an action message
    /// before the View is returned
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="viewName">The view name to show</param>
    /// <param name="model">Model data associated with the view</param>
    /// <param name="message">The action message to display after redirection. Use a starting ! character to display as an alert message.</param>
    /// <param name="args">Any message formatting arguments</param>
    /// <returns>a ViewResult result</returns>
    public static ViewResult View(this ControllerBase c, string viewName, object model, string message, params object[] args)
    {
      SaveActionMessage(c, message, true, args);

      c.ViewData.Model = model;
      return new ViewResult
      {
        ViewName = viewName,
        ViewData = c.ViewData,
        TempData = c.TempData
      };
    }

    /// <summary>
    /// ControllerBase extension method to save a message to
    /// the Controller.TempData session cache using the key: TempDataMessageKey.
    /// TempData is only alive for one request only before being wiped.
    /// </summary>
    /// <param name="c">The controller</param>
    /// <param name="message">The action message to display after redirection. Use a starting ! character to display as an alert message.</param>
    /// <param name="isSuccess">Flag indicating whether to save a success message or a failure message </param>
    /// <param name="args">Any message formatting arguments</param>
    private static void SaveActionMessage(this ControllerBase c, string message, bool isSuccess, params object[] args)
    {
      // store data in temp key, will be alive for one request only
      c.TempData[TempDataMessageKey] = string.Format(message, args);
      c.TempData[TempDataMessageTypeKey] = isSuccess;
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
        bool success = (bool)helper.ViewContext.TempData[TempDataMessageTypeKey];

        // create the close button for action message
        TagBuilder closeBtn = new TagBuilder("button");
        closeBtn.Attributes["type"] = "button";
        closeBtn.Attributes["data-dismiss"] = "alert";
        closeBtn.AddCssClass("close");
        closeBtn.SetInnerText("x");

        TagBuilder builder = new TagBuilder("div");
        builder.AddCssClass("alert");
        builder.GenerateId("actionmessage");

        if (success)
          builder.AddCssClass("alert-success");
        else
          builder.AddCssClass("alert-error");

        builder.InnerHtml = closeBtn.ToString(TagRenderMode.Normal) + message;

        return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
      }

      return MvcHtmlString.Empty;
    }
  }
}
