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

using NUnit.Framework;
using WebExtras.JQDataTables;
using WebExtras.JQDataTables.Plugins;

namespace WebExtras.tests.JQDataTables
{
  [TestFixture]
  public class DatatableSettingsTest
  {
    /// <summary>
    ///   Sample plugin class
    /// </summary>
    private class SamplePlugin : AbstractDatatablePlugin
    {
      public int oSampleField;
      public string oSampleProperty { get; set; }

      /// <summary>
      ///   Constructor
      /// </summary>
      public SamplePlugin() : base("oSamplePlugin")
      {
        oSampleField = 1234;
        oSampleProperty = "mihir-mone";
      }
    }

    /// <summary>
    ///   Test that the serialization i.e calling the <see cref="DatatableSettings.ToString()" /> method includes plugin
    ///   options in the root level serialised object
    /// </summary>
    [Test]
    public void Serialization_Includes_Plugin_Options_In_Root_Object()
    {
      // arrange
      SamplePlugin p = new SamplePlugin();
      DatatableSettings s = new DatatableSettings();
      s.Plugins.Add(p);

      const string expectedJson = "{\r\n  \"bLengthChange\": false,\r\n  \"bPaginate\": false,\r\n  \"bServerSide\": false,\r\n  \"iDisplayLength\": 10,\r\n  \"oSamplePlugin\": {\r\n    \"oSampleField\": 1234,\r\n    \"oSampleProperty\": \"mihir-mone\"\r\n  }\r\n}";

      // act
      string json = s.ToString();

      // assert
      Assert.AreEqual(expectedJson, json);
    }

    /// <summary>
    /// Test that the serialization for known plugins works as expected
    /// </summary>
    [Test]
    public void Serialization_Works_As_Expected_For_Known_Plugins()
    {
      // arrange
      ColVisDatatablePlugin cvdp = new ColVisDatatablePlugin {
        aiExclude = new[] { 0, 1, 4 }
      };

      DefaultDatatableButton btn = new DefaultDatatableButton
      {
        text = "Sample Button",
        action = DefaultDatatableButton.GetDefaultActionFunc()
      };
      btn.action.Body = "alert('hello mihir');";

      ButtonsDatatablePlugin bdp = new ButtonsDatatablePlugin();
      bdp.buttons.Add(btn);

      DatatableSettings s = new DatatableSettings();
      s.Plugins.AddRange(new IDatatablePlugin<object> [] { cvdp, bdp });

      const string expected = "{\r\n  \"bLengthChange\": false,\r\n  \"bPaginate\": false,\r\n  \"bServerSide\": false,\r\n  \"iDisplayLength\": 10,\r\n  \"oColVis\": {\r\n    \"aiExclude\": [\r\n      0,\r\n      1,\r\n      4\r\n    ]\r\n  },\r\n  \"buttons\": [\r\n    {\r\n      \"text\": \"Sample Button\",\r\n      \"action\": function (e, dt, node, config) { alert('hello mihir'); }\r\n    }\r\n  ]\r\n}";

      // act
      string json = s.ToString();

      // assert
      Assert.AreEqual(expected, json);
    }
  }
}