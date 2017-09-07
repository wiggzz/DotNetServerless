using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Amazon.Lambda.Serialization.Json;
using Serilog;
using Serilog.Formatting.Json;

[assembly:LambdaSerializer(typeof(JsonSerializer))]

namespace DotNetServerless {
  public class Hello {
    ILogger logger;

    public Hello() {
      logger = new LoggerConfiguration()
        .WriteTo.Console(new JsonFormatter())
        .CreateLogger();
    }

    public APIGatewayProxyResponse Handler(APIGatewayProxyRequest request)
    {
      var log = logger.ForContext("RequestId", request.RequestContext.RequestId);
      log.Information("Entering Hello::Handler");
      return APIGatewayHelper.Success(new HelloBody());
    }

    public class HelloBody {
      public String Message { get; set; }

      public HelloBody() {
        Message = "Hello World!";
      }
    }
  }
}