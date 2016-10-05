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

namespace WebExtras.Core
{
  /// <summary>
  ///   Indicates the type of HTML button to be rendered
  /// </summary>
  [Serializable]
  public enum EButton
  {
    /// <summary>
    ///   Regular button
    /// </summary>
    [StringValue("button")] Regular,

    /// <summary>
    ///   Reset button
    /// </summary>
    [StringValue("reset")] Reset,

    /// <summary>
    ///   Submit button
    /// </summary>
    [StringValue("submit")] Submit,

    /// <summary>
    ///   Cancel button
    /// </summary>
    [StringValue("button")] Cancel,

    /// <summary>
    ///   Back button
    /// </summary>
    [StringValue("button")] Back
  }
}