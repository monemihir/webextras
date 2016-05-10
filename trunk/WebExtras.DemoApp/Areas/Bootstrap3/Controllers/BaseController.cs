/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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

#pragma warning disable 1591

using System;
using System.Reflection;
using System.Web.Mvc;
using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Areas.Bootstrap3.Controllers
{
  public abstract partial class BaseController : Controller
  {
    protected string m_versionString;

    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      base.OnActionExecuting(filterContext);

      ViewData["layout_path"] = MVC.Bootstrap3.Shared.Views._Layout;
      WebExtrasConstants.DatatablesPaginationScheme = JQDataTables.EPagination.Bootstrap3;
      WebExtrasConstants.CssFramework = ECssFramework.Bootstrap;
      WebExtrasConstants.BootstrapVersion = EBootstrapVersion.V3;
      
      Version v = Assembly.GetExecutingAssembly().GetName().Version;

      m_versionString = string.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Revision);
    }
  }
}
