using System;
using System.IO;

namespace Docfx2xml.Helpers
{
  public static class DirectoryHelper
  {
    public static string BuildFileName(string dirPath, string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }
      return dirPath + "/" + fileName;
    }

    public static string SanitizeDirPath(string dirPath, bool throwErrorIfNull)
    {
      if (string.IsNullOrEmpty(dirPath))
      {
        if (throwErrorIfNull)
        {
          throw new ArgumentNullException(nameof(dirPath));
        }
        return dirPath;
      }
      dirPath = dirPath.Replace("\\", "/");
      if (dirPath.EndsWith("/"))
      {
        dirPath = dirPath.Remove(dirPath.Length - 1, 1);
      }
      return dirPath;
    }

    public static string CreateDirectoryIfNotExist(string dirPath, string childFolder)
    {
      if (string.IsNullOrEmpty(childFolder))
      {
        return dirPath;
      }
      var path = dirPath + "/" + childFolder;
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
      return path;
    }
    
    public static void RecreateDirectory(string path)
    {
      if (Directory.Exists(path))
      {
        DeleteDirectory(path);
      }
      Directory.CreateDirectory(path);
    }

    private static void DeleteDirectory(string path)
    {
      var files = Directory.GetFiles(path);
      var dirs = Directory.GetDirectories(path);
      foreach (var file in files)
      {
        File.SetAttributes(file, FileAttributes.Normal);
        File.Delete(file);
      }
      foreach (var dir in dirs)
      {
        DeleteDirectory(dir);
      }
      Directory.Delete(path, false);
    }
  }
}
