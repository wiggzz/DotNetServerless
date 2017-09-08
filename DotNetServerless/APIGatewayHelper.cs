using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;

namespace DotNetServerless
{
  public class APIGatewayHelper
  {
    public static APIGatewayProxyResponse Success<T>(T payload)
    {
      return new APIGatewayProxyResponse
      {
        StatusCode = 200,
        Body = StreamHelper.StringFromStream(stream =>
        {
          new JsonSerializer().Serialize(payload, stream);
        }),
        Headers = new Dictionary<string, string>
        {
          { "Content-Type", "application/json" }
        }
      };
    }

    public static APIGatewayProxyResponse Failure(Error error)
    {
      return new APIGatewayProxyResponse
      {
        StatusCode = error.StatusCode,
        Body = StreamHelper.StringFromStream(stream =>
        {
          new JsonSerializer().Serialize(error.Payload, stream);
        })
      };
    }

    public class Error : System.Exception
    {
      public int StatusCode { get; set; }

      public object Payload { get; set; }
    }
  }
}