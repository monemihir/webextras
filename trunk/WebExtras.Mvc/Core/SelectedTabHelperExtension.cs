/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
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

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// Extension to highlight the active/selected tab. The onus is on the user
  /// to define the CSS class for the active tab and make it available to the
  /// webpage
  /// </summary>
  public static class SelectedTabHelperExtension
  {
    /// <summary>
    /// Default CSS class name for selected tab
    /// </summary>
    public static string DefaultCssClass = "active";

    /// <summary>
    /// Get the CSS class based on whether the provided tab is active or not
    /// </summary>
    /// <param name="helper">Current HTML helper object</param>
    /// <param name="activeController">Controller name to be matched</param>
    /// <param name="actions">[Optional] Action names to be matched. Defaults to null</param>
    /// <param name="areMatch">[Optional] Whether to set current tab as selected if the current 
    /// action matches an action specified in the 'actions' parameter. Defaults to true</param>
    /// <returns>If current tab is active, the default CSS class "active",
    /// else empty string to indicate that current tab is not active</returns>
    public static string SelectedTab(this HtmlHelper helper, string activeController, IEnumerable<string> actions = null, bool areMatch = true)
    {
      return SelectedTab(helper, activeController, actions, DefaultCssClass, areMatch);
    }

    /// <summary>
    /// Get the CSS class based on whether the provided tab is active or not
    /// </summary>
    /// <param name="helper">Current HTML helper object</param>
    /// <param name="activeController">Controller name to be matched</param>
    /// <param name="action">Action name to be matched</param>
    /// <param name="isMatch">[Optional] Whether to set current tab as selected if the current
    /// action matches the action specified by the 'action' parameter. Defaults to true.</param>
    /// <returns>If current tab is active, the default CSS class "active",
    /// else empty string to indicate that current tab is not active</returns>
    public static string SelectedTab(this HtmlHelper helper, string activeController, string action, bool isMatch = true)
    {
      return SelectedTab(helper, activeController, new[] { action }, DefaultCssClass, isMatch);
    }

    /// <summary>
    /// Get the CSS class based on whether the provided tab is active or not
    /// </summary>
    /// <param name="helper">Current HTML helper object</param>
    /// <param name="activeController">Controller name to be matched</param>
    /// <param name="action">Action name to be matched</param>
    /// <param name="cssClass">custom CSS class defined with active tab CSS</param>
    /// <param name="isMatch">[Optional] Whether to set current tab as selected if the current
    /// action matches the action specified by the 'action' parameter. Defaults to true.</param>
    /// <returns>If current tab is active, the CSS class provided,
    /// else empty string to indicate that current tab is not active</returns>
    public static string SelectedTab(this HtmlHelper helper, string activeController, string action, string cssClass, bool isMatch = true)
    {
      return SelectedTab(helper, activeController, new[] { action }, cssClass, isMatch);
    }

    /// <summary>
    /// Get the CSS class based on whether the provided tab is active or not
    /// </summary>
    /// <param name="helper">Current HTML helper object</param>
    /// <param name="activeController">Controller name to be matched</param>
    /// <param name="actions">Action names to be matched</param>
    /// <param name="cssClass">custom CSS class defined with active tab CSS</param>
    /// <param name="areMatch">[Optional] Whether to set current tab as selected if the current 
    /// action matches an action specified in the 'actions' parameter. Defaults to true</param>
    /// <returns>If current tab is active, the CSS class provided,
    /// else empty string to indicate that current tab is not active</returns>
    private static string SelectedTab(this HtmlHelper helper, string activeController, IEnumerable<string> actions, string cssClass, bool areMatch = true)
    {
      string cssClassToUse;

      activeController = activeController.ToLowerInvariant();
      string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString().ToLowerInvariant();
      if (actions != null)
      {
        actions = actions.Select(f => f.ToLowerInvariant());
        string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString().ToLowerInvariant();
        if (areMatch)
        {
          cssClassToUse =
            (currentController == activeController && actions.Contains(currentAction))
              ? cssClass
              : string.Empty;
        }
        else
        {
          cssClassToUse =
            (currentController == activeController && !actions.Contains(currentAction))
              ? cssClass
              : string.Empty;
        }
      }
      else
      {
        cssClassToUse = (currentController == activeController) ? cssClass : string.Empty;
      }

      return cssClassToUse;
    }
  }
}