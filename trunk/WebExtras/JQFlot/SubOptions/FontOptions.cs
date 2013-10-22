/*
* This file is part of - WebExtras
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

namespace WebExtras.JQFlot.SubOptions
{
  /// <summary>
  /// Represents Flot font options.
  /// </summary>
  [Serializable]
  public class FontOptions
  {
    /// <summary>
    /// Font size in pixels
    /// </summary>
    public int? size;

    /// <summary>
    /// Font line height in pixels
    /// </summary>
    public int? lineHeight;

    /// <summary>
    /// Font style. CSS font-style specification.
    /// </summary>
    public string style;

    /// <summary>
    /// Font weight. CSS font-weight specification.
    /// </summary>
    public string weight;

    /// <summary>
    /// Font family. CSS font-family specfication.
    /// </summary>
    public string family;

    /// <summary>
    /// Font variant. CSS font-variant specification.
    /// </summary>
    public string variant;

    /// <summary>
    /// Font color. CSS color specification.
    /// </summary>
    public string color;
  }
}
