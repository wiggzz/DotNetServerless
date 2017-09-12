namespace DotNetServerless
{
  public class HelloBody
    {
    public HelloBody()
    {
      this.Message = "Hello World!";
    }

    public string Message { get; set; }
  }
}