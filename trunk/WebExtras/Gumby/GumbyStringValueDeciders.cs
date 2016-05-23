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

using WebExtras.Core;

namespace WebExtras.Gumby
{
  /// <summary>
  ///   String value decider for <see cref="EGumbyIcon" />
  /// </summary>
  internal class GumbyIconStringValueDecider : IStringValueDecider<EGumbyIcon>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EGumbyIcon> args)
    {
      return "icon-" + args.Value.ToString().ToLowerInvariant().Replace('_', '-');
    }
  }
}