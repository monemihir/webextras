using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Nancy;
using Nancy.Responses.Negotiation;
using Newtonsoft.Json;

namespace WebExtras.Nancy.Core
{
  /// <summary>
  /// Automatically creates routes using reflection
  /// </summary>
  public static class RoutesCreatorExtension
  {
    /// <summary>
    /// Automatically creates routes based on the defined methods.
    /// </summary>
    /// <param name="module">Current NancyModule</param>
    public static void CreateRoutesFromMethods(this NancyModule module)
    {
      Type[] validReturnTypes = new[] {
        typeof(Negotiator),
        typeof(Response)
      };

      Type type = module.GetType();

      // get all public methods
      MethodInfo[] methods = type.GetMethods();

      if (methods.Length == 0)
        return;

      // get all route methods i.e methods returning a view
      MethodInfo[] routeMethods = methods.Where(m => validReturnTypes.Contains(m.ReturnType) && m.DeclaringType == type).ToArray();

      Dictionary<string, Action<dynamic>> getRoutes = new Dictionary<string, Action<dynamic>>();
      Dictionary<string, Action<dynamic>> postRoutes = new Dictionary<string, Action<dynamic>>();

      foreach (MethodInfo m in routeMethods)
      {
        ERouteType requestType = ERouteType.Get;
        NancyModule.RouteBuilder builder = module.Get;

        if (m.GetCustomAttributes(typeof(HttpPostAttribute), false).Length == 1)
          requestType = ERouteType.Post;
        else if(m.GetCustomAttributes(typeof(HttpDeleteAttribute),false).Length==1)
          requestType=ERouteType.Delete;

        RouteAttribute[] routes = (RouteAttribute[])m.GetCustomAttributes(typeof(RouteAttribute), false);


        foreach (var r in routes)
        {
          switch (requestType)
          {
            case ERouteType.Post:
              builder = module.Post;
              break;

            case ERouteType.Delete:
              builder = module.Delete;
              break;
          }

          builder[r.Template] = p => CreateRoute(p, m, module);
        }
      }
    }

    /// <summary>
    /// Creates a route
    /// </summary>
    /// <param name="p">Route parameters</param>
    /// <param name="m">Method to be called</param>
    /// <param name="module">Module to call the method on</param>
    /// <returns>A route</returns>
    private static object CreateRoute(dynamic p, MethodInfo m, NancyModule module)
    {
      var objDict = ((DynamicDictionary)p).ToDictionary();

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
