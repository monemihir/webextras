using System;
using System.Globalization;

namespace MMM.Library.WebExtras
{
  /// <summary>
  /// Enum extenstions
  /// </summary>
  public static class EnumExtention
  {
    /// <summary>
    /// Convert a given enum value to titlecase
    /// </summary>
    /// <param name="val">Enum value to be converted</param>
    /// <returns>Titlecase converted value</returns>
    public static string ToTitleCase(this Enum val)
    {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(val.ToString());
    }
  }
}
