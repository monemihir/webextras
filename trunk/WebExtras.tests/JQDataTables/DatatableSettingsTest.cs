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

using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using WebExtras.JQDataTables;

namespace WebExtras.tests.JQDataTables
{
  [TestFixture]
  public class DatatableSettingsTest
  {
    /// <summary>
    ///   Sample plugin class
    /// </summary>
    private class SamplePlugin : IDatatablePlugin
    {
      /// <summary>
      ///   Name of the plugin
      /// </summary>
      public string Name { get { return "sample-plugin;"; } }

      /// <summary>
      ///   Create plugin options
      /// </summary>
      /// <returns></returns>
      public IDictionary<string, object> CreateOptions()
      {
        return new Dictionary<string, object>
        {
          {"sample-property", 1234}
        };
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

      string expectedJson = "{\r\n  \"bLengthChange\": false,\r\n  \"bPaginate\": false,\r\n  \"bServerSide\": false,\r\n  \"iDisplayLength\": 10,\r\n  \"sample-property\": 1234\r\n}";

      // act
      string json = s.ToString();

      // assert
      Assert.AreEqual(expectedJson, json);
    }
  }
}