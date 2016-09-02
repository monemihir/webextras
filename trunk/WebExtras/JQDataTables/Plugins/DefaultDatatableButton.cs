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
using Newtonsoft.Json;
using WebExtras.Core;

namespace WebExtras.JQDataTables.Plugins
{
  /// <summary>
  ///   A datatable button
  /// </summary>
  [Serializable]
  public class DefaultDatatableButton : IDatatableButton<IDictionary<string, object>>
  {
    /// <summary>
    ///   The text to show in the button
    /// </summary>
    public string text;

    /// <summary>
    ///   Action to take when the button is activated
    /// </summary>
    public JsFunc action;

    /// <summary>
    ///   The CSS class name for the button
    /// </summary>
    public string className;

    /// <summary>
    ///   Define an activation key for a button
    /// </summary>
    public object key;

    /// <summary>
    ///   Extend an existing button
    /// </summary>
    public string extend;

    /// <summary>
    ///   The default function definition for the action
    /// </summary>
    /// <returns>A function with an empty body but the function parameters filled in</returns>
    public static JsFunc GetDefaultActionFunc()
    {
      JsFunc fn = new JsFunc
      {
        ParameterNames = new[] {"e", "dt", "node", "config"}
      };

      return fn;
    }

    /// <summary>
    ///   Create options
    /// </summary>
    /// <param name="nullValues">Null value handling</param>
    /// <returns>Plugin options</returns>
    public virtual IDictionary<string, object> CreateOptions(NullValueHandling nullValues)
    {
      IDictionary<string, object> options = DatatablesHelper.ToDictionary(this, nullValues);

      return options;
    }
  }
}