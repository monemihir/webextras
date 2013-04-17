/*
* This file is part of - WebExtras
* Copyright (C) 2013 Mihir Mone
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


namespace WebExtras.Mvc.Bootstrap
{
  /// <summary>
  /// Bootstrap progress bar extension method
  /// </summary>
  public static class BootstrapProgressBarExtension
  {
    /// <summary>
    /// Create a striped progress bar
    /// </summary>
    /// <param name="bar">Progress bar to be converted</param>
    /// <returns>A striped progress bar</returns>
    public static BootstrapProgressBar AsStriped(this BootstrapProgressBar bar)
    {
      bar["class"] += " progress-striped";

      return bar;
    }

    /// <summary>
    /// Create a animated progress bar
    /// </summary>
    /// <param name="bar">Progress bar to be converted</param>
    /// <returns>An animated progress bar</returns>
    public static BootstrapProgressBar AsAnimated(this BootstrapProgressBar bar)
    {
      bar["class"] += " progress-striped active";

      return bar;
    }
  }
}
