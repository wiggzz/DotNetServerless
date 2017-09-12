using System.IO;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.TestUtilities;
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
    public async void HelloHandlerShouldReturn200()
    {
      var lambdaContext = new TestLambdaContext();
      var response = await this.hello.FunctionHandlerAsync(Request(), lambdaContext);

      Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async void HelloHandlerShouldReturnHelloWorldMessage()
    {
      var lambdaContext = new TestLambdaContext();
      var response = await this.hello.FunctionHandlerAsync(Request(), lambdaContext);

      Assert.Equal("{\"message\":\"Hello World!\"}", response.Body);
    }

    [Fact]
    public async void HelloHandlerResponseShouldBeSerializable()
    {
      var lambdaContext = new TestLambdaContext();
      var response = await this.hello.FunctionHandlerAsync(Request(), lambdaContext);

      MemoryStream stream = new MemoryStream();
      new JsonSerializer().Serialize(response, stream);

      Assert.NotEqual(0, stream.Length);
    }

    private static APIGatewayProxyRequest Request()
    {
      return new APIGatewayProxyRequest
      {
        Path = "/hello",
        HttpMethod = "GET",
        RequestContext = new APIGatewayProxyRequest.ProxyRequestContext
        {
            RequestId = "test-id",
            ApiId = "xxxxxx",
            Stage = "test"
        }
      };
    }
  }
}