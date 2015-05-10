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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtras.Mvc.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests.Html
{
  /// <summary>
  /// Hyperlink unit tests
  /// </summary>
  [TestClass]
  public class HtmlElementTest
  {
    #region Ctor tests

    /// <summary>
    /// Test that the constructor initialises all public properties
    /// </summary>
    [TestMethod]
    public void Ctor_Initialises_Properties()
    {
      // act
      HtmlElement element = new HtmlElement(EHtmlTag.A);

      // assert
      Assert.AreEqual(16, HtmlElement.SupportedTags.Count);
      Assert.IsTrue(string.IsNullOrEmpty(element.InnerHtml));
      Assert.AreEqual(EHtmlTag.A, element.Tag);
      Assert.AreEqual(0, element.PrependTags.Count);
      Assert.AreEqual(0, element.AppendTags.Count);
      Assert.AreEqual(0, element.CSSClasses.Count);

      Assert.IsNotNull(element.Attributes);
    }

    /// <summary>
    /// Test that the constructor with HTML attributes initialises
    /// all public properties, adds the HTML attributes to the element
    /// and handles the special condition for 'class' attribute
    /// </summary>
    [TestMethod]
    public void Ctor_With_HTMLAttributes_Works_Properly()
    {
      // act
      HtmlElement element = new HtmlElement(EHtmlTag.A, new { @class = "test-css-class", title = "test title" });

      // assert
      Assert.IsTrue(string.IsNullOrEmpty(element.InnerHtml));
      Assert.AreEqual(EHtmlTag.A, element.Tag);      
      Assert.AreEqual(0, element.PrependTags.Count);
      Assert.AreEqual(0, element.AppendTags.Count);

      Assert.AreEqual(1, element.Attributes.Count);
      Assert.AreEqual("test title", element.Attributes["title"]);
      Assert.AreEqual(1, element.CSSClasses.Count);
      Assert.AreEqual("test-css-class", element.CSSClasses[0]);
    }

    #endregion Ctor tests

    #region Parse tests

    /// <summary>
    /// Test that the Parse method works properly
    /// </summary>
    [TestMethod]
    public void Parse_Works_For_Single_Element()
    {
      // arrange
      string html = "<a href='/test.html' class='t1 t2' title='valid hyperlink'>Test link</a>";

      // act
      HtmlElement result = HtmlElement.Parse(html);

      // assert
      Assert.AreEqual("Test link", result.InnerHtml);
      Assert.AreEqual("/test.html", result["href"]);
      Assert.AreEqual("valid hyperlink", result["title"]);
      Assert.AreEqual(2, result.CSSClasses.Count);
      Assert.AreEqual("t1", result.CSSClasses[0]);
      Assert.AreEqual("t2", result.CSSClasses[1]);
    }

    /// <summary>
    /// Test that the Parse method works properly if the 
    /// given HTML has child elements
    /// </summary>
    [TestMethod]
    public void Parse_Works_For_Single_Child()
    {
      // arrange
      string html = "<a href='/test.html' class='t1 t2' title='valid hyperlink'><i class='icon-temp'></i>Test link</a>";

      // act
      HtmlElement result = HtmlElement.Parse(html);

      // assert
      Assert.IsTrue(string.IsNullOrEmpty(result.InnerHtml));
      Assert.AreEqual("/test.html", result["href"]);
      Assert.AreEqual("valid hyperlink", result["title"]);
      Assert.AreEqual(2, result.CSSClasses.Count);
      Assert.AreEqual("t1", result.CSSClasses[0]);
      Assert.AreEqual("t2", result.CSSClasses[1]);

      Assert.AreEqual(2, result.PrependTags.Count);
      Assert.AreEqual(1, result.PrependTags[0].CSSClasses.Count);
      Assert.AreEqual("icon-temp", result.PrependTags[0].CSSClasses[0]);
      Assert.AreEqual("Test link", result.PrependTags[1].InnerHtml);
    }

    /// <summary>
    /// Test that the Parse method works properly if the 
    /// given HTML has child elements
    /// </summary>
    [TestMethod]
    public void Parse_Works_For_Multiple_Children()
    {
      // arrange
      string html = "<a href='/test.html' class='t1 t2' title='valid hyperlink'><i class='icon-temp'></i>Test link <b>for bolded text</b></a>";
      string expected = "<a class=\"t1 t2\" href=\"/test.html\" title=\"valid hyperlink\"><i class=\"icon-temp\"></i><span>Test link </span><b>for bolded text</b></a>";

      // act
      HtmlElement result = HtmlElement.Parse(html);

      // assert      
      Assert.IsTrue(string.IsNullOrEmpty(result.InnerHtml));
      Assert.AreEqual("/test.html", result["href"]);
      Assert.AreEqual("valid hyperlink", result["title"]);
      Assert.AreEqual(2, result.CSSClasses.Count);
      Assert.AreEqual("t1", result.CSSClasses[0]);
      Assert.AreEqual("t2", result.CSSClasses[1]);

      Assert.AreEqual(3, result.PrependTags.Count);
      Assert.AreEqual(1, result.PrependTags[0].CSSClasses.Count);
      Assert.AreEqual("icon-temp", result.PrependTags[0].CSSClasses[0]);
      Assert.AreEqual("Test link ", result.PrependTags[1].InnerHtml);
      Assert.AreEqual("for bolded text", result.PrependTags[2].InnerHtml);

      string actual = result.ToHtmlString();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Test that the Parse method throws an exception if the 
    /// HTML to be parsed is an unsupported tag
    /// </summary>
    [TestMethod]
    public void Parse_Throws_Exception_If_Unsupported_Tag()
    {
      // arrange
      string html = "<nav title='/test.html'>Test navigation</nav>";
      NotSupportedException expected = new NotSupportedException("NAV tag is not supported. Only the following HTML tags are supported: A, I, B, IMG, BUTTON, INPUT, TEXTAREA, UL, OL, LI, DIV, SPAN, LABEL, SELECT, OPTION, SCRIPT.");
      NotSupportedException actual = null;

      // act
      try
      {
        HtmlElement.Parse(html);
      }
      catch (NotSupportedException e)
      {
        actual = e;
      }

      // assert
      Assert.AreEqual(expected.Message, actual.Message);
    }

    #endregion Parse tests
  }
}
