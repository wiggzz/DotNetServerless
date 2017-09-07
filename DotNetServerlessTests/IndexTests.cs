using Xunit;
using Hello;
using System;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using System.IO;

namespace HelloTests
{
    public class HandlerTests
    {
        private readonly Handler _handler;

        public HandlerTests()
        {
            _handler = new Handler();
        }

        [Fact]
        public void HandlerHelloShouldReturn200()
        {
            var response = _handler.Hello(new APIGatewayProxyRequest());

            Assert.Equal(response.StatusCode, 200);
        }

        [Fact]
        public void HandlerHelloShouldReturnHelloWorldMessage()
        {
          var response = _handler.Hello(new APIGatewayProxyRequest());

          Assert.Equal(response.Body, "{\"Message\":\"Hello World!\"}");
        }

        [Fact]
        public void HandlerHelloResponseShouldBeSerializable()
        {
          var response = _handler.Hello(new APIGatewayProxyRequest());

          MemoryStream stream = new MemoryStream();
          new JsonSerializer().Serialize(response, stream);
          
          Assert.NotEqual(stream.Length, 0);
        }
    }
}