using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

[assembly:LambdaSerializer(typeof(JsonSerializer))]

namespace DotNetServerless
{
  public class Hello
  {
    private readonly ILogger logger;
    private readonly Settings settings;

    public Hello()
    {
      this.settings = new Settings();

      ConfigurationHelper.Configure(this.settings);

      this.logger = new LoggerConfiguration()
        .WriteTo.Console(new JsonFormatter())
        .MinimumLevel.Is(this.settings.LogLevel)
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

    public class Settings
    {
      public LogEventLevel LogLevel { get; set; } = LogEventLevel.Information;
    }
  }
}