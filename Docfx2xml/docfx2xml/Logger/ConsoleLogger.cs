using System;

namespace Docfx2xml.Logger
{
  public class ConsoleLogger : ILogger
  {
    public void LogInformation(string message) => Log(message);
    
    public void LogWarning(string message) => Log(message, ConsoleColor.Yellow);

    public void LogError(string message) => Log(message, ConsoleColor.Red);

    public void LogError(Exception ex) => LogError(ex.ToString());

    private void Log(string msg, ConsoleColor? color = null)
    {
      if (color.HasValue)
      {
        Console.ForegroundColor = color.Value;
        Console.WriteLine($"[{DateTime.UtcNow:s}]:{msg}");
        Console.ResetColor();
      }
      else
      {
        Console.WriteLine($"[{DateTime.UtcNow:s}]:{msg}");
      }
    }
  }
}
