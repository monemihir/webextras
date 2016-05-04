using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebExtras.Core
{
  /// <summary>
  /// <see cref="Assembly"/> extensions
  /// </summary>
  public static class AssemblyExtensions
  {
    /// <summary>
    /// Whether current assembly was build in debug mode
    /// </summary>
    /// <param name="assembly">Current assembly</param>
    /// <returns>True if debug mode, else false</returns>
    public static bool IsDebugBuild(this Assembly assembly)
    {
      return assembly.GetCustomAttributes(false).OfType<DebuggableAttribute>().Select(da => da.IsJITTrackingEnabled).FirstOrDefault();
    }
  }
}
