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
      return RedirectToAction(Actions.Core());
    }
    
    //
    // GET: /Mvc/Core
    public virtual ActionResult Core()
    {
      return View();
    }

    //
    // GET: /Mvc/Bootstrap
    public virtual ActionResult Bootstrap()
    {
      return View();
    }
  }
}
