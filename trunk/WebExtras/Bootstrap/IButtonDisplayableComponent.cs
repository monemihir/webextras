using WebExtras.Core;
using WebExtras.Html;

namespace WebExtras.Bootstrap
{
  /// <summary>
  /// A HTML button component
  /// </summary>
  public interface IButtonDisplayableComponent : IHtmlRenderer
  {
    /// <summary>
    /// Add a bootstrap icon
    /// </summary>
    /// <param name="icon">Icon to add</param>
    /// <param name="append">[Optional] Whether to append the icon. Defaults to false</param>
    /// <returns>Updated button component</returns>
    IButtonDisplayableComponent AddIcon(EBootstrapIcon icon, bool append=false);

    /// <summary>
    /// Add a FontAwesome icon
    /// </summary>
    /// <param name="icon">Icon to add</param>
    /// <param name="size">Icon size</param>
    /// <param name="append">[Optional] Whether to append the icon. Defaults to false</param>
    /// <returns>Updated button component</returns>
    IButtonDisplayableComponent AddIcon(EFontAwesomeIcon icon, EFontAwesomeIconSize size = EFontAwesomeIconSize.Normal, bool append = false);
  }
}
