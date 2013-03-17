using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExtras.JQDataTables;

namespace WebExtras.DemoApp.Models.Core
{
  public class DatatablesViewModel
  {
    public int DisplayMode { get; set; }

    public Datatable Table { get; set; }

    public Datatable PostbackEnabledTable { get; set; }

    public PostbackSetupViewModel PostbackFormFields { get; set; }
  }
}