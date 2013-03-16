using System;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap hyperlink extensions
  /// </summary>
  public static class BootstrapHtmlStringExtension
  {
    #region Icon extensions

    /// <summary>
    /// Add an icon
    /// </summary>
    /// <typeparam name="T">Generic type to be used. This type must implement IExtendedHtmlString</typeparam>
    /// <param name="html">Current html element</param>
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
    /// <param name="html">Current html element</param>
    /// <param name="icon">Icon to be rendered</param>
    /// <returns>Html element with a white icon added</returns>
    public static T AddWhiteIcon<T>(this T html, BoostrapIcon icon) where T : IExtendedHtmlString
    {
      Italic i = new Italic(null);
      i["class"] = "icon-white " + string.Join(" ", icon.GetStringValue());
      html.PrependElement(i);

      return html;
    }

    #endregion Icon extensions

    #region Button extensions

    /// <summary>
    /// Create special buttons
    /// </summary>
    /// <typeparam name="T">Generic type to be used. Can only be either Hyperlink or Button</typeparam>
    /// <param name="html">Current HTML element</param>
    /// <param name="type">Bootstrap button type</param>
    /// <returns>A special button</returns>
    public static T AsButton<T>(this T html, BootstrapButtonType type) where T : IExtendedHtmlString
    {
      if (CanDisplayAsButton(html))
        html.AddCssClass(type.GetStringValue());

      return html;
    }

    /// <summary>
    /// Check whether we can actually display as button
    /// </summary>
    /// <param name="html">Current HTML element</param>
    /// <returns>True if can display as button, else False</returns>
    private static bool CanDisplayAsButton(IExtendedHtmlString html)
    {
      // We can only display hyperlinks and button as buttons
      try { Hyperlink h = html as Hyperlink; return true; }
      catch (Exception) { }

      try { Button b = html as Button; return true; }
      catch (Exception) { }

      return false;
    }

    #endregion Button extensions

    #region List extensions

    /// <summary>
    /// Create an unstyled list
    /// </summary>
    /// <param name="list">List to be converted</param>
    /// <returns>An unstyled list</returns>
    public static IExtendedHtmlString AsUnstyled(this HtmlList list)
    {
      list.AddCssClass("unstyled");

      return list;
    }

    #endregion List extensions
  }
}
