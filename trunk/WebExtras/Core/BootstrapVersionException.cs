// 
// This file is part of - WebExtras
// Copyright (C) 2016 Mihir Mone
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace WebExtras.Core
{
  /// <summary>
  ///   Bootstrap version exception thrown when a valid
  ///   Bootstrap version is not selected
  /// </summary>
  public class BootstrapVersionException : Exception
  {
    /// <summary>
    ///   The error message that explains the reason for the exception
    /// </summary>
    public override string Message
    {
      get
      {
        const string msg =
          "Please select your desired Bootstrap version by setting the WebExtrasConstants.BootstrapVersion property.\n" +
          "The simplest way of doing this is to set the value in your Global.asax.cs as shown below:\n\n" +
          "  public class MvcApplication : System.Web.HttpApplication\n" +
          "  {\n" +
          "      protected void Application_Start()\n" +
          "      {\n" +
          "          WebExtrasConstants.BootstrapVersion = EBootstrapVersion.V2;\n" +
          "      }\n" +
          "  }\n";

        return msg;
      }
    }
  }
}