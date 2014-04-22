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
using System.Collections.Generic;
using System.Linq;

namespace WebExtras.Mvc.JQueryUI
{
  /// <summary>
  /// JQuery UI date picker options
  /// </summary>
  [Serializable]
  public class DatePickerOptions
  {
    /// <summary>
    /// An input element that is to be updated with the selected date from the datepicker. 
    /// Use the "altFormat" option to change the format of the date within this field. 
    /// Leave as blank for no alternate field.
    /// </summary>
    public string altField { get; set; }

    /// <summary>
    /// The "dateFormat" to be used for the "altField" option. This allows one date format 
    /// to be shown to the user for selection purposes, while a different format is 
    /// actually sent behind the scenes. For a full list of the possible formats 
    /// see the "formatDate" function
    /// </summary>
    public string altFormat { get; set; }

    /// <summary>
    /// The text to display after each date field, e.g., to show the required format.
    /// </summary>
    public string appendText { get; set; }

    /// <summary>
    /// Set to true to automatically resize the input field to accommodate dates in 
    /// the current "dateFormat".
    /// </summary>
    public bool? autoSize { get; set; }

    /// <summary>
    /// A URL of an image to use to display the datepicker when the "showOn" option 
    /// is set to "button" or "both". If set, the "buttonText" option becomes the alt 
    /// value and is not directly displayed.
    /// </summary>
    public string buttonImage { get; set; }

    /// <summary>
    /// Whether the button image should be rendered by itself instead of inside a 
    /// button element. This option is only relevant if the "buttonImage" option has 
    /// also been set.
    /// </summary>
    public bool? buttonImageOnly { get; set; }

    /// <summary>
    /// The text to display on the trigger button. Use in conjunction with the "showOn"
    /// option set to "button" or "both".
    /// </summary>
    public string buttonText { get; set; }

    /// <summary>
    /// Whether the month should be rendered as a dropdown instead of text.
    /// </summary>
    public bool? changeMonth { get; set; }

    /// <summary>
    /// Whether the year should be rendered as a dropdown instead of text. Use the 
    /// "yearRange" option to control which years are made available for selection.
    /// </summary>
    public bool? changeYear { get; set; }

    /// <summary>
    /// The text to display for the close link. Use the "showButtonPanel" option to 
    /// display this button.
    /// </summary>
    public string closeText { get; set; }

    /// <summary>
    /// When true, entry in the input field is constrained to those characters 
    /// allowed by the current "dateFormat" option.
    /// </summary>
    public bool? constrainInput { get; set; }

    /// <summary>
    /// The text to display for the current day link. Use the "showButtonPanel" option 
    /// to display this button.
    /// </summary>
    public string currentText { get; set; }

    /// <summary>
    /// The format for parsed and displayed dates. For a full list of the possible 
    /// formats see the "formatDate" function.
    /// </summary>
    public string dateFormat { get; set; }

    /// <summary>
    /// The list of long day names, starting from Sunday, for use as requested via 
    /// the "dateFormat" option.
    /// </summary>
    public string[] dayNames { get; set; }

    /// <summary>
    /// The list of minimised day names, starting from Sunday, for use as column 
    /// headers within the datepicker.
    /// </summary>
    public string[] dayNamesMin { get; set; }

    /// <summary>
    /// The list of abbreviated day names, starting from Sunday, for use as 
    /// requested via the "dateFormat" option.
    /// </summary>
    public string[] dayNamesShort { get; set; }

    /// <summary>
    /// Set the date to highlight on first opening if the field is blank. Specify 
    /// either an actual date via a Date object or as a string in the current 
    /// "dateFormat", or a number of days from today (e.g. +7) or a string of 
    /// values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for 
    /// days, e.g. '+1m +7d'), or null for today.
    /// </summary>
    public object defaultDate { get; set; }

    /// <summary>
    /// Control the speed at which the datepicker appears, it may be a time in 
    /// milliseconds or a string representing one of the three predefined speeds 
    /// ("slow", "normal", "fast").
    /// </summary>
    public string duration { get; set; }

    /// <summary>
    /// Set the first day of the week: Sunday is 0, Monday is 1, etc.
    /// </summary>
    public int? firstDay { get; set; }

    /// <summary>
    /// When true, the current day link moves to the currently selected date 
    /// instead of today.
    /// </summary>
    public bool? gotoCurrent { get; set; }

    /// <summary>
    /// Normally the previous and next links are disabled when not applicable 
    /// (see the "minDate" and "maxDate" options). You can hide them altogether by 
    /// setting this attribute to true.
    /// </summary>
    public bool? hideIfNoPrevNext { get; set; }

    /// <summary>
    /// Whether the current language is drawn from right to left.
    /// </summary>
    public bool? isRTL { get; set; }

    /// <summary>
    /// The maximum selectable date. When set to null, there is no maximum. Can be
    /// a date containing maximum date, a number of days from today or a string in
    /// the format defined by the "dateFormat"
    /// </summary>
    public object maxDate { get; set; }

    /// <summary>
    /// The maximum selectable date. When set to null, there is no maximum. Can be
    /// a date containing minimum date, a number of days from today or a string in
    /// the format defined by the "dateFormat"
    /// </summary>
    public object minDate { get; set; }

    /// <summary>
    /// The list of full month names, for use as requested via the "dateFormat" option.
    /// </summary>
    public string[] monthNames { get; set; }

    /// <summary>
    /// The list of abbreviated month names, as used in the month header on each 
    /// datepicker and as requested via the dateFormat option.
    /// </summary>
    public string[] monthNamesShort { get; set; }

    /// <summary>
    /// Whether the "prevText" and "nextText" options should be parsed as dates by the 
    /// "formatDate" function, allowing them to display the target month names for example.
    /// </summary>
    public bool? navigationAsDateFormat { get; set; }

    /// <summary>
    /// The text to display for the next month link. With the standard ThemeRoller 
    /// styling, this value is replaced by an icon.
    /// </summary>
    public string nextText { get; set; }

    /// <summary>
    /// The text to display for the previous month link. With the standard ThemeRoller 
    /// styling, this value is replaced by an icon.
    /// </summary>
    public string prevText { get; set; }

    /// <summary>
    /// The number of months to show at once. The number of months to display in a 
    /// single row or an array defining the number of rows and columns
    /// </summary>
    public object numberOfMonths { get; set; }

    /// <summary>
    /// Whether days in other months shown before or after the current month are 
    /// selectable. This only applies if the "showOtherMonths" option is set to true.
    /// </summary>
    public bool? selectOtherMonths { get; set; }

    /// <summary>
    /// The cutoff year for determining the century for a date (used in conjunction 
    /// with dateFormat 'y'). Any dates entered with a year value less than or equal 
    /// to the cutoff year are considered to be in the current century, while those 
    /// greater than it are deemed to be in the previous century.
    /// </summary>
    public object shortYearCutoff { get; set; }

    /// <summary>
    /// The name of the animation used to show and hide the datepicker. Use "show" 
    /// (the default), "slideDown", "fadeIn", any of the jQuery UI effects. Set to 
    /// an empty string to disable animation.
    /// </summary>
    public bool? showAnim { get; set; }

    /// <summary>
    /// Whether to display a button pane underneath the calendar. The button pane 
    /// contains two buttons, a Today button that links to the current day, and a 
    /// Done button that closes the datepicker. The buttons' text can be customized 
    /// using the "currentText" and "closeText" options respectively.
    /// </summary>
    public bool? showButtonPanel { get; set; }

    /// <summary>
    /// When displaying multiple months via the "numberOfMonths" option, the 
    /// showCurrentAtPos option defines which position to display the current month in.
    /// </summary>
    public int? showCurrentAtPos { get; set; }

    /// <summary>
    /// Whether to show the month after the year in the header.
    /// </summary>
    public bool? showMonthAfterYear { get; set; }

    /// <summary>
    /// When the datepicker should appear. The datepicker can appear when the field 
    /// receives focus ("focus"), when a button is clicked ("button"), or when either 
    /// event occurs ("both").
    /// </summary>
    public string showOn { get; set; }

    /// <summary>
    /// If using one of the jQuery UI effects for the "showAnim" option, you can 
    /// provide additional settings for that animation via this option.
    /// </summary>
    public object showOptions { get; set; }

    /// <summary>
    /// Whether to display dates in other months (non-selectable) at the start or 
    /// end of the current month. To make these days selectable use the 
    /// "selectOtherMonths" option.
    /// </summary>
    public bool? showOtherMonths { get; set; }

    /// <summary>
    /// When true, a column is added to show the week of the year. The "calculateWeek" 
    /// option determines how the week of the year is calculated. You may also want 
    /// to change the "firstDay" option.
    /// </summary>
    public bool? showWeek { get; set; }

    /// <summary>
    /// Set how many months to move when clicking the previous/next links.
    /// </summary>
    public int? stepMonths { get; set; }

    /// <summary>
    /// The text to display for the week of the year column heading. Use the "showWeek" 
    /// option to display this column.
    /// </summary>
    public string weekHeader { get; set; }

    /// <summary>
    /// The range of years displayed in the year drop-down: either relative to today's 
    /// year ("-nn:+nn"), relative to the currently selected year ("c-nn:c+nn"), 
    /// absolute ("nnnn:nnnn"), or combinations of these formats ("nnnn:-nn"). Note 
    /// that this option only affects what appears in the drop-down, to restrict which 
    /// dates may be selected use the "minDate" and/or "maxDate" options.
    /// </summary>
    public string yearRange { get; set; }

    /// <summary>
    /// Additional text to display after the year in the month headers.
    /// </summary>
    public string yearSuffix { get; set; }

    /// <summary>
    /// Convert current date picker options to a dictionary
    /// </summary>
    /// <returns></returns>
    public IDictionary<string, object> ToDictionary()
    {
      return this.GetType()
        .GetProperties()
        .Where(f => f.GetValue(this, null) != null)
        .ToDictionary(k => k.Name, v => v.GetValue(this, null));
    }
  }
}
