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

using WebExtras.Html;

namespace WebExtras.Bootstrap
{
  /// <summary>
  ///   All available behaviors for <see cref="IFormComponent{TModel,TValue}" />. Also see
  ///   <see cref="M:WebExtrasConstants.FormControlBehavior" />.
  /// </summary>
  public enum EFormControlBehavior
  {
    /// <summary>
    ///   Renders the form control in the default way
    /// </summary>
    Default,

    /// <summary>
    ///   Renders the form control as an input group with an addon
    /// </summary>
    WithAddon
  }
}