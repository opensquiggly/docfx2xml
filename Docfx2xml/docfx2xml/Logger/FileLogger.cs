using System;
using System.IO;

namespace Docfx2xml.Logger
{
  public class FileLogger : ILogger
  {
    private readonly string _logFileName;

    public FileLogger()
    {
      _logFileName = "log.txt";
      CreateFileIfNotExist(_logFileName);
    }

    public FileLogger(string fileName)
    {
      _logFileName = fileName;
      CreateFileIfNotExist(fileName);
    }

    public void LogInformation(string message) => Log(message, LogMsgSeverity.Info);
    
    public void LogWarning(string message) => Log(message, LogMsgSeverity.Warning);

    public void LogError(string message) => Log(message, LogMsgSeverity.Error);

    public void LogError(Exception ex) => LogError(ex.ToString());

    private void Log(string message, LogMsgSeverity severity)
    {
      var fileMsg = $"[{severity.ToString().ToUpper()}:{DateTime.UtcNow:s}]:{message}";
      File.AppendAllText(_logFileName, fileMsg);
    }

    private static void CreateFileIfNotExist(string fileName)
    {
      if (!File.Exists(fileName))
      {
        File.Create(fileName);
      }
    }
  }
}