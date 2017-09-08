using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Serilog;
using Serilog.Formatting.Json;

[assembly:LambdaSerializer(typeof(JsonSerializer))]

namespace DotNetServerless
{
  public class Hello
  {
    private readonly ILogger logger;

    public Hello()
    {
      this.logger = new LoggerConfiguration()
        .WriteTo.Console(new JsonFormatter())
        .CreateLogger();
    }

    public APIGatewayProxyResponse Handler(APIGatewayProxyRequest request)
    {
      var log = this.logger.ForContext("RequestId", request.RequestContext.RequestId);
      log.Information("Entering Hello::Handler");
      return APIGatewayHelper.Success(new HelloBody());
    }

    public class HelloBody
    {
      public HelloBody()
      {
        this.Message = "Hello World!";
      }

      public string Message { get; set; }
    }
  }
}