/*
* This file is part of - WebExtras
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    #region Button tests

    /// <summary>
    /// Test that the Button method with no 'onclick' event
    /// returns expected results
    /// </summary>
    [TestMethod]
    public void Button_Without_OnClick_Test()
    {
      // Arrange
      string expected = "<button class=\"test-css-class\" title=\"test title\" type=\"button\">Test Button</button>";

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
      string expected = "<button class=\"test-css-class\" onclick=\"javascript:callTestFunc()\" title=\"test title\" type=\"submit\">Test Button</button>";

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
      string expected = "<table class=\"checkbox-group\" title=\"check box group\"><tr><td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 1\" /> box 1</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 2\" /> box 2</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 3\" /> box 3</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 4\" /> box 4</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 5\" /> box 5</td>\n</tr>\n<tr><td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 6\" /> box 6</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 7\" /> box 7</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 8\" /> box 8</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 9\" /> box 9</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 10\" /> box 10</td>\n</tr>\n</table>";

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
      string expected = "<table class=\"checkbox-group\" title=\"check box group\"><tr><td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 1\" /> box 1</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 2\" /> box 2</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 3\" /> box 3</td>\n</tr>\n<tr><td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 4\" /> box 4</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 5\" /> box 5</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 6\" /> box 6</td>\n</tr>\n<tr><td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 7\" /> box 7</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 8\" /> box 8</td>\n<td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 9\" /> box 9</td>\n</tr>\n<tr><td><input name=\"test-chkbox-group\" type=\"checkbox\" value=\"val 10\" /> box 10</td>\n</tr>\n</table>";

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

    /// <summary>
    /// Test initialise
    /// </summary>
    [TestInitialize]
    public void Initialise()
    {
      m_html = MockHtmlHelperUtil.CreateHtmlHelper();

      m_checkBoxes = Enumerable.Range(1, 10).Select(f => new CheckBox("box " + f, "val " + f));
    }
  }
}