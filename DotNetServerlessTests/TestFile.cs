using System;
using System.IO;

namespace DotNetServerless
{
  public class TestFile
  {
    private readonly string fileName;
    private readonly string contents;

    public TestFile(string fileName, string contents)
    {
      this.fileName = fileName;
      this.contents = contents;
    }

    public void Mock(Action action)
    {
      string previousContents = null;
      if (File.Exists(this.fileName))
      {
        previousContents = File.ReadAllText(this.fileName);
      }

      File.WriteAllText(this.fileName, this.contents);

      action();

      if (previousContents != null)
      {
        File.WriteAllText(this.fileName, previousContents);
      }
      else
      {
        File.Delete(this.fileName);
      }
    }
  }
}