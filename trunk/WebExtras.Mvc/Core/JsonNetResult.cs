/*
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
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  /// JSON.Net action result
  /// </summary>
  public class JsonNetResult : JsonResult
  {
    /// <summary>
    /// JSON serialiser settings
    /// </summary>
    public JsonSerializerSettings SerialiserSettings { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">Data to be returned</param>
    /// <param name="behavior">[Optional] JSON request behavior</param>
    public JsonNetResult(object data, JsonRequestBehavior behavior)
      : this(data, null, behavior)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="data">Data to be returned</param>
    /// <param name="settings">[Optional] JSON serialiser settings</param>
    /// <param name="behavior">[Optional] JSON request behavior</param>
    public JsonNetResult(object data, JsonSerializerSettings settings = null, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)    
    {
      Data = data;
      SerialiserSettings = settings ?? new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
      JsonRequestBehavior = behavior;
      ContentEncoding = Encoding.UTF8;
      ContentType = "application/json";
    }

    /// <summary>
    /// Execute this result
    /// </summary>
    /// <param name="context">Controller context</param>
    public override void ExecuteResult(ControllerContext context)
    {
      if (context == null)
        throw new ArgumentNullException("context");

      if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && context.HttpContext.Request.HttpMethod.ToLowerInvariant() == "get")
        throw new InvalidOperationException("Json GET request is not allowed");

      HttpResponseBase response = context.HttpContext.Response;

      response.ContentType = ContentType;
      response.ContentEncoding = ContentEncoding;

      if (Data == null) 
        return;

      JsonTextWriter writer = new JsonTextWriter(response.Output);
      JsonSerializer serializer = JsonSerializer.Create(SerialiserSettings);
      serializer.Serialize(writer, Data);

      writer.Flush();
    }
  }
}
