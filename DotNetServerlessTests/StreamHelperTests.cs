using Xunit;
using DotNetServerless;
using System;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.Json;
using System.IO;

namespace DotNetServerlessTests
{
    public class StreamHelperTests
    {
        [Fact]
        public void StreamHelperShouldReturnDataWrittenToStreamAsString()
        {
            var s = StreamHelper.StringFromStream(stream => {
              StreamWriter writer = new StreamWriter(stream);
              writer.Write("value");
              writer.Flush();
            });

            Assert.Equal("value", s);
        }
    }
}