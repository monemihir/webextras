using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebExtras.DemoApp.Models.Mvc
{
  public class BootstrapHtmlViewModel
  {
    public string SomeProperty { get; set; }

    [Description("This is the second property")]
    public string SomeProperty2 { get; set; }

    public bool ShowMessage { get; set; }
  }
}