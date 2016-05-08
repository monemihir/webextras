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

using Newtonsoft.Json;
using WebExtras.Component;
using WebExtras.Core;

namespace WebExtras.Bootstrap.v3
{
  /// <summary>
  ///   Denotes a Bootstrap 3 date time picker component
  /// </summary>
  public class DateTimePickerHtmlComponent : HtmlComponent
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="name">HTML field name</param>
    /// <param name="id">HTML field id</param>
    /// <param name="options">Date time picker options</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    public DateTimePickerHtmlComponent(string name, string id, PickerOptions options, object htmlAttributes)
      : base(EHtmlTag.Div)
    {
      PickerOptions pickerOptions =
        (options ?? BootstrapConstants.DateTimePickerOptions).TryFontAwesomeIcons();

      string fieldId = id;
      string fieldName = name;

      // create the text box
      HtmlComponent input = new HtmlComponent(EHtmlTag.Input);
      var attribs = WebExtrasUtil.AnonymousObjectToHtmlAttributes(htmlAttributes).ToDictionary();

      input.Attributes.Add(attribs);
      input.Attributes["type"] = "text";
      input.Attributes["name"] = fieldName;

      if (input.Attributes.ContainsKey("class"))
        input.Attributes["class"] += " form-control";
      else
        input.Attributes["class"] = "form-control";

      // create icon
      HtmlComponent icons = new HtmlComponent(EHtmlTag.I);

      if (WebExtrasConstants.FontAwesomeVersion == EFontAwesomeVersion.V4)
        icons.CssClasses.Add("fa fa-calendar");
      else if (WebExtrasConstants.FontAwesomeVersion == EFontAwesomeVersion.V3)
        icons.CssClasses.Add("icon-calendar");
      else
        icons.CssClasses.Add("glyphicon glyphicon-calendar");

      // create addon
      HtmlComponent addOn = new HtmlComponent(EHtmlTag.Span);
      addOn.CssClasses.Add("input-group-addon");
      addOn.AppendTags.Add(icons);

      // create JSON dictionary of the picker options
      string op = pickerOptions.ToJson(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

      HtmlComponent script = new HtmlComponent(EHtmlTag.Script);
      script.Attributes["type"] = "text/javascript";
      script.InnerHtml = "$(function(){ $('#" + fieldId + "').datetimepicker(" + op + "); });";

      // setup up datetime picker
      Attributes["id"] = fieldId;
      Attributes["class"] = "input-group date";
      AppendTags.Add(input);
      AppendTags.Add(addOn);
      AppendTags.Add(script);
    }
  }
}