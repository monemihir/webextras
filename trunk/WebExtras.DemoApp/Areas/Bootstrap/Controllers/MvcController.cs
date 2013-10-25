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

using System;
using System.Web.Mvc;
using WebExtras.DemoApp.Models.Mvc;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Areas.Bootstrap.Controllers
{
  public partial class MvcController : BaseController
  {
    //
    // GET: /Bootstrap/Mvc
    public virtual ActionResult Index()
    {
      return RedirectToAction(Actions.CoreHtml());
    }

    //
    // GET: /Bootstrap/Mvc/CoreHtml
    public virtual ActionResult CoreHtml()
    {
      CoreHtmlViewModel model = new CoreHtmlViewModel
      {
        SomeProperty = "Blah blah",
        ShowMessage = false
      };

      return View(model);
    }

    //
    // GET: /Bootstrap/Mvc/CoreForm
    public virtual ActionResult CoreForm()
    {
      return View();
    }

    //
    // GET: /Bootstrap/Mvc/BootstrapHtml
    public virtual ActionResult BootstrapHtml(bool? msg)
    {
      CoreHtmlViewModel model = new CoreHtmlViewModel
      {
        SomeProperty = "Blah blah",
        ShowMessage = msg.HasValue
      };

      return View(model);
    }

    //
    // GET: /Bootstrap/Mvc/BootstrapForm
    public virtual ActionResult BootstrapForm()
    {
      CoreFormViewModel model = new CoreFormViewModel
      {
        DateTextBox = DateTime.Now,
        DateTimeTextBox = DateTime.Now,
        TimeTextBox = DateTime.Now
      };

      return View(model);
    }

    //
    // GET: /Bootstrap/Mvc/ActionMessageDemo
    public virtual ActionResult ActionMessageDemo(bool success)
    {
      if (!success)
        return this.RedirectToAction(Actions.BootstrapHtml(true), "Your action failed", EActionMessage.Error);
      return this.RedirectToAction(Actions.BootstrapHtml(true), "Your action was successful");
    }

    //
    // GET: /Bootstrap/Mvc/ActionResults
    public virtual ActionResult ActionResults()
    {
      return View();
    }
  }
}
