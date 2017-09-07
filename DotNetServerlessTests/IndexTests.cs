using Xunit;
using DotNetServerless;
using System;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using System.IO;

namespace DotNetServerlessTests
{
    public class HelloTests
    {
        private readonly Hello _hello;
        private readonly APIGatewayProxyRequest _request;

        public HelloTests()
        {
            _hello = new Hello();
            _request = new APIGatewayProxyRequest {
                RequestContext = new APIGatewayProxyRequest.ProxyRequestContext {
                    RequestId = "test-id"
                }
            };
        }

        [Fact]
        public void HelloHandlerShouldReturn200()
        {
            var response = _hello.Handler(_request);

            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void HelloHandlerShouldReturnHelloWorldMessage()
        {
          var response = _hello.Handler(_request);

          Assert.Equal("{\"Message\":\"Hello World!\"}", response.Body);
        }

        [Fact]
        public void HelloHandlerResponseShouldBeSerializable()
        {
          var response = _hello.Handler(_request);

          MemoryStream stream = new MemoryStream();
          new JsonSerializer().Serialize(response, stream);
          
          Assert.NotEqual(0, stream.Length);
        }
    }
}