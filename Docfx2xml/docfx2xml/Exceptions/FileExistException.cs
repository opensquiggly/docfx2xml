using System;

namespace Docfx2xml.Exceptions
{
  [Serializable]
  public class FileExistException : Exception
  {
    public string FileName { get; set; }

    public FileExistException(string message) : base(message){ }

    public FileExistException(string message, string fileName) : base(message)
    {
      FileName = fileName;
    }
  }
}