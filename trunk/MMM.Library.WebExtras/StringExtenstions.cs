using System.Globalization;

namespace MMM.Library.WebExtras
{
  /// <summary>
  /// String extension functions
  /// </summary>
  public static class StringExtenstions
  {
    /// <summary>
    /// Converts a given string to title case
    /// </summary>
    /// <param name="str">String to be converted to titlecase</param>
    /// <returns>Titlecase converted string</returns>
    public static string ToTitleCase(this string str)
    {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
    }
  }
}
