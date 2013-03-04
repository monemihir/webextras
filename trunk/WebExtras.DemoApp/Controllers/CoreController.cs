using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExtras.DemoApp.Models.Core;
using WebExtras.JQDataTables;

namespace WebExtras.DemoApp.Controllers
{
  public partial class CoreController : Controller
  {
    //
    // GET: /Core/
    public virtual ActionResult Index()
    {
      return RedirectToAction(Actions.Generic());
    }

    //
    // GET: /Core/Generic
    public virtual ActionResult Generic()
    {
      return View();
    }

    //
    // GET: /Core/Datatables
    public virtual ActionResult Datatables()
    {
      DatatablesViewModel model = new DatatablesViewModel();

      DatatableColumn dtColumn1 = new DatatableColumn("First Column", "", 10, true);
      DatatableColumn dtColumn2 = new DatatableColumn("Second Column", "", 10, true);

      DatatableSettings dtSettings = new DatatableSettings(5, new AASort(0, SortType.Ascending), null, "demo records", "150px");
      dtSettings.sDom = "t<'row-fluid'<'span6'i><'span6'p>>";
      dtSettings.sPaginationType = "bootstrap";

      // Let's create the actual data to go into the table
      string[][] dtData = new string[][]
      {
        new string[] { "first column row 1", "second column row 1" },    
        new string[] { "first column row 2", "second column row 2" }
      };

      DatatableRecords dtRecords = new DatatableRecords
      {
        iTotalRecords = dtData.Length,            // Total records in table
        iTotalDisplayRecords = dtData.Length,     // Total records to be displayed in the table
        aaData = dtData                           // The data to be displayed
      };

      // We need a collection of columns, so create an array from our column
      DatatableColumn[] dtColumns = new DatatableColumn[] { dtColumn1, dtColumn2 };

      // Let's create the datatable object with an HTML ID, our settings, columns and records
      Datatable dtable = new Datatable("demo-table", dtSettings, dtColumns, dtRecords);

      model.Table = dtable;

      return View(model);
    }

    //
    // GET: /Core/Flot
    public virtual ActionResult Flot()
    {
      return View();
    }
  }
}
