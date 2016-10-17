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
using WebExtras.Core;

namespace WebExtras.JQDataTables.Plugins
{
  /// <summary>
  ///   An abstract datatable plugin
  /// </summary>
  [Serializable]
  public abstract class AbstractDatatablePlugin : IDatatablePlugin<IDictionary<string, object>>
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="name">Plugin name</param>
    protected AbstractDatatablePlugin(string name)
    {
      Name = name;
      CustomConverters = new List<JsonConverter>();
    }

    #region Implementation of IDatatablePlugin

    /// <summary>
    ///   Plugin name
    /// </summary>
    [JsonIgnore]
    public string Name { get; private set; }

    /// <summary>
    ///   Any custom <see cref="JsonConverter" /> implementation specified using the <see cref="JsonConverterAttribute" /> on
    ///   the property/field definition. There custom converters must be detected in the
    ///   <see cref="CreateOptions" /> method
    /// </summary>
    [JsonIgnore]
    public List<JsonConverter> CustomConverters { get; private set; }

    /// <summary>
    ///   Create plugin options
    /// </summary>
    /// <param name="nullValues">Null value handling</param>
    /// <returns>Plugin options</returns>
    public virtual IDictionary<string, object> CreateOptions(NullValueHandling nullValues)
    {
      Type[] converterTypes;

      IDictionary<string, object> options = DatatablesHelper.ToDictionary(this, nullValues, out converterTypes);

      var converters = converterTypes.Distinct().Select(c => (JsonConverter) Activator.CreateInstance(c));

      CustomConverters.AddRange(converters);

      return options;
    }

    /// <summary>
    ///   Converts the current plugin to JSON
    /// </summary>
    /// <param name="settings">Custom serialiser settings</param>
    /// <returns>JSON string representing plugin options</returns>
    public virtual string ToJson(JsonSerializerSettings settings = null)
    {
      JsonSerializerSettings finalSettings = settings ?? WebExtrasSettings.JsonSerializerSettings;

      // this call will detect any custom converters that may have been defined
      IDictionary<string, object> options = CreateOptions(finalSettings.NullValueHandling);

      // add those converters to our collection
      CustomConverters.ForEach(finalSettings.Converters.Add);

      string json = JsonConvert.SerializeObject(options, finalSettings);

      return json;
    }

    #endregion
  }
}