using Microsoft.AspNetCore.Mvc;

namespace DotNetServerless.Controllers
{
  [Route("hello")]
  public class HelloController : Controller
  {
    [HttpGet]
    public HelloBody Get()
    {
      return new HelloBody();
    }
  }
}