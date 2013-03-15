using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap button extensions
  /// </summary>
  public static class BootstrapButtonExtension
  {
    /// <summary>
    /// Create a primary button
    /// </summary>
    /// <param name="btn">HTML Button element</param>
    /// <returns>A HTML primary button</returns>
    public static Button AsPrimary(this Button btn)
    {
      btn.AddCssClass("btn btn-primary");

      return btn;
    }

    /// <summary>
    /// Create a regular button
    /// </summary>
    /// <param name="btn">HTML Button element</param>
    /// <returns>A HTML regular button</returns>
    public static Button AsRegular(this Button btn)
    {
      btn.AddCssClass("btn");

      return btn;
    }

    /// <summary>
    /// Create a success button
    /// </summary>
    /// <param name="btn">HTML Button element</param>
    /// <returns>A HTML success button</returns>
    public static Button AsSuccess(this Button btn)
    {
      btn.AddCssClass("btn btn-success");

      return btn;
    }

    /// <summary>
    /// Create a warning button
    /// </summary>
    /// <param name="btn">HTML Button element</param>
    /// <returns>A HTML warning button</returns>
    public static Button AsWarning(this Button btn)
    {
      btn.AddCssClass("btn btn-warning");

      return btn;
    }

    /// <summary>
    /// Create a info button
    /// </summary>
    /// <param name="btn">HTML Button element</param>
    /// <returns>A HTML info button</returns>
    public static Button AsInfo(this Button btn)
    {
      btn.AddCssClass("btn btn-info");

      return btn;
    }
  }
}
