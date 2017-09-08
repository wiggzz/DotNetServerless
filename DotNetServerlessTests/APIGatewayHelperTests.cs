using DotNetServerless;
using Xunit;

namespace DotNetServerlessTests
{
  public class APIGatewayHelperTests
  {
    [Fact]
    public void SuccessShouldReturnA200()
    {
      var response = APIGatewayHelper.Success(new { });

      Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public void SuccessShouldSerializeThePayload()
    {
      var obj = new { Key = "Value" };
      var response = APIGatewayHelper.Success(obj);

      Assert.Equal(response.Body, "{\"Key\":\"Value\"}");
    }

    [Fact]
    public void SuccessShouldSetContentTypeToApplicationJson()
    {
      var response = APIGatewayHelper.Success(new { });

      Assert.Equal(response.Headers["Content-Type"], "application/json");
    }

    [Fact]
    public void FailureShouldReturnSpecifiedStatusCode()
    {
      var error = new APIGatewayHelper.Error
      {
        StatusCode = 400
      };
      var response = APIGatewayHelper.Failure(error);

      Assert.Equal(400, response.StatusCode);
    }

    [Fact]
    public void FailureShouldSerializeThePayload()
    {
      var error = new APIGatewayHelper.Error
      {
        Payload = new { Key = "Value" }
      };
      var response = APIGatewayHelper.Failure(error);

      Assert.Equal(response.Body, "{\"Key\":\"Value\"}");
    }
  }
}