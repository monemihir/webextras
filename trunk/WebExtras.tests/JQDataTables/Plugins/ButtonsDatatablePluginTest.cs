using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using WebExtras.JQDataTables.Plugins;

namespace WebExtras.tests.JQDataTables.Plugins
{
  /// <summary>
  /// Unit tests for <see cref="ButtonsDatatablePlugin"/>
  /// </summary>
  [TestFixture]
  public class ButtonsDatatablePluginTest
  {
    DefaultDatatableButton m_defaultBtn;
    InbuiltDatatableButton m_inbuiltBtn;
    ButtonsDatatablePlugin m_plugin;

    /// <summary>
    /// Test setup
    /// </summary>
    [SetUp]
    public void Initialise()
    {
      m_inbuiltBtn = new InbuiltDatatableButton { type = "copy" };
      m_defaultBtn= new DefaultDatatableButton
      {
        action = DefaultDatatableButton.GetDefaultActionFunc(),
        text = "My Default Button",
        key = "e"
      };
      m_plugin = new ButtonsDatatablePlugin();
    }

    /// <summary>
    /// Test that the default datatable button options are created properly
    /// </summary>
    [Test]
    public void InbuiltButtons_Are_Serialised_Properly()
    {
      // arrange
      m_plugin.buttons.Add(m_inbuiltBtn);

      const string expected = "[\r\n  \"copy\"\r\n]";

      // act
      string json = m_plugin.ToJson();

      // assert
      Assert.AreEqual(expected, json);
    }

    /// <summary>
    /// Test that the default datatable buttons are JSON serialised properly
    /// </summary>
    [Test]
    public void DefaultButtons_Are_Serialised_Properly()
    {
      // arrange
      m_plugin.buttons.Add(m_defaultBtn);

      const string expected = "[\r\n  {\r\n    \"text\": \"My Default Button\",\r\n    \"action\": function (e, dt, node, config) {  },\r\n    \"key\": \"e\"\r\n  }\r\n]";

      // act
      string json = m_plugin.ToJson();

      // assert
      Assert.AreEqual(expected, json);
    }

    /// <summary>
    /// Test that a mixture of default and inbuilt buttons gets serialised properly
    /// </summary>
    [Test]
    public void MixedButtons_Are_Serialised_Properly()
    {
      // arrange
      m_plugin.buttons.Add(m_defaultBtn);
      m_plugin.buttons.Add(m_inbuiltBtn);

      const string expected = "[\r\n  {\r\n    \"text\": \"My Default Button\",\r\n    \"action\": function (e, dt, node, config) {  },\r\n    \"key\": \"e\"\r\n  },\r\n  \"copy\"\r\n]";

      // act
      string json = m_plugin.ToJson();

      // assert
      Assert.AreEqual(expected, json);
    }
  }
}
