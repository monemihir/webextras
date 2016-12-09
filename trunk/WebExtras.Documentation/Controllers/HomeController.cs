using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExtras.Documentation.Controllers
{
  public partial class HomeController : Controller
  {
    // GET: Home
    public virtual ActionResult Index()
    {
      return View();
    }
  }
}