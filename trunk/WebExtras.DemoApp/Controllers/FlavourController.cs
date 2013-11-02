﻿/*
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

using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace WebExtras.DemoApp.Controllers
{
  public partial class FlavourController : Controller
  {
    //
    // GET: /Flavour/
    public virtual ActionResult Index()
    {
      return View();
    }

    //
    // GET: /Flavour/BuildDetails
    public virtual ContentResult BuildDetails()
    {
      string result = System.IO.File.ReadAllText(Server.MapPath(Links.Content.inline.build_txt));

      string url = Request.Url.AbsoluteUri;

      if (url.Contains("apphb.com"))
      {
        FileInfo fInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
        result = "Built by <a href='http://www.appharbor.com'>AppHarbor</a> on " +
          fInfo.CreationTime.ToString("dd MMM yyyy HH:mm:ss zz");
      }

      return Content(result);
    }
  }
}