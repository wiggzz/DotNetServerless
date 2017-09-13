using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DotNetServerless
{
  public class LocalEntryPoint
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}