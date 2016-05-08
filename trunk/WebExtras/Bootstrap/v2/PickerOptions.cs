// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Newtonsoft.Json;
using WebExtras.Core;

// ReSharper disable InconsistentNaming

#pragma warning disable 1584,1658

namespace WebExtras.Bootstrap.v2
{
  /// <summary>
  ///   Date time picker options
  /// </summary>
  [Serializable]
  public class PickerOptions
  {
    /// <summary>
    ///   Date time text format. ISO 8601 format: yyyy-mm-ddThh:ii:ssZ. Note: We ise 'i' for minutes
    ///   and 'm' for month
    /// </summary>
    public string format;

    /// <summary>
    ///   Day of the week start. 0 (Sunday) to 6 (Saturday)
    /// </summary>
    public int? weekStart;

    /// <summary>
    ///   The earliest date that may be selected; all earlier dates will be disabled.
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))] public DateTime? startDate;

    /// <summary>
    ///   The latest date that may be selected; all later dates will be disabled.
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))] public DateTime? endDate;

    /// <summary>
    ///   Days of the week that should be disabled. Values are 0 (Sunday) to 6 (Saturday).
    /// </summary>
    public int[] daysOfWeekDisabled;

    /// <summary>
    ///   Whether or not to close the datetimepicker immediately when a date is selected.
    /// </summary>
    public bool? autoClose;

    /// <summary>
    ///   The view that the datetimepicker should show when it is opened. Accepts 'hour',
    ///   'day', 'month', 'year', 'decade'
    /// </summary>
    public string startView;

    /// <summary>
    ///   The lowest view that the datetimepicker should show. Accepts 'hour',
    ///   'day', 'month', 'year', 'decade'
    /// </summary>
    public string minView;

    /// <summary>
    ///   The higest view that the datetimepicker should show. Accepts 'hour',
    ///   'day', 'month', 'year', 'decade'
    /// </summary>
    public string maxView;

    /// <summary>
    ///   If true, displays a "Today" button at the bottom of the datetimepicker
    ///   to select the current date. If true, the "Today" button will only move
    ///   the current date into view
    /// </summary>
    public bool? todayBtn;

    /// <summary>
    ///   If true, highlights the current date.
    /// </summary>
    public bool? todayHighlight;

    /// <summary>
    ///   Whether or not to allow date navigation by arrow keys.
    /// </summary>
    public bool? keyboardNavigation;

    /// <summary>
    ///   The two-letter code of the language to use for month and day names.
    ///   These will also be used as the input's value (and subsequently sent
    ///   to the server in the case of form submissions). Currently ships with
    ///   English ('en'), German ('de'), Brazilian ('br'), and Spanish ('es')
    ///   translations, but others can be added (see I18N below). If an unknown
    ///   language code is given, English will be used.
    /// </summary>
    public string language;

    /// <summary>
    ///   Whether or not to force parsing of the input value when the picker
    ///   is closed. That is, when an invalid date is left in the input field
    ///   by the user, the picker will forcibly parse that value, and set the
    ///   input's value to the new, valid date, conforming to the given <see cref="M:format" />.
    /// </summary>
    public bool? forceParse;

    /// <summary>
    ///   The increment used to build the hour view. A preset is created for each minuteStep minutes.
    /// </summary>
    public int? minuteStep;

    /// <summary>
    ///   This option is currently only available in the component implementation.
    ///   With it you can place the picker just under the input field. Accepts
    ///   'bottom-right' and 'bottom-left'
    /// </summary>
    public string pickerPosition;

    /// <summary>
    ///   With this option you can select the view from which the date will be selected.
    ///   By default it's the last one, however you can choose the first one, so at each
    ///   click the date will be updated. Accepts 'hour', 'day', 'month', 'year', 'decade'
    /// </summary>
    public string viewSelect;

    /// <summary>
    ///   This option will enable meridian views for day and hour views.
    /// </summary>
    public bool? showMeridian;

    /// <summary>
    ///   You can initialize the viewer with a date. By default it's now, so you can
    ///   specify yesterday or today at midnight ...
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))] public DateTime? initialDate;

    /// <summary>
    ///   How the picker should operate
    /// </summary>
    [JsonIgnore] public EPickerView View;

    /// <summary>
    ///   Constructor
    /// </summary>
    public PickerOptions()
    {
      format = "yyyy-mm-dd hh:ii:ss";
      View = EPickerView.DateTime;
      autoClose = true;
      pickerPosition = "bottom-left";
    }

    /// <summary>
    ///   Updates picker options based on the view selected
    /// </summary>
    /// <returns>Updated picker options</returns>
    public PickerOptions UpdateOptionsBasedOnView()
    {
      switch (View)
      {
        case EPickerView.Date:
          minView = "month";
          break;

        case EPickerView.Time:
          maxView = "hour";
          startView = "day";
          break;
      }

      return this;
    }
  }
}

#pragma warning restore 1584,1658