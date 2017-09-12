using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetServerless
{
  public enum AppStage
  {
    Development,
    Test,
    Production
  }

  public static class ConfigurationHelper
  {
    public static AppStage Stage()
    {
      AppStage stage;
      Enum.TryParse(Environment.GetEnvironmentVariable("STAGE"), ignoreCase: true, result: out stage);
      return stage;
    }

    public static IConfigurationRoot Configuration()
    {
      string lowercaseStage = Stage().ToString().ToLower();
      return new ConfigurationBuilder()
        .AddJsonFile("config/appsettings.json")
        .AddJsonFile($"config/appsettings.{lowercaseStage}.json", optional: true)
        .Build();
    }

    public static void Configure<TOptions>(TOptions options, IConfiguration configuration = null)
      where TOptions : class
    {
      if (configuration == null)
      {
        configuration = Configuration();
      }

      new ConfigureFromConfigurationOptions<TOptions>(configuration)
        .Configure(options);
    }
  }
}