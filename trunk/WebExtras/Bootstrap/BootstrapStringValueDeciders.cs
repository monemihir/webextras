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

namespace WebExtras.Bootstrap
{
  /// <summary>
  ///   The string value decider for a bootstrap button
  /// </summary>
  internal class BootstrapButtonStringValueDecider : IStringValueDecider<EBootstrapButton>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   String value decider args
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EBootstrapButton> args)
    {
      if (WebExtrasConstants.BootstrapVersion == EBootstrapVersion.None)
        throw new BootstrapVersionException();

      string iconName = "btn-" + args.Value.ToString().ToLowerInvariant();

      if (WebExtrasConstants.BootstrapVersion == EBootstrapVersion.V3 &&
          args.Value == EBootstrapButton.Large)
        iconName = "btn-lg";

      if (WebExtrasConstants.BootstrapVersion == EBootstrapVersion.V3 &&
          args.Value == EBootstrapButton.Small)
        iconName = "btn-sm";

      string value = "btn " + iconName;

      return value;
    }
  }

  /// <summary>
  ///   The string value decider for a bootstrap icon
  /// </summary>
  internal class BootstrapIconStringValueDecider : IStringValueDecider<EBootstrapIcon>
  {
    /// <summary>
    ///   The string value decider function
    /// </summary>
    /// <param name="args">
    ///   [Optional] Sender object that can contain extra data
    ///   which can then be used to decide the value
    /// </param>
    /// <returns>The string value to be used for the enum value</returns>
    public string Decide(StringValueDeciderArgs<EBootstrapIcon> args)
    {
      string iconName = args.Value.ToString().ToLowerInvariant().Replace("_", "-");

      string value;
      switch (WebExtrasConstants.BootstrapVersion)
      {
        case EBootstrapVersion.V2:
          value = "icon-" + iconName;
          break;
        case EBootstrapVersion.V3:
          value = "glyphicon glyphicon-" + iconName;
          break;
        default:
          throw new BootstrapVersionException();
      }

      return value;
    }
  }
}