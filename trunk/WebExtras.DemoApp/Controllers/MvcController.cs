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
    // GET: /Mvc/Bootstrap
    public virtual ActionResult Bootstrap()
    {
      return View();
    }
  }
}
