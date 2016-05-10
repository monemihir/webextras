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

namespace WebExtras.Nancy.Http
{
  /// <summary>
  ///   An abstract Nancy route
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public abstract class AbstractRouteAttribute : Attribute
  {
    /// <summary>
    ///   Route path
    /// </summary>
    public string RoutePath { get; private set; }

    /// <summary>
    ///   HTTP request type
    /// </summary>
    public EHttpRoute RequestType { get; private set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="routePath">Route path</param>
    /// <param name="requestType">Request type</param>
    protected AbstractRouteAttribute(string routePath, EHttpRoute requestType)
    {
      RoutePath = routePath;
      RequestType = requestType;
    }
  }
}