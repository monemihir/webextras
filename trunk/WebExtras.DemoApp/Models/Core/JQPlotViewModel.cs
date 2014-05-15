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

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExtras.JQPlot;

namespace WebExtras.DemoApp.Models.Core
{
  /// <summary>
  /// jqPlot view model
  /// </summary>
  public class JQPlotViewModel
  {
    public JQPlotChartBase[] Charts { get; set; }
    public int DisplayMode { get; set; }
  }
}