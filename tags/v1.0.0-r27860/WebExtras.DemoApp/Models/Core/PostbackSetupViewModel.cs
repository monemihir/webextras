using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebExtras.JQDataTables;

namespace WebExtras.DemoApp.Models.Core
{
  public class PostbackSetupViewModel
  {
    [DisplayName("First column")]
    public string FirstColumn { get; set; }

    [DisplayName("Second column")]
    public string SecondColumn { get; set; }

    public PostbackSetupViewModel() { }
  }
}