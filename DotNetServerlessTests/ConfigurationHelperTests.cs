using System;
using System.Collections.Generic;
using System.IO;
using DotNetServerless;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace DotNetServerlessTests
{
  public class ConfigurationHelperTests
  {
    [Fact]
    public void StageShouldReturnTheStageFromEnvironmentVariable()
    {
      var key = "STAGE";
      var previousValue = Environment.GetEnvironmentVariable(key);
      Environment.SetEnvironmentVariable(key, "test");

      Assert.Equal(AppStage.Test, ConfigurationHelper.Stage());

      Environment.SetEnvironmentVariable(key, previousValue);
    }

    [Fact]
    public void ConfigurationShouldReturnConfigurationLoadedFromAppSettingsJsonFile()
    {
      var testFile = new TestFile("config/appsettings.json", "{\"key\":\"value\"}");

      testFile.Mock(() =>
      {
        var configuration = ConfigurationHelper.Configuration();

        Assert.Equal("value", configuration["key"]);
      });
    }

    [Fact]
    public void ConfigureShouldConfigureOptions()
    {
      var mockSettings = new MockSettings();

      var dict = new Dictionary<string, string>
      {
        { "Key", "Value" }
      };

      var configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(dict)
        .Build();

      ConfigurationHelper.Configure(mockSettings, configuration);

      Assert.Equal("Value", mockSettings.Key);
    }

    private class MockSettings
    {
      public string Key { get; set; }
    }
  }
}