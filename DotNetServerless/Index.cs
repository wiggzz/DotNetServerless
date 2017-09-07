using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Amazon.Lambda.Serialization.Json;

[assembly:LambdaSerializer(typeof(JsonSerializer))]

namespace DotNetServerless {
  public class Hello {
    public APIGatewayProxyResponse Handler(APIGatewayProxyRequest request)
    {
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