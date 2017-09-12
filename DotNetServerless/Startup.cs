using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Json;

namespace DotNetServerless
{
  public class Startup
  {
    public Startup(IHostingEnvironment environment)
    {
      var settings = new DefaultSettings();

      ConfigurationHelper.Configure(settings);

      Log.Logger = new LoggerConfiguration()
        .WriteTo.Console(new JsonFormatter())
        .MinimumLevel.Is(settings.LogLevel)
        .CreateLogger();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddSerilog();
      app.UseMvc();
    }
  }
}