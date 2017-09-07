using Xunit;
using Hello;
using Amazon.Lambda.APIGatewayEvents;

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
    }
}