using System;

namespace Docfx2xml.Exceptions
{
  [Serializable]
  public class FileNotExistException : Exception
  {
    public string FileName { get; set; }

    public FileNotExistException(string message) : base(message){ }

    public FileNotExistException(string message, string fileName) : base(message)
    {
      FileName = fileName;
    }
  }
}