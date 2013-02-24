using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMM.Library.WebExtras.Mvc
{
  /// <summary>
  /// Type of action message
  /// </summary>
  public enum ActionMessageType
  {
    /// <summary>
    /// Success message
    /// </summary>
    [StringValue("success")]
    Success,

    /// <summary>
    /// Error message
    /// </summary>
    [StringValue("error")]
    Error,

    /// <summary>
    /// Warning message
    /// </summary>
    [StringValue("warning")]
    Warning,

    /// <summary>
    /// Information message
    /// </summary>
    [StringValue("info")]
    Information
  }
}
