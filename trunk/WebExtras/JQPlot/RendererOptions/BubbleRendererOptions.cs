/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


namespace WebExtras.JQPlot.RendererOptions
{
  /// <summary>
  /// Bubble renderer options
  /// </summary>
  public class BubbleRendererOptions : IRendererOptions
  {
    /// <summary>
    /// True to vary the color of each bubble in this series according to the 
    /// seriesColors array.  False to set each bubble to the color specified 
    /// on this series.  This has no effect if a css background color option 
    /// is specified in the renderer css options.
    /// </summary>
    public bool? varyBubbleColors { get; set; }

    /// <summary>
    /// True to scale the bubble radius based on plot size.  False will use 
    /// the radius value as provided as a raw pixel value for bubble radius.
    /// </summary>
    public bool? autoscaleBubbles { get; set; }

    /// <summary>
    /// Multiplier the bubble size if autoscaleBubbles is true.
    /// </summary>
    public bool? autoscaleMultiplier { get; set; }

    /// <summary>
    /// Factor which decreases bubble size based on how many bubbles on the 
    /// chart.  0 means no adjustment for number of bubbles.  Negative values 
    /// will decrease size of bubbles as more bubbles are added.  Values 
    /// between 0 and -0.2 should work well.
    /// </summary>
    public double? autoscalePointsFactor { get; set; }

    /// <summary>
    /// True to escape html in bubble label text.
    /// </summary>
    public bool? escapeHtml { get; set; }

    /// <summary>
    /// True to highlight bubbles when moused over.  This must be false to 
    /// enable highlightMouseDown to highlight when clicking on a slice.
    /// </summary>
    public bool? highlightMouseOver { get; set; }

    /// <summary>
    /// True to highlight when a mouse button is pressed over a bubble.  
    /// This will be disabled if highlightMouseOver is true.
    /// </summary>
    public bool? highlightMouseDown { get; set; }

    /// <summary>
    /// An array of colors to use when highlighting a slice.  Calculated 
    /// automatically if not supplied.
    /// </summary>
    public string[] highlightColors { get; set; }

    /// <summary>
    /// Alpha transparency to apply to all bubbles in this series.
    /// </summary>
    public double? bubbleAlpha { get; set; }

    /// <summary>
    /// Alpha transparency to apply when highlighting bubble.  Set to value
    /// of bubbleAlpha by default.
    /// </summary>
    public double? highlightAlpha { get; set; }

    /// <summary>
    /// True to color the bubbles with gradient fills instead of flat colors.  
    /// NOT AVAILABLE IN IE due to lack of excanvas support for radial gradient 
    /// fills. will be ignored in IE.
    /// </summary>
    public bool? bubbleGradients { get; set; }

    /// <summary>
    /// True to show labels on bubbles (if any), false to not show.
    /// </summary>
    public bool? showLabels { get; set; }
  }
}
