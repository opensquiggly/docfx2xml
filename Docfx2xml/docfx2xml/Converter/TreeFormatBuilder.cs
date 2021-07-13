using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Docfx2xml.Configuration;
using Docfx2xml.Helpers;
using Docfx2xml.Logger;

namespace Docfx2xml.Converter
{
  public class TreeFormatBuilder : ITreeFormatBuilder
  {
    private readonly ILogger _logger;

    private const string TocLessFileName = ".opensquiggly";

    public TreeFormatBuilder(ILogger logger)
    {
      _logger = logger;
    }

    public void BuildTree(IEnumerable<string> fileNames, ConvertConfiguration config)
    {
      if (!config.BuildTocLessTreeFiles)
      {
        _logger.LogInformation("Default files tree builder...");
        return;
      }

      _logger.LogInformation("Build OpenSquiggly tocLess tree files...");
      var rootFolder = DirectoryHelper.SanitizeDirPath(config.XmlOutPath, true);
      var rootFilePath = CreateTocLessFileIfNotExist(rootFolder);
      var fileNamesArray = fileNames.ToArray();
      Array.Sort(fileNamesArray, StringComparer.InvariantCultureIgnoreCase);
      foreach (var filename in fileNamesArray)
      {
        var folderName = Path.GetDirectoryName(filename);
        var filePath = CreateTocLessFileIfNotExist(folderName);
        var isRootFolder = DirectoryHelper.SanitizeDirPath(folderName, false) == rootFolder;
        using var sw = File.AppendText(filePath);
        sw.WriteLine(BuildFileName(filename, isRootFolder));
      }
    }

    private static string CreateTocLessFileIfNotExist(string folderPath)
    {
      var rootFolder = DirectoryHelper.SanitizeDirPath(folderPath, true);
      var fileName = DirectoryHelper.BuildFileName(rootFolder, TocLessFileName);
      if (!File.Exists(fileName))
      {
        using var fs = File.CreateText(fileName);
        var subFolders = Directory.GetDirectories(folderPath);
        Array.Sort(subFolders, StringComparer.InvariantCultureIgnoreCase);
        if (subFolders.Any())
        {
          foreach (var folder in subFolders)
          {
            fs.WriteLine(BuildFolderName(folder));
          }
        }
      }
      return fileName;
    }

    private static string BuildFileName(string name, bool rootFile)
    {
      var fileNameWithExtension = Path.GetFileName(name);
      var fileName = Path.GetFileNameWithoutExtension(name);
      var nameResult = rootFile ? fileName : fileName.Split(".").LastOrDefault();
      return $"{fileNameWithExtension}={nameResult}";
    }

    private static string BuildFolderName(string name)
    {
      var directoryInfo = new DirectoryInfo(name);
      var directoryName = directoryInfo.Name;
      return $"{directoryName}={directoryName.Replace('.', '_')}";
    } 
  }
}