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
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExtras.DemoApp.Controllers
{
  public partial class MvcController : Controller
  {
    //
    // GET: /Mvc
    public virtual ActionResult Index()
    {
      return RedirectToAction(Actions.CoreHtml());
    }
    
    //
    // GET: /Mvc/CoreHtml
    public virtual ActionResult CoreHtml()
    {
      return View();
    }

    //
    // GET: /Mvc/CoreForm
    public virtual ActionResult CoreForm()
    {
      return View();
    }

    //
    // GET: /Mvc/BootstrapHtml
    public virtual ActionResult BootstrapHtml()
    {
      return View();
    }

    //
    // GET: /Mvc/BootstrapForm
    public virtual ActionResult BootstrapForm()
    {
      return View();
    }
  }
}
