using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap hyperlink extensions
  /// </summary>
  public static class ExtendedHtmlStringExtension
  {
    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html helper</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <returns>Html element with icon added</returns>
    public static T AddIcon<T>(this T html, BoostrapIcon icon) where T : IExtendedHtmlString
    {
      Italic i = new Italic(null);
      i["class"] = string.Join(" ", icon.GetStringValue());
      html.PrependElement(i);

      return html;
    }

    /// <summary>
    /// Add a white icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html helper</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <returns>Html element with a white icon added</returns>
    public static T AddWhiteIcon<T>(this T html, BoostrapIcon icon) where T : IExtendedHtmlString
    {
      Italic i = new Italic(null);
      i["class"] = "icon-white " + string.Join(" ", icon.GetStringValue());
      html.PrependElement(i);

      return html;
    }
  }
}
