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
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WebExtras.JQDataTables.Plugins
{
  /// <summary>
  ///   Buttons datatable plugin
  /// </summary>
  [Serializable]
  public class ButtonsDatatablePlugin : IDatatablePlugin<List<IDatatableButton<object>>>
  {
    /// <summary>
    ///   Button definitions
    /// </summary>
    public List<IDatatableButton<object>> buttons { get; private set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    public ButtonsDatatablePlugin()
    {
      buttons = new List<IDatatableButton<object>>();
      CustomConverters = new List<JsonConverter>();
    }

    /// <summary>
    ///   Plugin name
    /// </summary>
    public string Name { get { return "buttons"; } }

    /// <summary>
    ///   Any custom <see cref="JsonConverter" /> implementation specified using the <see cref="JsonConverterAttribute" /> on
    ///   the property/field definition. There custom converters must be detected in the
    ///   <see cref="CreateOptions" /> method
    /// </summary>
    public List<JsonConverter> CustomConverters { get; private set; }

    /// <summary>
    ///   Create plugin options
    /// </summary>
    /// <param name="nullValues">Null value handling</param>
    /// <returns>Plugin options</returns>
    public virtual List<IDatatableButton<object>> CreateOptions(NullValueHandling nullValues)
    {
      // since the buttons list can never be null we can safely ignore the null value handling

      return buttons;
    }

    /// <summary>
    ///   Converts the current plugin to JSON
    /// </summary>
    /// <param name="settings">Custom serialiser settings</param>
    /// <returns>JSON string representing plugin options</returns>
    public virtual string ToJson(JsonSerializerSettings settings = null)
    {
      JsonSerializerSettings finalSettings = settings ?? new JsonSerializerSettings
      {
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      };

      List<IDatatableButton<object>> finalOptions = CreateOptions(finalSettings.NullValueHandling);

      object[] explodedOptions = finalOptions.Select(f => f.CreateOptions(finalSettings.NullValueHandling)).ToArray();

      string json = JsonConvert.SerializeObject(explodedOptions, finalSettings);

      return json;
    }
  }
}