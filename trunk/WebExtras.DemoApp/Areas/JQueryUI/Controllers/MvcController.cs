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

using System;
using System.Web.Mvc;
using WebExtras.DemoApp.Models.Mvc;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Areas.JQueryUI.Controllers
{
  public partial class MvcController : BaseController
  {
    //
    // GET: /JQueryUI/Mvc
    public virtual ActionResult Index()
    {
      return RedirectToAction(Actions.CoreHtml());
    }

    //
    // GET: /JQueryUI/Mvc/CoreHtml
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
    // GET: /JQueryUI/Mvc/CoreForm
    public virtual ActionResult CoreForm()
    {
      return View();
    }

    //
    // GET: /JQueryUI/Mvc/BootstrapHtml
    public virtual ActionResult JQueryUIHtml(bool? msg)
    {
      CoreHtmlViewModel model = new CoreHtmlViewModel
      {
        SomeProperty = "Blah blah",
        ShowMessage = msg.HasValue
      };

      return View(model);
    }

    //
    // GET: /JQueryUI/Mvc/BootstrapForm
    public virtual ActionResult JQueryUIForm()
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
    // GET: /JQueryUI/Mvc/ActionMessageDemo
    public virtual ActionResult ActionMessageDemo()
    {
      return this.RedirectToAction(Actions.JQueryUIHtml(true), "This is an action message demo");
    }

    //
    // GET: /JQueryUI/Mvc/ActionResults
    public virtual ActionResult ActionResults()
    {
      return View();
    }
  }
}
