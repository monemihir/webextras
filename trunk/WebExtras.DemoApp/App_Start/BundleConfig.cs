﻿/*
* This file is part of - WebExtras Demo application
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
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

#pragma warning disable 1591

using SquishIt.Framework;
using WebExtras.Core;

namespace WebExtras.DemoApp.App_Start
{
  /// <summary>
  /// Defines all CSS and JS bundles
  /// </summary>
  public class BundleConfig
  {
    /// <summary>
    /// Returns the CSS cache Url based on the given content bundle
    /// </summary>
    /// <param name="bundle">Content bundle</param>
    /// <returns>CSS cache Url</returns>
    public static string ResolveCssPath(ContentBundle bundle)
    {
      return string.Format("~/Assets/Css/{0}", bundle.GetStringValue());
    }

    /// <summary>
    /// Returns the JS cache Url based on the given content bundle
    /// </summary>
    /// <param name="bundle">Content bundle</param>
    /// <returns>JS cache Url</returns>
    public static string ResolveJsPath(ContentBundle bundle)
    {
      return string.Format("~/Assets/Js/{0}", bundle.GetStringValue());
    }

    /// <summary>
    /// Registers all bundles to be used across the website
    /// </summary>
    public static void RegisterBundles()
    {
      // Minimal CSS bundle
      Bundle.Css()
        .Add(Links.Content.webextras_css)
        .Add(Links.Content.style_css)
        .AsCached(ContentBundle.CSSMinimal.GetStringValue(), ResolveCssPath(ContentBundle.CSSMinimal));

      // CSS Bootstrap bundle
      Bundle.Css()
        .Add(Links.Content.bootstrap_2_3_1_css)
        .Add(Links.Content.font_awesome_css)
        .Add(Links.Content.bootstrap2_datetimepicker_20130514_css)
        .Add(Links.Content.jquery_dataTables_css)
        .Add(Links.Content.jquery_jScrollPane_2_0_0beta12_css)
        .Add(Links.Content.jquery_jqplot_min_css)
        .Add(Links.Content.webextras_bootstrap_css)
        .Add(Links.Content.style_bootstrap_css)
        .Add(Links.Content.style_css)
        .AsCached(ContentBundle.CSSBootstrap.GetStringValue(), ResolveCssPath(ContentBundle.CSSBootstrap));

      // CSS Bootstrap3 bundle
      Bundle.Css()
        .Add(Links.Content.bootstrap_3_0_0_css)
        //.Add(Links.Content.bootstrap_theme_3_0_0_css)
        .Add(Links.Content.font_awesome_css)
        .Add(Links.Content.bootstrap3_datetimepicker_4_7_14_css)
        .Add(Links.Content.jquery_dataTables_css)
        .Add(Links.Content.jquery_datatables_bootstrap3_css)
        .Add(Links.Content.jquery_jScrollPane_2_0_0beta12_css)
        .Add(Links.Content.webextras_common_css)
        .Add(Links.Content.webextras_bootstrap3_css)
        .Add(Links.Content.style_bootstrap3_css)
        .Add(Links.Content.style_css)
        .AsCached(ContentBundle.CSSBootstrap3.GetStringValue(), ResolveCssPath(ContentBundle.CSSBootstrap3));

      // CSS Gumby bundle
      Bundle.Css()
        .Add(Links.Content.gumby_2_5_6_css)
        .Add(Links.Content.jquery_dataTables_css)
        .Add(Links.Content.jquery_jScrollPane_2_0_0beta12_css)
        .Add(Links.Content.webextras_gumby_css)
        .Add(Links.Content.style_gumby_css)
        .Add(Links.Content.style_css)
        .AsCached(ContentBundle.CSSGumby.GetStringValue(), ResolveCssPath(ContentBundle.CSSGumby));

      // CSS JQuery UI bundle
      Bundle.Css()
        .Add(Links.Content.fluidable_min_css)
        .Add(Links.Content.jquery_ui_darkness_1_10_3_css)
        .Add(Links.Content.jquery_ui_menubar_css)
        .Add(Links.Content.jquery_ui_datetimepicker_css)
        .Add(Links.Content.jquery_dataTables_css)
        .Add(Links.Content.jquery_dataTables_jui_css)
        .Add(Links.Content.jquery_jScrollPane_2_0_0beta12_css)
        .Add(Links.Content.webextras_jqueryui_css)
        .Add(Links.Content.style_jqueryui_css)
        .Add(Links.Content.style_css)
        .AsCached(ContentBundle.CSSJQueryUI.GetStringValue(), ResolveCssPath(ContentBundle.CSSJQueryUI));

      // Core javascript libraries' bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.jquery_1_9_1_min_js)
        .Add(Links.Scripts.jquery_migrate_1_1_1_min_js)
        .Add(Links.Scripts.jquery_datatables_min_js)
        .Add(Links.Scripts.jquery_jScrollPane_2_0_0beta12_js)
        .Add(Links.Scripts.jquery_mousewheel_3_0_6_js)
        .Add(Links.Scripts.jquery_mwheelIntent_1_2_js)
        .AsCached(ContentBundle.JSBase.GetStringValue(), ResolveJsPath(ContentBundle.JSBase));

      // jQuery Flot bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.jquery_flot_min_js)
        .Add(Links.Scripts.jquery_flot_curvedlines_js)
        .Add(Links.Scripts.jquery_flot_dashes_js)
        .Add(Links.Scripts.jquery_flot_axislabels_js)
        .Add(Links.Scripts.jquery_flot_pie_min_js)
        .Add(Links.Scripts.jquery_flot_time_min_js)
        .AsCached(ContentBundle.JSFlot.GetStringValue(), ResolveJsPath(ContentBundle.JSFlot));

      // jqPlot bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.JQPlot.jqplot_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_json2_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_canvasAxisTickRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_canvasAxisLabelRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_canvasTextRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_categoryAxisRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_barRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_dateAxisRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_cursor_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_highlighter_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_ohlcRenderer_min_js)
        .Add(Links.Scripts.JQPlot.jqplot_pointLabels_min_js)
        .AsCached(ContentBundle.JSjqPlot.GetStringValue(), ResolveJsPath(ContentBundle.JSjqPlot));

      // Bootstrap javascript bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.bootstrap_2_3_1_min_js)
        .Add(Links.Scripts.jquery_datatables_bootstrap_js)
        .Add(Links.Scripts.bootstrap2_datetimepicker_20130514_min_js)
        .AsCached(ContentBundle.JSBootstrap.GetStringValue(), ResolveJsPath(ContentBundle.JSBootstrap));

      // Bootstrap3 javascript bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.bootstrap_3_0_0_min_js)
        .Add(Links.Scripts.moment_js)
        .Add(Links.Scripts.jquery_datatables_bootstrap3_js)
        .Add(Links.Scripts.bootstrap3_datetimepicker_4_0_0_js)
        .AsCached(ContentBundle.JSBootstrap3.GetStringValue(), ResolveJsPath(ContentBundle.JSBootstrap3));

      // Gumby javascript bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.modernizr_2_6_2_min_js)
        .Add(Links.Scripts.gumby_2_5_6_min_js)
        .AsCached(ContentBundle.JSGumby.GetStringValue(), ResolveJsPath(ContentBundle.JSGumby));

      // jQuery UI javascript bundle
      Bundle.JavaScript()
        .Add(Links.Scripts.jquery_ui_1_10_3_custom_min_js)
        .Add(Links.Scripts.jquery_ui_menubar_js)
        .Add(Links.Scripts.jquery_ui_datetimepicker_1_4_4_js)
        .AsCached(ContentBundle.JSJQueryUI.GetStringValue(), ResolveJsPath(ContentBundle.JSJQueryUI));
    }
  }
}