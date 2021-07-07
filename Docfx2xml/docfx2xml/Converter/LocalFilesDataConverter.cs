using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Docfx2xml.Configuration;
using Docfx2xml.Helpers;
using Docfx2xml.Logger;
using Docfx2xml.Models;
using Docfx2xml.XmlConverter;
using YamlDotNet.Serialization;

namespace Docfx2xml.Converter
{
  public class LocalFilesDataConverter : IDataConverter
  {
    private readonly ILogger _logger;
    private readonly IXmlConverter _xmlConverter;
    private readonly IDataLoader _dataLoader;

    public LocalFilesDataConverter(ILogger logger, IXmlConverter xmlConverter, IDataLoader dataLoader)
    {
      _logger = logger;
      _xmlConverter = xmlConverter;
      _dataLoader = dataLoader;
    }

    public void Convert(ConvertConfiguration config) => ConvertAsync(config).GetAwaiter().GetResult();

    public Task ConvertAsync(ConvertConfiguration config) => Task.Run(() => ConvertImplement(config));

    private void ConvertImplement(ConvertConfiguration config)
    {
      var files = Directory.GetFiles(config.YamlDataPath, "*.yml");
      if (!files.Any())
      {
        throw new FileNotFoundException($"directory {config.YamlDataPath} not contains *.yml files");
      }
      DirectoryHelper.RecreateDirectory(config.XmlOutPath);
      
      var deserializer = new DeserializerBuilder()
        .IgnoreUnmatchedProperties()
        .Build();
      
      foreach (var file in files)
      {
        if (Path.GetFileName(file) == "toc.yml")
        {
          continue;
        }
        
        _logger.LogInformation($"Process: {file}...");
        
        using var readerYaml = new StreamReader(file);
        var yamlData = deserializer.Deserialize<DataInfo>(readerYaml);
        var xml = _xmlConverter.ConvertToDoc(yamlData, config.XsltFilePath);
        var xmlFileName = Path.GetFileNameWithoutExtension(file);

        var namespaceName = yamlData.Items.FirstOrDefault()?.Namespace;
        _dataLoader.UploadData(xml, config, xmlFileName, namespaceName);
        _logger.LogInformation($"Saved {xmlFileName}.xml");
      }
      _logger.LogInformation("...");
      _logger.LogInformation($"Processed files:{files.Length}");
    }
  }
}
