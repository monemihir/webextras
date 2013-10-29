/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2013 Mihir Mone
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

using System.Web.Mvc;

namespace WebExtras.DemoApp.Areas.Gumby
{
  public class GumbyAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "gumby";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute(
          "gumby_default",
          "gumby/{controller}/{action}/{id}",
          new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
