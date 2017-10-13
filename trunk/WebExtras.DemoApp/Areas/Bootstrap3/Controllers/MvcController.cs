// 
// This file is part of - WebExtras
// Copyright 2017 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.FontAwesome;
using WebExtras.Mvc.Bootstrap;
using WebExtras.Mvc.Html;
#pragma warning disable 1591
using System;
using System.Web.Mvc;
using WebExtras.DemoApp.Models.Mvc;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Areas.Bootstrap3.Controllers
{
  public partial class MvcController : BaseController
  {
    //
    // GET: /Bootstrap3/Mvc
    public virtual ActionResult Index()
    {
      return RedirectToAction(Actions.CoreHtml());
    }

    //
    // GET: /Bootstrap3/Mvc/CoreHtml
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
    // GET: /Bootstrap3/Mvc/CoreForm
    public virtual ActionResult CoreForm()
    {
      return View();
    }

    //
    // GET: /Bootstrap3/Mvc/BootstrapHtml
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
    // GET: /Bootstrap3/Mvc/BootstrapForm
    public virtual ActionResult BootstrapForm()
    {
      CoreFormViewModel model = new CoreFormViewModel
      {
        DateTextBox = DateTime.Now,
        DateTimeTextBox = DateTime.Now,
        TimeTextBox = DateTime.Now,
        DatePickerNoAddon = DateTime.Now
      };

      return View(model);
    }

    //
    // GET: /Bootstrap3/Mvc/ActionMessageDemo
    public virtual ActionResult ActionMessageDemo(bool success)
    {
      if (!success)
        return this.RedirectToAction(Actions.BootstrapHtml(true), "Your action failed", EMessage.Error);
      return this.RedirectToAction(Actions.BootstrapHtml(true), "Your action was successful");
    }

    //
    // GET: /Bootstrap3/Mvc/UserAlertsDemo
    public virtual ActionResult UserAlertsDemo()
    {
      Random rand = new Random(DateTime.UtcNow.Millisecond);
      Alert[] defaultAlerts =
      {
        new Alert(EMessage.Success, "Hooray...I am a resounding success"),
        new Alert(EMessage.Warning, "Oops...something went wrong. But no worries, I can still continue", "Note:"),
        new Alert(EMessage.Error, "No dice...something is seriously wrong. I quit", "Error:",
          EBootstrapIcon.Exclamation_Sign),
        new Alert(EMessage.Information, "Just so you know, I am gonna try it again", "Note:", EFontAwesomeIcon.Flag)
      };

      this.SaveUserAlert(defaultAlerts[rand.Next(4)]);

      return RedirectToAction(Actions.BootstrapHtml());
    }

    //
    // GET: /Bootstrap3/Mvc/ActionResults
    public virtual ActionResult ActionResults()
    {
      return View();
    }
  }
}