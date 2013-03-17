using WebExtras.Core;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// A collection of button display types
  /// </summary>
  public enum BootstrapButtonType
  {
    /// <summary>
    /// Default button
    /// </summary>
    [StringValue("btn")]
    Default,

    /// <summary>
    /// Primary button
    /// </summary>
    [StringValue("btn btn-primary")]
    Primary,

    /// <summary>
    /// Success button
    /// </summary>
    [StringValue("btn btn-success")]
    Success,

    /// <summary>
    /// Info button
    /// </summary>
    [StringValue("btn btn-info")]
    Info,

    /// <summary>
    /// Warning button
    /// </summary>
    [StringValue("btn btn-warning")]
    Warning,

    /// <summary>
    /// Inverse button
    /// </summary>
    [StringValue("btn btn-inverse")]
    Inverse
  }
}
