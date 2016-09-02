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
using Newtonsoft.Json;

namespace WebExtras.JQDataTables.Plugins
{
  /// <summary>
  ///   A generic datatable plugin interface
  /// </summary>
  /// <typeparam name="TOptions">Output type of the processed options</typeparam>
  public interface IDatatablePlugin<out TOptions> : IProcessOptions<TOptions>
  {
    /// <summary>
    ///   Plugin name
    /// </summary>
    string Name { get; }

    /// <summary>
    ///   Any custom <see cref="JsonConverter" /> implementation specified using the <see cref="JsonConverterAttribute" /> on
    ///   the property/field definition. There custom converters must be detected in the
    ///   <see cref="IProcessOptions{TOptions}.CreateOptions" /> method
    /// </summary>
    List<JsonConverter> CustomConverters { get; }

    /// <summary>
    ///   Converts the current plugin to JSON
    /// </summary>
    /// <param name="settings">Custom serialiser settings</param>
    /// <returns>JSON string representing plugin options</returns>
    string ToJson(JsonSerializerSettings settings = null);
  }

  /// <summary>
  ///   A generic non templated datatable plugin interface
  /// </summary>
  public interface IDatatablePlugin : IDatatablePlugin<object>
  {
    // nothing to do here, only a convenience interface
  }
}