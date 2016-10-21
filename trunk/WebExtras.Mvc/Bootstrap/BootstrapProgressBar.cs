// 
// This file is part of - WebExtras
// Copyright 2016 Mihir Mone
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Globalization;
using System.Web.Mvc;
using WebExtras.Bootstrap;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  ///   Represents a bootstrap progress bar
  /// </summary>
  [Serializable]
  public class BootstrapProgressBar : HtmlElement
  {
    /// <summary>
    ///   Percentage of completion for the progress bar
    /// </summary>
    public int Percent { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapProgressBar(int percent, object htmlAttributes = null)
      : this(EBootstrapProgressBar.Default, percent, string.Empty, htmlAttributes)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="type">Progress bar type</param>
    /// <param name="percent">Percentage of completion for the progress bar</param>
    /// <param name="srText">[Optional] Custom text to be displayed in progress bar. Defaults to percentage complete</param>
    /// <param name="htmlAttributes">[Optional] Extra HTML attributes</param>
    public BootstrapProgressBar(EBootstrapProgressBar type, int percent, string srText = null,
      object htmlAttributes = null)
      : base(EHtmlTag.Div, htmlAttributes)
    {
      Percent = percent;
      this["class"] += "progress";

      Div inner = new Div();

      switch (WebExtrasSettings.BootstrapVersion)
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

          Span spanInner = new Span(string.IsNullOrWhiteSpace(srText) ? percent + "% Complete" : srText);
          spanInner["class"] = "sr-only";

          inner.Append(spanInner);
          break;
      }

      Append(inner);

      //this.m_tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    ///   Converts current element to a MVC HTMl string with
    ///   the given tag rendering mode
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