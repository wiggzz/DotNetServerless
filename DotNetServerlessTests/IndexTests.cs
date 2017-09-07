using Xunit;
using DotNetServerless;
using System;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using System.IO;

namespace DotNetServerlessTests
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

            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void HandlerHelloShouldReturnHelloWorldMessage()
        {
          var response = _handler.Hello(new APIGatewayProxyRequest());

          Assert.Equal("{\"Message\":\"Hello World!\"}", response.Body);
        }

        [Fact]
        public void HandlerHelloResponseShouldBeSerializable()
        {
          var response = _handler.Hello(new APIGatewayProxyRequest());

          MemoryStream stream = new MemoryStream();
          new JsonSerializer().Serialize(response, stream);
          
          Assert.NotEqual(0, stream.Length);
        }
    }
}