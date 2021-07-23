using System.Threading.Tasks;
using System.Xml;
using Docfx2xml.Configuration;
using Docfx2xml.Helpers;

namespace Docfx2xml.Converter
{
  public class LocalFilesDataLoader : IDataLoader
  {
    public string UploadData(XmlDocument document, ConvertConfiguration config, string xmlFileName, string namespaceName)
    {
      var namespaceNameValue = config.SaveToNamespaceFolders ? namespaceName : null;
      var fileName = BuildFileName(config.XmlOutPath, $"{xmlFileName}.xml", namespaceNameValue);
      document.Save(fileName);
      return fileName;
    }
    
    public Task<string> UploadDataAsync(XmlDocument document, ConvertConfiguration config, string xmlFileName, string namespaceName) => 
      Task.Run(() => UploadData(document, config, xmlFileName, namespaceName));
    
    private static string BuildFileName(string xmlOutPath, string xmlDocName, string namespaceName)
    {
      var configPath = DirectoryHelper.SanitizeDirPath(xmlOutPath, true);
      var nameSpaceFolder = DirectoryHelper.SanitizeDirPath(namespaceName, false);
      var path = DirectoryHelper.CreateDirectoryIfNotExist(configPath, nameSpaceFolder);
      var fileName = DirectoryHelper.BuildFileName(path, xmlDocName);

      return fileName;
    }
  }
}
