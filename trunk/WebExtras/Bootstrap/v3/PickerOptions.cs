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

namespace WebExtras.Bootstrap.v3
{
  /// <summary>
  ///   Date time picker options
  /// </summary>
  [Serializable]
  public class PickerOptions
  {
    /// <summary>
    ///   If true, the picker will show on textbox focus and icon click when used in a button group
    /// </summary>
    public bool? allowInputToggle;

    /// <summary>
    ///   Shows the week of the year to the left of first day of the week.
    /// </summary>
    public bool? calendarWeeks;

    /// <summary>
    ///   Using a Bootstraps collapse to switch between date/time pickers.
    /// </summary>
    public bool? collapse;

    /// <summary>
    ///   Disables the section of days of the week, e.g. weekends.
    /// </summary>
    public int[] daysOfWeekDisabled;

    /// <summary>
    ///   Changes the heading of the datepicker when in "days" view.
    /// </summary>
    public string dayViewHeaderFormat;

    // "keyBinds" option has not been migrated

    /// <summary>
    ///   Will cause the date picker to stay open after a blur event.
    /// </summary>
    public bool? debug;

    /// <summary>
    ///   Sets the picker default date/time. Overrides useCurrent
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))] public DateTime? defaultDate;

    /// <summary>
    ///   Disables selection of dates in the array, e.g. holidays
    /// </summary>
    public DateTime[] disabledDates;

    /// <summary>
    ///   Will allow or disallow hour selections (much like <see cref="M:disabledTimeIntervals" />) but will affect all days
    /// </summary>
    public bool? disabledHours;

    /// <summary>
    ///   Disables time selection between the given moments
    /// </summary>
    public bool? disabledTimeIntervals;

    /// <summary>
    ///   Disables selection of dates NOT in the array, e.g. holidays
    /// </summary>
    public DateTime[] enabledDates;

    /// <summary>
    ///   Will allow or disallow hour selections (much like <see cref="M:disabledTimeIntervals" />) but will affect all days
    /// </summary>
    public bool? enabledHours;

    /// <summary>
    ///   Allows for several input formats to be valid. See this
    ///   <see cref="http://github.com/Eonasdan/bootstrap-datetimepicker/pull/666" />.
    /// </summary>
    public string extraFormats;

    /// <summary>
    ///   If false, the textbox will not be given focus when the picker is shown
    /// </summary>
    public bool? focusOnShow;

    /// <summary>
    ///   Date time text format. See momentjs' docs (<see cref="http://momentjs.com/docs/#/displaying/format/" />) for valid
    ///   formats. Format also
    ///   dictates what components are show, e.g. MM/dd/YYYY will not diplay the time picker.
    /// </summary>
    public string format;

    /// <summary>
    ///   Change the default icons for the pickers functions.
    /// </summary>
    public IconOptions icons;

    /// <summary>
    ///   Will display the picker inline without the need of a input field. This will also hide borders and shadows.
    /// </summary>
    public bool? inline;

    /// <summary>
    ///   Will cause the date picker to not revert or overwrite invalid dates.
    /// </summary>
    public bool? keepInvalid;

    /// <summary>
    ///   Will cause the date picker to stay open after selecting a date if no time components are being used.
    /// </summary>
    public bool? keepOpen;

    /// <summary>
    ///   See momentjs (<see cref="http://github.com/moment/moment/tree/develop/locale" />) for valid locales.
    ///   You must include moment-with-locales.js or a local js file.
    /// </summary>
    public string locale;

    /// <summary>
    ///   Prevents date/time selections after this date
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))] public DateTime? maxDate;

    /// <summary>
    ///   Prevents date/time selections before this date
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))] public DateTime? minDate;

    /// <summary>
    ///   Show the "Clear" button in the icon toolbar.
    ///   Clicking the "Clear" button will set the calendar to null
    /// </summary>
    public bool? showClear;

    /// <summary>
    ///   Show the "Close" button in the icon toolbar.
    ///   Clicking the "Close" button will call hide()
    /// </summary>
    public bool? showClose;

    /// <summary>
    ///   Show the "Today" button in the icon toolbar.
    ///   Clicking the "Today" button will set the calendar view and set the date to now.
    /// </summary>
    public bool? showTodayButton;

    /// <summary>
    ///   Shows the picker side by side when using the time and date together.
    /// </summary>
    public bool? sideBySide;

    /// <summary>
    ///   Number of minutes the up/down arrow's will move the minutes value in the time picker
    /// </summary>
    public int? stepping;

    /// <summary>
    ///   Changes the placement of the icon toolbar. Accepts: 'default', 'top', 'bottom'
    /// </summary>
    public string toolbarPlacement;

    /// <summary>
    ///   On show, will set the picker to the current date/time
    /// </summary>
    public bool? useCurrent;

    /// <summary>
    ///   Defines if moment should use strict date parsing when considering a date to be valid
    /// </summary>
    public bool? useStrict;

    /// <summary>
    ///   This will change the viewDate without changing or setting the selected date.
    /// </summary>
    public bool? viewDate;

    /// <summary>
    ///   The default view to display when the picker is shown.
    ///   Note: To limit the picker to selecting, for instance the year and month, use format: MM/YYYY
    /// </summary>
    public string viewMode;

    /// <summary>
    ///   On picker show, places the widget at the identifier (string) if the element has css position: 'relative'
    /// </summary>
    public string widgetParent;

    /// <summary>
    ///   Controls where the widget is placed
    /// </summary>
    public PositionOptions widgetPositioning;

    /// <summary>
    ///   Constructor
    /// </summary>
    public PickerOptions()
    {
      format = "YYYY-MM-DD HH:mm:ss";
    }

    /// <summary>
    ///   Tries to use font awesome icons by inspecting <see cref="M:WebExtrasConstants.FontAwesomeVersion" />
    /// </summary>
    /// <returns>Updated picker options</returns>
    public PickerOptions TryFontAwesomeIcons()
    {
      switch (WebExtrasConstants.FontAwesomeVersion)
      {
        case EFontAwesomeVersion.V4:
          icons = new IconOptions
          {
            time = "fa fa-clock-o",
            date = "fa fa-calendar",
            up = "fa fa-arrow-up",
            down = "fa fa-arrow-down",
            previous = "fa fa-arrow-left",
            next = "fa fa-arrow-right",
            clear = "fa fa-trash",
            today = "fa fa-crosshairs"
          };
          break;

        case EFontAwesomeVersion.V3:
          icons = new IconOptions
          {
            time = "icon-time",
            date = "icon-calendar",
            up = "icon-arrow-up",
            down = "icon-arrow-down",
            previous = "icon-arrow-left",
            next = "icon-arrow-right",
            clear = "icon-trash",
            today = "icon-screenshot"
          };
          break;
      }

      return this;
    }
  }
}

#pragma warning restore 1584,1658