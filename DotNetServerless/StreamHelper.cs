using Amazon.Lambda.Serialization.Json;
using System;
using System.IO;

namespace DotNetServerless {
  public class StreamHelper {
    public static string StringFromStream(Action<Stream> handler) {
      MemoryStream stream = new MemoryStream();
      handler(stream);
      stream.Position = 0;
      return new StreamReader(stream).ReadToEnd();
    }
  }
}