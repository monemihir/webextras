﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using WebExtras.Core;
    using WebExtras.Mvc.Bootstrap;
    using WebExtras.Mvc.Bootstrap.v3;
    using WebExtras.Mvc.Core;
    using WebExtras.Mvc.Html;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Bootstrap3/Views/Mvc/BootstrapForm.cshtml")]
    public partial class _Areas_Bootstrap3_Views_Mvc_BootstrapForm_cshtml : System.Web.Mvc.WebViewPage<WebExtras.DemoApp.Models.Mvc.CoreFormViewModel>
    {
        public _Areas_Bootstrap3_Views_Mvc_BootstrapForm_cshtml()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
  
  ViewBag.Title = "Mvc Bootstrap 3 Form Helper Extensions";


            
            #line default
            #line hidden
WriteLiteral(@"
<h3 class=""keep-center"">Mvc Bootstrap 3 Form Helper Extensions</h3>

<div class=""row"">
  <div class=""col-md-6"">
    <div class=""row"">
      <div class=""col-md-3"">
        <strong>Assembly</strong>
      </div>
      <div class=""col-md-4"">
        WebExtras.Mvc.dll
      </div>
    </div>
    <div class=""row"">
      <div class=""col-md-3"">
        <strong>Namespace</strong>
      </div>
      <div class=""col-md-4"">
        WebExtras.Mvc.Bootstrap
      </div>
    </div>
  </div>
  <div class=""col-md-6"">
    <div class=""col-md-3"">
      <strong>Dependancies</strong>
    </div>
    <div class=""col-md-7"">
      <ul class=""dependancies"">
        <li>Bootstrap 3.x</li>
        <li>Font Awesome 3.11 and below</li>
        <li>");


            
            #line 36 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
       Write(Html.Hyperlink("Bootstrap Datetime picker", "http://www.malot.fr/bootstrap-datetimepicker"));

            
            #line default
            #line hidden
WriteLiteral(@"</li>
        <li>webextras.bootstrap3.css</li>
      </ul>
    </div>
  </div>
</div>

<div class=""well"">
  <h4>Creating special buttons</h4>
  <p>Special buttons can be created by decorating hyperlinks and basic buttons with the appropriate special button type</p>

  <p>Markup</p>
  <pre><code>
");


WriteLiteral("@Html.Hyperlink(\"Take me to google\", \"http://www.google.com\")\r\n    .AsButton(EBoo" +
"tstrapButton.Default)\r\n\r\n");


WriteLiteral("@Html.Button(EButton.Regular, \"Take me to google\", \"window.location=\'http://www.g" +
"oogle.com.au\'\")\r\n    .AsButton(EBootstrapButton.Danger, EBootstrapButton.Large)\r" +
"\n  </code></pre>\r\n");


            
            #line 55 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
    
    const string msg = "You can create a button of type <strong>EButton.Cancel</strong> which takes you back to the previous page. When a button of this" +
                       "type is created, any onclick event specified will be blatantly ignored.";
  

            
            #line default
            #line hidden
WriteLiteral("  ");


            
            #line 59 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
Write(Html.Alert(EMessage.Warning, msg, string.Empty, EFontAwesomeIcon.Flag));

            
            #line default
            #line hidden
WriteLiteral("\r\n  <p>Output</p>\r\n  <div class=\"content\">\r\n    <p>\r\n      ");


            
            #line 63 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
 Write(Html.Hyperlink("Take me to google", "http://www.google.com").AsButton(EBootstrapButton.Default));

            
            #line default
            #line hidden
WriteLiteral("\r\n      ");


            
            #line 64 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
 Write(Html.Hyperlink("Take me to google", "http://www.google.com").AsButton(EBootstrapButton.Primary));

            
            #line default
            #line hidden
WriteLiteral("\r\n      ");


            
            #line 65 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
 Write(Html.Button(EButton.Cancel, "Take me back").AsButton(EBootstrapButton.Danger));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </p>\r\n    <p>\r\n      ");


            
            #line 68 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
 Write(Html.Button(EButton.Regular, "Take me to google", "http://www.google.com").AsButton(EBootstrapButton.Info, EBootstrapButton.XSmall));

            
            #line default
            #line hidden
WriteLiteral("\r\n      ");


            
            #line 69 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
 Write(Html.Button(EButton.Regular, "Take me to google", "http://www.google.com").AsButton(EBootstrapButton.Warning, EBootstrapButton.Small));

            
            #line default
            #line hidden
WriteLiteral("\r\n      ");


            
            #line 70 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
 Write(Html.Button(EButton.Regular, "Take me to google", "goToGoogle()").AsButton(EBootstrapButton.Success, EBootstrapButton.Large));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </p>\r\n  </div>\r\n  <p>All available extensions</p>\r\n  <pre><code>\r\n.AsButton" +
"(type)\r\n  </code></pre>\r\n  ");


            
            #line 77 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
Write(Html.Alert(EMessage.Warning, "Note that this extension can only be used for hyperlinks and button elements", string.Empty, EFontAwesomeIcon.Flag));

            
            #line default
            #line hidden
WriteLiteral(@"
</div>

<div class=""well"">
  <h4>Date time pickers</h4>
  <p>
    WebExtras provides helper methods for rendering a date time picker attached to a textbox by using a great little date time picker
    provided by Jonathan Peterson. You can get a copy of the date time picker from ");


            
            #line 84 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
                                                                              Write(Html.Hyperlink("here.", "https://github.com/Eonasdan/bootstrap-datetimepicker"));

            
            #line default
            #line hidden
WriteLiteral("\r\n  </p>\r\n  <p>Markup</p>\r\n  <pre><code>\r\n");


WriteLiteral("@Html.DateTimeTextBoxFor(f => f.DateTextBox, new PickerOptions { format = \"YYYY-M" +
"M-DD\" })\r\n");


WriteLiteral("@Html.DateTimeTextBoxFor(f => f.TimeTextBox, new PickerOptions { format = \"HH:mm:" +
"ss\" })\r\n");


WriteLiteral(@"@Html.DateTimeTextBoxFor(f => f.DateTimeTextBox)
  </code></pre>
  <p>Output</p>
  <div class=""content"">
    <div class=""row keep-center"">
      <div class=""col-md-4"">Date only picker</div>
      <div class=""col-md-4"">Time only picker</div>
      <div class=""col-md-4"">Date and time picker</div>
    </div>
    <div class=""row keep-center"">
      <div class=""col-md-4"">
        ");


            
            #line 101 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
   Write(Html.DateTimeTextBoxFor(f => f.DateTextBox, new PickerOptions { format = "YYYY-MM-DD" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n      </div>\r\n      <div class=\"col-md-4\">\r\n        ");


            
            #line 104 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
   Write(Html.DateTimeTextBoxFor(f => f.TimeTextBox, new PickerOptions { format = "HH:mm:ss" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n      </div>\r\n      <div class=\"col-md-4\">\r\n        ");


            
            #line 107 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
   Write(Html.DateTimeTextBoxFor(f => f.DateTimeTextBox));

            
            #line default
            #line hidden
WriteLiteral(@"
      </div>
    </div>
  </div>
  <p>A slight gotcha with the time only picker is that the date will always be fixed to 31 December 1899. </p>
</div>

<div class=""well"">
  <h4>Manipulating lists</h4>
  <div class=""row"">
    <div class=""col-md-6"">
      <p>Unstyled lists can be created by using the <strong>AsUnstyled()</strong> decorator.</p>
      <p>Markup</p>
      <pre><code>
");


WriteLiteral(@"@Html.List(EList.Unordered, new HtmlListItem[] { 
  new HtmlListItem(""list item 1""),
  new HtmlListItem(""list item 2""),
  new HtmlListItem(""list item 3""),
  new HtmlListItem(""list item 4""),
  new HtmlListItem(""list item 5"")
}).AsUnstyled()
  </code></pre>
      <p>Output</p>
      <div class=""content"">
        ");


            
            #line 131 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
   Write(Html.List(EList.Unordered, new HtmlListItem[] { 
      new HtmlListItem("list item 1"),
      new HtmlListItem("list item 2"),
      new HtmlListItem("list item 3"),
      new HtmlListItem("list item 4"),
      new HtmlListItem("list item 5")
    }).AsUnstyled());

            
            #line default
            #line hidden
WriteLiteral("\r\n      </div>\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n      <p>Inline lists can" +
" be created by using the <strong>AsInline()</strong> decorator.</p>\r\n      <p>Ma" +
"rkup</p>\r\n      <pre><code>\r\n");


WriteLiteral(@"@Html.List(EList.Unordered, new HtmlListItem[] { 
  new HtmlListItem(""list item 1""),
  new HtmlListItem(""list item 2""),
  new HtmlListItem(""list item 3""),
  new HtmlListItem(""list item 4""),
  new HtmlListItem(""list item 5"")
}).AsInline()
  </code></pre>
      <p>Output</p>
      <div class=""content"">
        ");


            
            #line 154 "..\..\Areas\Bootstrap3\Views\Mvc\BootstrapForm.cshtml"
   Write(Html.List(EList.Unordered, new HtmlListItem[] { 
      new HtmlListItem("list item 1"),
      new HtmlListItem("list item 2"),
      new HtmlListItem("list item 3"),
      new HtmlListItem("list item 4"),
      new HtmlListItem("list item 5")
    }).AsInline());

            
            #line default
            #line hidden
WriteLiteral("\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591