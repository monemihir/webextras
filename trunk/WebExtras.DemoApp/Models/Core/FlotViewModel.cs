using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExtras.JQFlot;

namespace WebExtras.DemoApp.Models.Core
{
  /// <summary>
  /// Flot graph view model
  /// </summary>
  public class FlotViewModel
  {
    public FlotChart Chart { get; set; }
    public int DisplayMode { get; set; }
  }
}