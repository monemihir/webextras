using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtras.Core
{
  /// <summary>
  /// Utility methods for <see cref="Enum"/>
  /// </summary>
  public static class EnumUtil
  {
    /// <summary>
    /// Get all values of an enum
    /// </summary>
    /// <typeparam name="TEnumType">Enum type</typeparam>
    /// <returns>A collection of all values of the enum</returns>
    public static IEnumerable<TEnumType> GetValues<TEnumType>()
    {
      if (!typeof(TEnumType).IsEnum)
        throw new InvalidUsageException("GetValues<> can only be invoked on an enum");

      return Enum.GetValues(typeof(TEnumType)).Cast<TEnumType>();
    }
  }
}
