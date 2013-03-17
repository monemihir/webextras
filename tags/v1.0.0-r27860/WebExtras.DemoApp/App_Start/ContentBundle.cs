using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExtras.Core;

namespace WebExtras.DemoApp.App_Start
{
  /// <summary>
  /// A list of all content bundles available
  /// </summary>
  public enum ContentBundle
  {
    /// <summary>
    /// Main bundle
    /// </summary>
    [StringValue("css-main")]
    CSSMain,

    /// <summary>
    /// Core jQuery, jQuery UI and any other core libraries
    /// </summary>
    [StringValue("js-base")]
    JSBase,
  }
}