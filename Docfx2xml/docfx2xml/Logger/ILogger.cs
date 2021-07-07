using System;

namespace Docfx2xml.Logger
{
  public interface ILogger
  {
    void LogInformation(string message);
    
    void LogWarning(string message);
    
    void LogError(string message);
    
    void LogError(Exception ex);
  }
}
