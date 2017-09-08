using System;
using System.IO;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using DotNetServerless;
using Xunit;

namespace DotNetServerlessTests
{
  public class HelloTests
  {
    private readonly Hello hello;

    public HelloTests()
    {
      this.hello = new Hello();
    }

    [Fact]
    public void HelloHandlerShouldReturn200()
    {
      var response = this.hello.Handler(Request());

      Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public void HelloHandlerShouldReturnHelloWorldMessage()
    {
      var response = this.hello.Handler(Request());

      Assert.Equal("{\"Message\":\"Hello World!\"}", response.Body);
    }

    [Fact]
    public void HelloHandlerResponseShouldBeSerializable()
    {
      var response = this.hello.Handler(Request());

      MemoryStream stream = new MemoryStream();
      new JsonSerializer().Serialize(response, stream);

      Assert.NotEqual(0, stream.Length);
    }

    private static APIGatewayProxyRequest Request()
    {
      return new APIGatewayProxyRequest
      {
        RequestContext = new APIGatewayProxyRequest.ProxyRequestContext
        {
            RequestId = "test-id"
        }
      };
    }
  }
}