using System.IO;
using DotNetServerless;
using Xunit;

namespace DotNetServerlessTests
{
  public class StreamHelperTests
  {
    [Fact]
    public void StreamHelperShouldReturnDataWrittenToStreamAsString()
    {
      var s = StreamHelper.StringFromStream(stream =>
      {
        StreamWriter writer = new StreamWriter(stream);
        writer.Write("value");
        writer.Flush();
      });

      Assert.Equal("value", s);
    }
  }
}