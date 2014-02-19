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

using System;
using System.Globalization;
using System.Web.Mvc;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Represents a bootstrap progress bar
  /// </summary>
  [Serializable]
  public class BootstrapProgressBar : HtmlElement
  {
    /// <summary>
    /// Percentage of completion for the progress bar
    /// </summary>
    public int Percent { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapProgressBar(int percent, object htmlAttributes = null)
      : this(EBootstrapProgressBar.Default, percent, htmlAttributes) { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Progress bar type</param>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapProgressBar(EBootstrapProgressBar type, int percent, object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      Percent = percent;
      this["class"] += "progress";

      Div inner = new Div();

      switch (WebExtrasMvcConstants.BootstrapVersion)
      {
        case EBootstrapVersion.None:
          throw new BootstrapVersionException();

        case EBootstrapVersion.V2:
          inner["class"] = string.Format("bar bar-{0}", type.ToString().ToLowerInvariant());
          break;

        case EBootstrapVersion.V3:
          inner["class"] = string.Format("progress-bar progress-bar-{0}", type.ToString().ToLowerInvariant());
          inner["role"] = "progressbar";
          inner["aria-valuenow"] = percent.ToString(CultureInfo.InvariantCulture);
          inner["aria-valuemin"] = "0";
          inner["aria-valuemax"] = "100";

          Span spanInner = new Span(percent + "% Complete");
          spanInner["class"] = "sr-only";

          inner.Append(spanInner);
          break;
      }

      Append(inner);

      //this.m_tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Converts current element to a MVC HTMl string with
    /// the given tag rendering mode
    /// </summary>
    /// <param name="renderMode">Tag render mode</param>
    /// <returns>MVC HTML string representation of the current element</returns>
    public override string ToHtmlString(TagRenderMode renderMode)
    {
      AppendTags[0].Attributes["style"] = string.Format("width: {0}%", Percent);

      return base.ToHtmlString(renderMode);
    }
  }
}
