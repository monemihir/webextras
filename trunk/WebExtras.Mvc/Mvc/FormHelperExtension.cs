/*
* This file is part of - Code Library
* Copyright (C) 2013 Mihir Mone
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
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using WebExtras.Html;

namespace WebExtras.Mvc.Mvc
{
  /// <summary>
  /// Form helper extension methods
  /// </summary>
  public static class FormHelperExtension
  {
    #region Button extensions

    /// <summary>
    /// Create a HTML Button control
    /// </summary>
    /// <param name="html">Current HTMLHelper object</param>
    /// <param name="type">Type of the button control. Valid values are 'regular',
    /// 'submit', 'reset'</param>
    /// <param name="cssClass">CSS class</param>
    /// <param name="id">ID</param>
    /// <param name="value">Value text to display on button</param>
    /// <param name="onClick">[Optional] Javascript onClick event name. Defaults to null. Note. If button type is 'Submit' or
    /// 'Reset' this onclick event will be ignored and can be null</param>
    /// <param name="htmlAttributes">[Optional] Additional html attributes to apply to the link (BUTTON) object</param>
    /// <returns>HTML Button</returns>
    public static MvcHtmlString Button(
      this HtmlHelper html,
      ButtonOfType type,
      string cssClass,
      string id,
      string value,
      string onClick = null,
      object htmlAttributes = (IDictionary<string, object>)null)
    {
      string autogenId = string.Format("autogen-{0}", new Random(DateTime.Now.Millisecond).Next(1, 9999).ToString());
      TagBuilder button = new TagBuilder("button");
      button.Attributes["id"] = string.IsNullOrEmpty(id) ? autogenId : id;
      button.InnerHtml = value;

      if (!string.IsNullOrEmpty(cssClass))
        button.AddCssClass(cssClass);
      button.Attributes["type"] = (type == ButtonOfType.Regular) ? "button" : type.ToString().ToLower();

      if (!string.IsNullOrEmpty(onClick))
        button.Attributes["onclick"] = "javascript:" + onClick;

      button.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      return MvcHtmlString.Create(button.ToString(TagRenderMode.Normal));
    }

    #endregion Button extensions

    #region IconButton extensions

    /// <summary>
    /// Create a HTML Button control with an icon
    /// </summary>
    /// <param name="html">Current HTMLHelper object</param>
    /// <param name="type">Type of the button control. Valid values are 'regular',
    /// 'submit', 'reset'</param>
    /// <param name="cssClass">CSS class</param>
    /// <param name="id">ID</param>
    /// <param name="value">Value text to display on button</param>
    /// <param name="iconClass">Icon CSS class(s) to be prepended for the link. Multiple icon classes must be separated with
    /// spaces</param>
    /// <param name="onClick">[Optional] Javascript onClick event name. Defaults to null. Note. If button type is 'Submit' or
    /// 'Reset' this onclick event will be ignored and can be null</param>
    /// <param name="htmlAttributes">[Optional] Additional html attributes to apply to the link (BUTTON) object</param>
    /// <returns>HTML Button</returns>
    public static MvcHtmlString IconButton(
      this HtmlHelper html,
      ButtonOfType type,
      string cssClass,
      string id,
      string value,
      string iconClass,
      string onClick = null,
      object htmlAttributes = (IDictionary<string, object>)null)
    {
      string autogenId = string.Format("autogen-{0}", new Random(DateTime.Now.Millisecond).Next(1, 9999).ToString());
      TagBuilder button = new TagBuilder("button");
      button.Attributes["id"] = string.IsNullOrEmpty(id) ? autogenId : id;
      button.InnerHtml = string.Format("<i class='{0}'></i>{1}", iconClass, value);
      onClick = (!string.IsNullOrEmpty(onClick) && onClick.EndsWith("()")) ? onClick : onClick + "()";
      if (!string.IsNullOrEmpty(cssClass))
        button.AddCssClass(cssClass);
      button.Attributes["type"] = (type == ButtonOfType.Regular) ? "button" : type.ToString().ToLower();
      if (type == ButtonOfType.Regular)
        button.Attributes["onclick"] = "javascript:" + onClick;

      button.MergeAttributes<string, object>((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes));

      return MvcHtmlString.Create(button.ToString(TagRenderMode.Normal));
    }

    #endregion IconButton extensions

    #region CheckBoxList extensions

    /// <summary>
    /// Create a CheckBox list
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="name">Name of checkbox list</param>
    /// <param name="listInfo">List of CheckBox controls</param>
    /// <param name="boxesPerLine">Number of checkboxes per line</param>
    /// <returns>String representation of a checkbox list</returns>
    public static MvcHtmlString CheckBoxList(
      this HtmlHelper htmlHelper,
      string name,
      List<CheckBox> listInfo,
      int boxesPerLine)
    {
      return htmlHelper.CheckBoxList(name, listInfo, boxesPerLine,
          ((IDictionary<string, object>)null));
    }

    /// <summary>
    /// Create a CheckBox list with extra HTML attributes
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="name">Name of checkbox list</param>
    /// <param name="listInfo">List of CheckBox controls</param>
    /// <param name="boxesPerLine">Number of checkboxes per line</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>String representation of a checkbox list</returns>
    public static MvcHtmlString CheckBoxList(
      this HtmlHelper htmlHelper,
      string name,
      List<CheckBox> listInfo,
      int boxesPerLine,
      object htmlAttributes)
    {
      return htmlHelper.CheckBoxList(name, listInfo, boxesPerLine,
          ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
    }

    /// <summary>
    /// Create a CheckBox list with extra HTML attributes
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="name">Name of checkbox list</param>
    /// <param name="listInfo">List of CheckBox controls</param>
    /// <param name="boxesPerLine">Number of checkboxes per line</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>String representation of a checkbox list</returns>
    public static MvcHtmlString CheckBoxList(
      this HtmlHelper htmlHelper,
      string name,
      List<CheckBox> listInfo,
      int boxesPerLine,
      IDictionary<string, object> htmlAttributes)
    {
      if (String.IsNullOrEmpty(name))
        throw new ArgumentException("The argument must have a value", "name");
      if (listInfo == null)
        throw new ArgumentNullException("listInfo");
      if (!listInfo.Any())
        throw new ArgumentException("The list must contain at least one value", "listInfo");

      StringBuilder sb = new StringBuilder();

      // Create a table
      TagBuilder tbl = new TagBuilder("table");
      tbl.Attributes["width"] = "100%";
      int index = 0;
      while (true)
      {
        // Create a new table row
        TagBuilder row = new TagBuilder("tr");
        for (int j = 0; j < boxesPerLine && index < listInfo.Count; j++, index++)
        {
          // Create a new table cell
          TagBuilder cell = new TagBuilder("td");
          cell.AddCssClass("display-field");

          // Loop until either number of boxes available finishes or
          // number of boxes per line are added
          CheckBox box = listInfo[index];

          TagBuilder chkbox = new TagBuilder("input");
          if (box.IsChecked)
            chkbox.MergeAttribute("checked", "checked");
          if (!box.IsEnabled)
            chkbox.MergeAttribute("disabled", "");
          chkbox.MergeAttributes<string, object>(htmlAttributes);
          chkbox.MergeAttribute("type", "checkbox");
          chkbox.MergeAttribute("value", box.Value);
          chkbox.MergeAttribute("name", name);

          TagBuilder span = new TagBuilder("span");
          span.SetInnerText(" " + box.DisplayText);
          span.MergeAttribute("id", string.Format("{0}-{1}", name, box.Value));

          // Append the checkbox to the table cell
          cell.InnerHtml = chkbox.ToString(TagRenderMode.SelfClosing) + span.ToString(TagRenderMode.Normal);

          // Append the table cell to the table row
          row.InnerHtml += cell.ToString(TagRenderMode.Normal);
        }

        // Append table row to the table
        tbl.InnerHtml += row.ToString(TagRenderMode.Normal);
        if (index >= listInfo.Count)
        {
          break;
        }
      }

      sb.Append(tbl.ToString(TagRenderMode.Normal));
      return MvcHtmlString.Create(sb.ToString());
    }

    #endregion CheckBoxList extensions

    #region RadioButtonList extensions

    /// <summary>
    /// Create a RadioButton list with the given name and
    /// list of items.
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="name">Name of the radio button list</param>
    /// <param name="selectList">List of radio buttons</param>
    /// <returns>String representation of a RadioButton list</returns>
    public static MvcHtmlString RadioButtonList(
      this HtmlHelper htmlHelper,
      string name,
      IEnumerable<SelectListItem> selectList)
    {
      return RadioButtonList(htmlHelper, name, selectList,
        ((IDictionary<string, object>)null));
    }

    /// <summary>
    /// Create a RadioButton list with the given name and
    /// list of items.
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="name">Name of the radio button list</param>
    /// <param name="selectList">List of radio buttons</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>String representation of a RadioButton list</returns>
    public static MvcHtmlString RadioButtonList(
      this HtmlHelper htmlHelper,
      string name,
      IEnumerable<SelectListItem> selectList,
      object htmlAttributes)
    {
      return RadioButtonList(htmlHelper, name, selectList,
        ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
    }

    /// <summary>
    /// Create a RadioButton list with the given name and
    /// list of items.
    /// </summary>
    /// <param name="htmlHelper">Current HTMLHelper object</param>
    /// <param name="name">Name of the radio button list</param>
    /// <param name="selectList">List of radio buttons</param>
    /// <param name="htmlAttributes">Extra HTML attributes</param>
    /// <returns>String representation of a RadioButton list</returns>
    public static MvcHtmlString RadioButtonList(
      this HtmlHelper htmlHelper,
      string name,
      IEnumerable<SelectListItem> selectList,
      IDictionary<string, object> htmlAttributes)
    {
      List<string> radioButtons = new List<string>();

      foreach (SelectListItem item in selectList)
      {
        TagBuilder radioBtn = new TagBuilder("input");
        radioBtn.Attributes["type"] = "radio";
        radioBtn.Attributes["name"] = name;
        if (item.Selected)
          radioBtn.Attributes["checked"] = "checked";
        radioBtn.Attributes["value"] = item.Value.ToString();
        radioBtn.MergeAttributes<string, object>(htmlAttributes);
        radioButtons.Add(radioBtn.ToString(TagRenderMode.SelfClosing) + " " + item.Text);
      }

      return MvcHtmlString.Create(string.Join("&nbsp;&nbsp;", radioButtons.ToArray()));
    }

    #endregion RadioButtonList extensions
  }
}