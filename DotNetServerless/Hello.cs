using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

[assembly:LambdaSerializer(typeof(JsonSerializer))]

namespace DotNetServerless
{
  public class Hello : BaseLambdaFunction<HelloBody>
  {
    public override HelloBody HandlerDelegate(APIGatewayProxyRequest request)
    {
      return new HelloBody();
    }
  }
}