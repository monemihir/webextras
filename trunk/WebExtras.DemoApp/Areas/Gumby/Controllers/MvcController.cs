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
using WebExtras.Core;
using WebExtras.Gumby;
using WebExtras.Mvc.Bootstrap;
using WebExtras.Mvc.Gumby;
using WebExtras.Mvc.Html;
#pragma warning disable 1591
using System.Web.Mvc;
using WebExtras.DemoApp.Models.Mvc;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Areas.Gumby.Controllers
{
  public partial class MvcController : BaseController
  {
    //
    // GET: /Gumby/Mvc
    public virtual ActionResult Index()
    {
      return RedirectToAction(Actions.CoreHtml());
    }

    //
    // GET: /Gumby/Mvc/CoreHtml
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
    // GET: /Gumby/Mvc/CoreForm
    public virtual ActionResult CoreForm()
    {
      return View();
    }

    //
    // GET: /Gumby/Mvc/GumbyHtml
    public virtual ActionResult GumbyHtml(bool? msg)
    {
      CoreHtmlViewModel model = new CoreHtmlViewModel
      {
        SomeProperty = "Blah blah",
        ShowMessage = msg.HasValue
      };

      return View(model);
    }

    //
    // GET: /Gumby/Mvc/GumbyForm
    public virtual ActionResult GumbyForm()
    {
      //BootstrapFormViewModel model = new BootstrapFormViewModel
      //{
      //  DateTextBox = DateTime.Now,
      //  DateTimeTextBox = DateTime.Now,
      //  TimeTextBox = DateTime.Now
      //};

      return View();
    }

    //
    // GET: /Gumby/Mvc/ActionMessageDemo
    public virtual ActionResult ActionMessageDemo(bool success)
    {
      if (!success)
        return this.RedirectToAction(Actions.GumbyHtml(true), "Your action failed", EMessage.Error);
      return this.RedirectToAction(Actions.GumbyHtml(true), "Your action was successful");
    }

    //
    // GET: /Gumby/Mvc/UserAlertsDemo
    public virtual ActionResult UserAlertsDemo()
    {
      Random rand = new Random(DateTime.UtcNow.Millisecond);
      Alert[] defaultAlerts = {
        new Alert(EMessage.Success, "Hooray...I am a resounding success"),
        new Alert(EMessage.Warning, "Oops...something went wrong. But no worries, I can still continue", "Note:"),
        new Alert(EMessage.Error, "No dice...something is seriously wrong. I quit", "Error:", EGumbyIcon.Docs),
        new Alert(EMessage.Information, "Just so you know, I am gonna try it again", "Note:", EGumbyIcon.Flag)
      };

      this.SaveUserAlert(defaultAlerts[rand.Next(4)]);

      return RedirectToAction(Actions.GumbyHtml());
    }

    //
    // GET: /Gumby/Mvc/ActionResults
    public virtual ActionResult ActionResults()
    {
      return View();
    }
  }
}
