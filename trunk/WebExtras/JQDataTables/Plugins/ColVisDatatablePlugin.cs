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
using WebExtras.Core;

namespace WebExtras.JQDataTables.Plugins
{
  /// <summary>
  ///   ColVis plugin
  /// </summary>
  [Serializable]
  public class ColVisDatatablePlugin : AbstractDatatablePlugin
  {
    /// <summary>
    ///   This parameter denotes how the dropdown list of columns can be activated by the end user. Its value should be either
    ///   "mouseover" or "click".
    /// </summary>
    public string activate;

    /// <summary>
    ///   This array contains the column indexes which you wish to exclude from the list of columns in the dropdown list,
    ///   effectively meaning that the end user has no control over the visibility of those columns. As well as indexes, this
    ///   array can also contain the string 'all' which indicates that all columns should be excluded from the list. This is
    ///   useful when using ColVis' grouping buttons feature.
    /// </summary>
    public int[] aiExclude;

    /// <summary>
    ///   Include a "restore" button in the column list. The restore button provides an additional button which when activated
    ///   causes the column visibility to return to what it was when DataTables was initialised.
    /// </summary>
    public bool? bRestore;

    /// <summary>
    ///   The text that will be used in the button.
    /// </summary>
    public string buttonText;

    /// <summary>
    ///   Allows customisation of the labels used for the buttons (useful for stripping HTML for example).
    /// </summary>
    public JsFunc fnLabel;

    /// <summary>
    ///   Callback function to let you know when the state has changed.
    /// </summary>
    public JsFunc fnStateChange;

    /// <summary>
    ///   Define buttons that toggle groups of columns.
    /// </summary>
    public ColVisButtonGroup[] groups;

    /// <summary>
    ///   Alter the duration used for the fade in / out animation of the column visibility buttons when the control button is
    ///   clicked on. The value of the parameter is interpreted as milliseconds. Defaults to 500
    /// </summary>
    public int? iOverlayFade;

    /// <summary>
    ///   This parameter provides the ability to specify which edge of the control button the drop down column visibility list
    ///   should align to - either "left" or "right".
    /// </summary>
    public string sAlign;

    /// <summary>
    ///   This parameter is used to enable a button that, when selected, will show all columns in the table. The value given is
    ///   used as the button's display text.
    /// </summary>
    public string showAll;

    /// <summary>
    ///   This parameter is used to enable a button that, when selected, will hide all columns in the table. The value given is
    ///   used as the button's display text.
    /// </summary>
    public string showNone;

    /// <summary>
    ///   This parameter provides the ability to customise the text for the restore button. Note that when using camelCase
    ///   style, if this parameter is defined, it is assumed that the restore button should be shown.
    /// </summary>
    public string sRestore;

    /// <summary>
    ///   Constructor
    /// </summary>
    public ColVisDatatablePlugin()
      : base("oColVis")
    {
      // nothing to do here
    }
  }
}