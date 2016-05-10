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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nancy;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;
using WebExtras.Nancy.Http;

namespace WebExtras.Nancy.Core
{
  /// <summary>
  ///   Automatically creates routes using reflection
  /// </summary>
  public static class RoutesCreatorExtension
  {
    private static readonly Type HasRouteMethodsInterfaceType = typeof(IHasRouteMethods);
    private static readonly Type NancyModuleType = typeof(NancyModule);

    private static readonly Type[] RouteTypes =
    {
      typeof(DeleteRouteAttribute),
      typeof(PostRouteAttribute),
      typeof(GetRouteAttribute)
    };

    /// <summary>
    ///   Automatically creates routes based on the defined methods.
    /// </summary>
    /// <param name="module">Current NancyModule</param>
    /// <exception cref="RouteException">If zero or multiple routes are defined for a method</exception>
    public static void CreateRoutesFromMethods(this NancyModule module)
    {
      Type[] validReturnTypes =
      {
        typeof(Negotiator),
        typeof(Response)
      };

      Type type = module.GetType();

      // get all public methods
      MethodInfo[] methods = type.GetMethods();

      if (methods.Length == 0)
        return;

      Type[] interfaces = type.GetInterfaces();

      // get all route methods i.e methods returning a view
      MethodInfo[] routeMethods = methods
        .Where(m => validReturnTypes.Contains(m.ReturnType) &&
                    interfaces.Contains(HasRouteMethodsInterfaceType) &&
                    m.DeclaringType != NancyModuleType)
        .ToArray();

      // sanity check routes defined
      foreach (MethodInfo m in routeMethods)
      {
        List<AbstractRouteAttribute> methodAttribs = new List<AbstractRouteAttribute>();
        foreach (Type t in RouteTypes)
        {
          var attribs = (AbstractRouteAttribute[]) m.GetCustomAttributes(t, false);
          methodAttribs.AddRange(attribs);
        }

        if (methodAttribs.Count > 1)
          throw new RouteException("Multiple routes defined for: " + m.Name);
      }

      // create routes by inspecting method attributes
      foreach (MethodInfo m in routeMethods)
      {
        NancyModule.RouteBuilder builder = module.Get;
        AbstractRouteAttribute route = null;

        // get the route that was defined
        foreach (Type t in RouteTypes)
        {
          var attribs = (AbstractRouteAttribute[]) m.GetCustomAttributes(t, false);

          if (attribs.Length == 0)
            continue;

          route = attribs[0];
          break;
        }

        if (route == null)
          throw new RouteException("No route defined for: " + m.Name);

        switch (route.RequestType)
        {
          case EHttpRoute.Post:
            builder = module.Post;
            break;

          case EHttpRoute.Delete:
            builder = module.Delete;
            break;
        }

        // create Nancy route mapping
        MethodInfo runMethod = m;
        builder[route.RoutePath] = p => CreateRoute(p, runMethod, module);
      }
    }

    /// <summary>
    ///   Creates a route
    /// </summary>
    /// <param name="p">Route parameters</param>
    /// <param name="m">Method to be called</param>
    /// <param name="module">Module to call the method on</param>
    /// <returns>A route</returns>
    private static object CreateRoute(dynamic p, MethodInfo m, NancyModule module)
    {
      var objDict = ((DynamicDictionary) p).ToDictionary();

      List<object> invokeParams = new List<object>();

      ParameterInfo[] mParams = m.GetParameters();

      foreach (var pinfo in mParams)
      {
        string pJson = JsonConvert.SerializeObject(objDict[pinfo.Name]);

        object val = JsonConvert.DeserializeObject(pJson, pinfo.ParameterType);

        invokeParams.Add(val);
      }

      return m.GetParameters().Length == 0 ? m.Invoke(module, null) : m.Invoke(module, invokeParams.ToArray());
    }
  }
}