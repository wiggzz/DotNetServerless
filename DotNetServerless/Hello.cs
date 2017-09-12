using System.IO;
using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;

namespace DotNetServerless
{
  public class Hello : APIGatewayProxyFunction
  {
    protected override void Init(IWebHostBuilder builder)
    {
      builder.UseStartup<Startup>()
        .UseApiGateway();
    }
  }
}