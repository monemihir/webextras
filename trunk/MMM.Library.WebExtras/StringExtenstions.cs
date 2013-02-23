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

    /// <summary>
    /// Returns a value indicating whether the specified System.String object occurs
    /// within this string ignoring case.
    /// </summary>
    /// <param name="str">String to be checked</param>
    /// <param name="value">The string to seek</param>
    /// <returns>True if string to be seeked is found in this string, else False</returns>
    public static bool ContainsIgnoreCase(this string str, string value)
    {
      return str.ToLowerInvariant().Contains(value.ToLowerInvariant());
    }
  }
}