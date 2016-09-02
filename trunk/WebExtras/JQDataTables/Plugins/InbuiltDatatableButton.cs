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
using Newtonsoft.Json;

namespace WebExtras.JQDataTables.Plugins
{
  /// <summary>
  ///   An inbuilt datatable button
  /// </summary>
  [Serializable]
  public class InbuiltDatatableButton : IDatatableButton<object>
  {
    /// <summary>
    ///   Inbuilt button type. Valid values are copy, csv, excel, pdf and print
    /// </summary>
    public string type;

    /// <summary>
    ///   Create options
    /// </summary>
    /// <param name="nullValues">Null value handling</param>
    /// <returns>Plugin options</returns>
    public object CreateOptions(NullValueHandling nullValues)
    {
      return type;
    }
  }
}