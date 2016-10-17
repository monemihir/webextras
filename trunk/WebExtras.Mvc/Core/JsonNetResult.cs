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

using System;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebExtras.Core;

namespace WebExtras.Mvc.Core
{
  /// <summary>
  ///   JSON.Net action result
  /// </summary>
  public class JsonNetResult : JsonResult
  {
    /// <summary>
    ///   JSON serialiser settings
    /// </summary>
    public JsonSerializerSettings SerialiserSettings { get; set; }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="data">Data to be returned</param>
    /// <param name="behavior">[Optional] JSON request behavior</param>
    public JsonNetResult(object data, JsonRequestBehavior behavior)
      : this(data, null, behavior)
    {
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="data">Data to be returned</param>
    /// <param name="settings">
    ///   [Optional] JSON serialiser settings. If null will use the global JSON serialisation settings
    ///   <see cref="M:GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerialiserSettings" />
    /// </param>
    /// <param name="behavior">[Optional] JSON request behavior</param>
    public JsonNetResult(object data, JsonSerializerSettings settings = null,
      JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
    {
      Data = data;
      SerialiserSettings = settings ?? WebExtrasSettings.JsonSerializerSettings;
      JsonRequestBehavior = behavior;
      ContentEncoding = Encoding.UTF8;
      ContentType = "application/json";
    }

    /// <summary>
    ///   Execute this result
    /// </summary>
    /// <param name="context">Controller context</param>
    public override void ExecuteResult(ControllerContext context)
    {
      if (context == null)
        throw new ArgumentNullException("context");

      if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
          context.HttpContext.Request.HttpMethod.ToLowerInvariant() == "get")
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