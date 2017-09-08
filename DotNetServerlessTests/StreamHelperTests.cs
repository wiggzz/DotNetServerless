using System;
using System.IO;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using DotNetServerless;
using Xunit;

namespace DotNetServerlessTests
{
  public class StreamHelperTests
  {
    [Fact]
    public void StreamHelperShouldReturnDataWrittenToStreamAsString()
    {
      var s = StreamHelper.StringFromStream(stream =>
      {
        StreamWriter writer = new StreamWriter(stream);
        writer.Write("value");
        writer.Flush();
      });

      Assert.Equal("value", s);
    }
  }
}