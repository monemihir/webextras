using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebExtras.JQFlot.Graphs
{
  /// <summary>
  /// Represents a base graph
  /// </summary>
  [Serializable]
  public abstract class BaseGraph
  {
    /// <summary>
    /// Whether to show graph
    /// </summary>
    public bool? show;

    /// <summary>
    /// The width in pixels of the line
    /// </summary>
    public int? lineWidth;

    /// <summary>
    /// Whether the area under the lines should be filled.
    /// </summary>
    public bool? fill;

    /// <summary>
    /// Fill color. This must be a CSS color specification.
    /// </summary>
    public string fillColor;
  }
}
