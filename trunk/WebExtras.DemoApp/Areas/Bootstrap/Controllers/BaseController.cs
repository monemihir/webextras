using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Areas.Bootstrap.Controllers
{
    public abstract class BaseController : Controller
    {
      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        base.OnActionExecuting(filterContext);

        WebExtrasMvcConstants.BootstrapVersion = EBootstrapVersion.V2;
      }
    }
}
