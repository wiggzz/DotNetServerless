using Microsoft.AspNetCore.Mvc;

namespace DotNetServerless.Controllers
{
  public class HelloController : Controller
  {
    [HttpGet("hello")]
    public HelloBody Get()
    {
      return new HelloBody();
    }
  }
}