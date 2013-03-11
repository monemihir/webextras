/*
* This file is part of - Code Library
* Copyright (C) 2013 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// flot grid options
  /// </summary>
  public class GridOptions
  {
     /// <summary>
      /// ctor to initialize defaults. hoverable=true, clickable=false, borderWidth=0, show=false
      /// </summary>
      public GridOptions()
      {
        hoverable = true;
        clickable = false;
        borderWidth = 0;
      }

      /// <summary>
      /// whether the grid is hoverable
      /// </summary>
      public bool hoverable { get; set; }

      /// <summary>
      /// whether the grid is clickable
      /// </summary>
      public bool clickable { get; set; }

      /// <summary>
      /// border width for graph
      /// </summary>
      public int borderWidth { get; set; }
  }
}
