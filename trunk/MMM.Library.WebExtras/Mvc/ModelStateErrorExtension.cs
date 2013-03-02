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

using System.Collections.Specialized;
using System.Web.Mvc;

namespace MMM.Library.WebExtras.Mvc
{
  /// <summary>
  /// ModelStateDictionary extension class to add custom/server side validation errors
  /// </summary>
  public static class ModelStateErrorExtension
  {
    /// <summary>
    /// ModelStateDictionary extension method which adds custom/server side validation errors for display by MVC
    /// </summary>
    /// <param name="modelState">ModelStateDictionary object</param>
    /// <param name="errors">NameValueCollection of errors: key=property name, value=error message</param>
    public static void AddRuleViolations(this ModelStateDictionary modelState, NameValueCollection errors)
    {
      AddRuleViolations(modelState, errors, null);
    }

    /// <summary>
    /// ModelStateDictionary extension method which adds custom/server side validation errors for display by MVC
    /// </summary>
    /// <param name="modelState">ModelStateDictionary object</param>
    /// <param name="errors">NameValueCollection of errors: key=property name, value=error message</param>
    /// <param name="keyPrefix">a string to prefix the final key, used for child objects i.e EditVesselViewModel.Vessel.IMO</param>
    public static void AddRuleViolations(this ModelStateDictionary modelState,
      NameValueCollection errors, string keyPrefix)
    {
      if (errors == null || errors.Count == 0)
        return;

      keyPrefix = string.IsNullOrEmpty(keyPrefix) ? "" : keyPrefix + ".";

      foreach (string key in errors.Keys)
        modelState.AddModelError(keyPrefix + key, errors.Get(key));
    }
  }
}