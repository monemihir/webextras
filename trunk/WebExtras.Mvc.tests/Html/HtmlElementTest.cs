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
using NUnit.Framework;
using WebExtras.Core;
using WebExtras.Mvc.Html;

namespace WebExtras.Mvc.tests.Html
{
  /// <summary>
  ///   Hyperlink unit tests
  /// </summary>
  [TestFixture]
  public class HtmlElementTest
  {
    #region Ctor tests

    /// <summary>
    ///   Test that the constructor initialises all public properties
    /// </summary>
    [Test]
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
    ///   Test that the constructor with HTML attributes initialises
    ///   all public properties, adds the HTML attributes to the element
    ///   and handles the special condition for 'class' attribute
    /// </summary>
    [Test]
    public void Ctor_With_HTMLAttributes_Works_Properly()
    {
      // act
      HtmlElement element = new HtmlElement(EHtmlTag.A, new {@class = "test-css-class", title = "test title"});

      // assert
      Assert.IsTrue(string.IsNullOrEmpty(element.InnerHtml));
      Assert.AreEqual(EHtmlTag.A, element.Tag);
      Assert.AreEqual(0, element.PrependTags.Count);
      Assert.AreEqual(0, element.AppendTags.Count);

      Assert.AreEqual(2, element.Attributes.Count);
      Assert.AreEqual("test title", element.Attributes["title"]);
      Assert.AreEqual("test-css-class", element.Attributes["class"]);
      Assert.AreEqual(0, element.CSSClasses.Count);
    }

    #endregion Ctor tests

    #region Parse tests

    /// <summary>
    ///   Test that the Parse method works properly
    /// </summary>
    [Test]
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
      Assert.AreEqual("t1 t2", result["class"]);
    }

    /// <summary>
    ///   Test that the Parse method works properly if the
    ///   given HTML has child elements
    /// </summary>
    [Test]
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
      Assert.AreEqual("t1 t2", result["class"]);

      Assert.AreEqual(2, result.PrependTags.Count);
      Assert.AreEqual("icon-temp", result.PrependTags[0].Attributes["class"]);
      Assert.AreEqual("Test link", result.PrependTags[1].InnerHtml);
    }

    /// <summary>
    ///   Test that the Parse method works properly if the
    ///   given HTML has child elements
    /// </summary>
    [Test]
    public void Parse_Works_For_Multiple_Children()
    {
      // arrange
      string html =
        "<a href='/test.html' class='t1 t2' title='valid hyperlink'><i class='icon-temp'></i>Test link <b>for bolded text</b></a>";
      string expected =
        "<a href=\"/test.html\" class=\"t1 t2\" title=\"valid hyperlink\"><i class=\"icon-temp\"></i><span >Test link </span><b >for bolded text</b></a>";

      // act
      HtmlElement result = HtmlElement.Parse(html);

      // assert      
      Assert.IsTrue(string.IsNullOrEmpty(result.InnerHtml));
      Assert.AreEqual("/test.html", result["href"]);
      Assert.AreEqual("valid hyperlink", result["title"]);
      Assert.AreEqual("t1 t2", result["class"]);

      Assert.AreEqual(3, result.PrependTags.Count);
      Assert.AreEqual("icon-temp", result.PrependTags[0].Attributes["class"]);
      Assert.AreEqual("Test link ", result.PrependTags[1].InnerHtml);
      Assert.AreEqual("for bolded text", result.PrependTags[2].InnerHtml);

      string actual = result.ToHtmlString();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///   Test that the Parse method throws an exception if the
    ///   HTML to be parsed is an unsupported tag
    /// </summary>
    [Test]
    public void Parse_Throws_Exception_If_Unsupported_Tag()
    {
      // arrange
      string html = "<nav title='/test.html'>Test navigation</nav>";
      NotSupportedException expected =
        new NotSupportedException(
          "NAV tag is not supported. Only the following HTML tags are supported: A, I, B, IMG, BUTTON, INPUT, TEXTAREA, UL, OL, LI, DIV, SPAN, LABEL, SELECT, OPTION, SCRIPT.");
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