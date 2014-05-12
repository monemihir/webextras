/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Web.Mvc;
using WebExtras.DemoApp.Models.Core;
using WebExtras.Mvc.Core;

namespace WebExtras.DemoApp.Controllers
{
  public partial class GraphDataController : Controller
  {
    /// <summary>
    /// Returns the graph data to be plotted as JSON
    /// </summary>
    /// <returns>JSON data result</returns>
    public virtual ActionResult GetJQPlotData()
    {
      List<double[][]> data = new List<double[][]> { new GraphDataGenerator().GraphSampleData };

      return new JsonNetResult(data, JsonRequestBehavior.AllowGet);
    }
  }
}