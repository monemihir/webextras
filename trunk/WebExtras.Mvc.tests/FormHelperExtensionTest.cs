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

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Core;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests
{
  /// <summary>
  /// FormHelperExtension unit tests
  /// </summary>
  [TestClass]
  public class FormHelperExtensionTest
  {
    private HtmlHelper m_html;
    private IEnumerable<CheckBox> m_checkBoxes;
    private IEnumerable<RadioButton> m_radioBtns;

    #region Button tests

    /// <summary>
    /// Test that the Button method with no 'onclick' event
    /// returns expected results
    /// </summary>
    [TestMethod]
    public void Button_Without_OnClick_Test()
    {
      // Arrange
      const string expected = "<button title=\"test title\" class=\"test-css-class\" type=\"button\">Test Button</button>";

      // Act
      Button result = FormHelperExtension.Button(
        m_html,
        EButton.Regular,
        "Test Button",
        new { title = "test title", @class = "test-css-class" });

      // Assert
      Assert.AreEqual(expected, result.ToHtmlString());
    }

    /// <summary>
    /// Test that the Button method with an 'onclick' event
    /// returns expected results
    /// </summary>
    [TestMethod]
    public void Button_With_OnClick_Test()
    {
      // Arrange
      const string expected = "<button title=\"test title\" class=\"test-css-class\" type=\"submit\" onclick=\"javascript:callTestFunc()\">Test Button</button>";

      // Act
      Button result = FormHelperExtension.Button(
        m_html,
        EButton.Submit,
        "Test Button",
        "callTestFunc()",
        new { title = "test title", @class = "test-css-class" });

      // Assert
      Assert.AreEqual(expected, result.ToHtmlString());
    }

    #endregion Button tests

    #region CheckBoxGroup tests

    /// <summary>
    /// Test that the CheckBoxGroup method with default no. of boxes
    /// per line returns expected results
    /// </summary>
    [TestMethod]
    public void CheckBoxGroup_Without_NumBoxesPerLine_Test()
    {
      // Arrange
      const string expected = "<table class=\"checkbox-group\" title=\"check box group\"><tr><td><input type=\"checkbox\" value=\"val 1\" name=\"test-chkbox-group\"/> box 1</td>\n<td><input type=\"checkbox\" value=\"val 2\" name=\"test-chkbox-group\"/> box 2</td>\n<td><input type=\"checkbox\" value=\"val 3\" name=\"test-chkbox-group\"/> box 3</td>\n<td><input type=\"checkbox\" value=\"val 4\" name=\"test-chkbox-group\"/> box 4</td>\n<td><input type=\"checkbox\" value=\"val 5\" name=\"test-chkbox-group\"/> box 5</td>\n</tr>\n<tr><td><input type=\"checkbox\" value=\"val 6\" name=\"test-chkbox-group\"/> box 6</td>\n<td><input type=\"checkbox\" value=\"val 7\" name=\"test-chkbox-group\"/> box 7</td>\n<td><input type=\"checkbox\" value=\"val 8\" name=\"test-chkbox-group\"/> box 8</td>\n<td><input type=\"checkbox\" value=\"val 9\" name=\"test-chkbox-group\"/> box 9</td>\n<td><input type=\"checkbox\" value=\"val 10\" name=\"test-chkbox-group\"/> box 10</td>\n</tr>\n</table>";

      // Act
      string result = FormHelperExtension.CheckBoxGroup(
        m_html,
        "test-chkbox-group",
        m_checkBoxes,
        new { title = "check box group" }).ToHtmlString();

      // assert
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test that the CheckBoxGroup method with a no. of boxes
    /// per line specified returns expected results
    /// </summary>
    [TestMethod]
    public void CheckBoxGroup_With_NumBoxesPerLine_Test()
    {
      // Arrange
      const string expected = "<table class=\"checkbox-group\" title=\"check box group\"><tr><td><input type=\"checkbox\" value=\"val 1\" name=\"test-chkbox-group\"/> box 1</td>\n<td><input type=\"checkbox\" value=\"val 2\" name=\"test-chkbox-group\"/> box 2</td>\n<td><input type=\"checkbox\" value=\"val 3\" name=\"test-chkbox-group\"/> box 3</td>\n</tr>\n<tr><td><input type=\"checkbox\" value=\"val 4\" name=\"test-chkbox-group\"/> box 4</td>\n<td><input type=\"checkbox\" value=\"val 5\" name=\"test-chkbox-group\"/> box 5</td>\n<td><input type=\"checkbox\" value=\"val 6\" name=\"test-chkbox-group\"/> box 6</td>\n</tr>\n<tr><td><input type=\"checkbox\" value=\"val 7\" name=\"test-chkbox-group\"/> box 7</td>\n<td><input type=\"checkbox\" value=\"val 8\" name=\"test-chkbox-group\"/> box 8</td>\n<td><input type=\"checkbox\" value=\"val 9\" name=\"test-chkbox-group\"/> box 9</td>\n</tr>\n<tr><td><input type=\"checkbox\" value=\"val 10\" name=\"test-chkbox-group\"/> box 10</td>\n</tr>\n</table>";

      // Act
      string result = FormHelperExtension.CheckBoxGroup(
        m_html,
        "test-chkbox-group",
        m_checkBoxes,
        3,
        new { title = "check box group" }).ToHtmlString();

      // assert
      Assert.AreEqual(expected, result);
    }

    #endregion CheckBoxGroup tests

    #region RadioButtonGroup tests

    /// <summary>
    /// Test that the RadioButtonGroup method with no. of buttons
    /// not specified returns expected results
    /// </summary>
    [TestMethod]
    public void RadioButtonGroup_Without_NumButtonsPerLine_Test()
    {
      // arrange
      const string expected = "<table class=\"radiobutton-group\" title=\"radio button group\"><tr><td><input type=\"radio\" value=\"val 1\" name=\"test-radio-group\"/> rbtn 1</td>\n<td><input type=\"radio\" value=\"val 2\" name=\"test-radio-group\"/> rbtn 2</td>\n<td><input type=\"radio\" value=\"val 3\" name=\"test-radio-group\"/> rbtn 3</td>\n<td><input type=\"radio\" value=\"val 4\" name=\"test-radio-group\"/> rbtn 4</td>\n<td><input type=\"radio\" value=\"val 5\" name=\"test-radio-group\"/> rbtn 5</td>\n</tr>\n<tr><td><input type=\"radio\" value=\"val 6\" name=\"test-radio-group\"/> rbtn 6</td>\n<td><input type=\"radio\" value=\"val 7\" name=\"test-radio-group\"/> rbtn 7</td>\n<td><input type=\"radio\" value=\"val 8\" name=\"test-radio-group\"/> rbtn 8</td>\n<td><input type=\"radio\" value=\"val 9\" name=\"test-radio-group\"/> rbtn 9</td>\n<td><input type=\"radio\" value=\"val 10\" name=\"test-radio-group\"/> rbtn 10</td>\n</tr>\n</table>";

      // act
      string result = FormHelperExtension.RadioButtonGroup(
        m_html,
        "test-radio-group",
        m_radioBtns,
        new { title = "radio button group" }).ToHtmlString();

      // assert
      Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Test that the RadioButtonGroup method with a no. of buttons
    /// specified returns expected results
    /// </summary>
    [TestMethod]
    public void RadioButtonGroup_With_NumButtonsPerLine_Test()
    {
      // arrange
      const string expected = "<table class=\"radiobutton-group\" title=\"radio button group\"><tr><td><input type=\"radio\" value=\"val 1\" name=\"test-radio-group\"/> rbtn 1</td>\n<td><input type=\"radio\" value=\"val 2\" name=\"test-radio-group\"/> rbtn 2</td>\n<td><input type=\"radio\" value=\"val 3\" name=\"test-radio-group\"/> rbtn 3</td>\n</tr>\n<tr><td><input type=\"radio\" value=\"val 4\" name=\"test-radio-group\"/> rbtn 4</td>\n<td><input type=\"radio\" value=\"val 5\" name=\"test-radio-group\"/> rbtn 5</td>\n<td><input type=\"radio\" value=\"val 6\" name=\"test-radio-group\"/> rbtn 6</td>\n</tr>\n<tr><td><input type=\"radio\" value=\"val 7\" name=\"test-radio-group\"/> rbtn 7</td>\n<td><input type=\"radio\" value=\"val 8\" name=\"test-radio-group\"/> rbtn 8</td>\n<td><input type=\"radio\" value=\"val 9\" name=\"test-radio-group\"/> rbtn 9</td>\n</tr>\n<tr><td><input type=\"radio\" value=\"val 10\" name=\"test-radio-group\"/> rbtn 10</td>\n</tr>\n</table>";

      // act
      string result = FormHelperExtension.RadioButtonGroup(
        m_html,
        "test-radio-group",
        m_radioBtns,
        3,
        new { title = "radio button group" }).ToHtmlString();

      // assert
      Assert.AreEqual(expected, result);
    }

    #endregion RadioButtonGroup tests

    /// <summary>
    /// Test initialise
    /// </summary>
    [TestInitialize]
    public void Initialise()
    {
      m_html = MockHtmlHelperUtil.CreateHtmlHelper();

      m_checkBoxes = Enumerable.Range(1, 10).Select(f => new CheckBox("box " + f, "val " + f));
      m_radioBtns = Enumerable.Range(1, 10).Select(f => new RadioButton("rbtn " + f, "val " + f));
    }
  }
}