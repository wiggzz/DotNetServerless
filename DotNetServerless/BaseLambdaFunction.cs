using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Serilog;
using Serilog.Formatting.Json;

namespace DotNetServerless
{
  public abstract class BaseLambdaFunction<TResponseType>
  {
    public BaseLambdaFunction()
    {
      this.InitializeSettings();

      this.InitializeLogger();
    }

    public ILogger Logger { get; set; }

    public DefaultSettings Settings { get; set; }

    public abstract TResponseType HandlerDelegate(APIGatewayProxyRequest request, ILogger logger);

    public APIGatewayProxyResponse Handler(APIGatewayProxyRequest request)
    {
      var log = this.Logger.ForContext("RequestId", request.RequestContext.RequestId);
      log.Information("Entered {ClassName}::Handler", this.GetType().Name);
      try
      {
        return APIGatewayHelper.Success(this.HandlerDelegate(request));
      }
      catch (APIGatewayHelper.Error error)
      {
        return APIGatewayHelper.Failure(error);
      }
    }

    public void InitializeSettings()
    {
      this.Settings = new DefaultSettings();

      ConfigurationHelper.Configure(this.Settings);
    }

    public void InitializeLogger()
    {
      this.Logger = new LoggerConfiguration()
        .WriteTo.Console(new JsonFormatter())
        .MinimumLevel.Is(this.Settings.LogLevel)
        .CreateLogger();
    }
  }
}