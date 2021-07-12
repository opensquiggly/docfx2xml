using System.Collections.Generic;
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
    private readonly IXmlConverterResolver _xmlConvertResolver;
    private readonly IDataLoader _dataLoader;
    private readonly ITreeFormatBuilder _treeFormatBuilder;

    public LocalFilesDataConverter(ILogger logger, IXmlConverterResolver xmlConvertResolver, IDataLoader dataLoader, ITreeFormatBuilder treeFormatBuilder)
    {
      _logger = logger;
      _xmlConvertResolver = xmlConvertResolver;
      _dataLoader = dataLoader;
      _treeFormatBuilder = treeFormatBuilder;
    }

    public void Convert(ConvertConfiguration config) => ConvertAsync(config).GetAwaiter().GetResult();

    public Task ConvertAsync(ConvertConfiguration config) => ConvertImplement(config);

    private async Task ConvertImplement(ConvertConfiguration config)
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
      
      var xmlConverter = _xmlConvertResolver.Resolve(config.XmlConverterType);
      var fileNames = new List<string>();
      foreach (var file in files)
      {
        if (Path.GetFileName(file) == "toc.yml")
        {
          continue;
        }
        
        _logger.LogInformation($"Process: {file}...");
        
        using var readerYaml = new StreamReader(file);
        var yamlData = deserializer.Deserialize<DataInfo>(readerYaml);
        var xml = xmlConverter.ConvertToDoc(yamlData, config.XsltFilePath);
        var xmlFileName = Path.GetFileNameWithoutExtension(file);
        var namespaceName = yamlData.Items.FirstOrDefault()?.Namespace;
        var fileName = await _dataLoader.UploadDataAsync(xml, config, xmlFileName, namespaceName);
        _logger.LogInformation($"Saved {xmlFileName}.xml");
        fileNames.Add(fileName);
      }
      
      _logger.LogInformation("...");
      _treeFormatBuilder.BuildTree(fileNames, config);
      _logger.LogInformation("...");
      
      _logger.LogInformation($"Processed files:{files.Length}");
    }
  }
}
