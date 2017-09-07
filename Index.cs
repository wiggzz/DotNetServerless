using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System;
using System.IO;
using System.Collections.Generic;
using Amazon.Lambda.Serialization.Json;

[assembly:LambdaSerializer(typeof(JsonSerializer))]

namespace Hello {
  public class Handler {
    public APIGatewayProxyResponse Hello(APIGatewayProxyRequest request)
    {
      Console.WriteLine("Entered hello");
      Stream stream = new MemoryStream();

      Response response = new Response();
      new JsonSerializer().Serialize(response, stream);
      stream.Position = 0;

      return new APIGatewayProxyResponse {
        Body = new StreamReader(stream).ReadToEnd(),
        StatusCode = 200,
        Headers = new Dictionary<string, string> {
          { "Content-Type", "text/html" }
        }
      };
    }

    public class Response {
      public String Message { get; set; }

      public Response() {
        Message = "Hello World!";
      }
    }
  }
}