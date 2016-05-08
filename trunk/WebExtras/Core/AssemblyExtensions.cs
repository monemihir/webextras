// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace WebExtras.Core
{
  /// <summary>
  ///   <see cref="Assembly" /> extensions
  /// </summary>
  public static class AssemblyExtensions
  {
    /// <summary>
    ///   Whether current assembly was build in debug mode
    /// </summary>
    /// <param name="assembly">Current assembly</param>
    /// <returns>True if debug mode, else false</returns>
    public static bool IsDebugBuild(this Assembly assembly)
    {
      return
        assembly.GetCustomAttributes(false)
          .OfType<DebuggableAttribute>()
          .Select(da => da.IsJITTrackingEnabled)
          .FirstOrDefault();
    }
  }
}