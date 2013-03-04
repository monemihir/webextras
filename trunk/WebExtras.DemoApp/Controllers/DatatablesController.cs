using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExtras.DemoApp.Controllers
{
  public partial class DatatablesController : Controller
  {
    //
    // GET: /Datatables/
    public virtual ActionResult Index()
    {
      return View();
    }

  }
}
