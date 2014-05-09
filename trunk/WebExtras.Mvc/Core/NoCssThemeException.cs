﻿/*
* This file is part of - WebExtras
* Copyright (C) 2014 Mihir Mone
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// No CSS framework theme selected exception thrown when neither Bootstrap nor Gumby 
  /// CSS framework is selected and an extension for these framework is used
  /// </summary>
  public class NoCssThemeException : Exception
  {
    /// <summary>
    /// The code line that can resolve this exception
    /// </summary>
    readonly string m_codeLine;

    /// <summary>
    /// Constructor
    /// </summary>
    public NoCssThemeException()
    {
      switch (WebExtrasMvcConstants.CssFramework)
      {
        case ECssFramework.None:
          throw new NoCssFrameworkException();
        case ECssFramework.Gumby:
          m_codeLine = "          WebExtrasMvcConstants.GumbyTheme = EGumbyTheme.Metro;\n";
          break;
        case ECssFramework.Bootstrap:
          m_codeLine = "          WebExtrasMvcConstants.BootstrapVersion = EBootstrapVersion.V2;\n";
          break;
        default:
          m_codeLine = string.Empty;
          break;
      }
    }

    /// <summary>
    /// The error message that explains the reason for the exception
    /// </summary>
    public override string Message
    {
      get
      {
        const string prefix = "Please select the appropriate CSS framework theme/version.\n" +
                           "The simplest way of doing this is to set the value in your Global.asax.cs as shown below:\n\n" +
                           "  public class MvcApplication : System.Web.HttpApplication\n" +
                           "  {\n" +
                           "      protected void Application_Start()\n" +
                           "      {\n";

        const string suffix = "      }\n" +
                           "  }\n";

        return prefix + m_codeLine + suffix;
      }
    }
  }
}
