using System.IO;
using System.Threading.Tasks;
using Docfx2xml.Exceptions;
using Docfx2xml.Logger;
using Newtonsoft.Json;

namespace Docfx2xml.Configuration.Implements
{
  public class InitializeConfigDataProvider : ConfigDataProviderBase
  {
    private readonly string _fileName;
    private readonly ILogger _logger;
    private readonly IConfigInputDataBuilder _configDataBuilder; 

    public InitializeConfigDataProvider(string fileName, ILogger logger, IConfigInputDataBuilder configDataBuilder)
    {
      _fileName = fileName;
      _logger = logger;
      _configDataBuilder = configDataBuilder;
    }

    public override Task<ConvertConfiguration> GetConfigurationAsync() => Task.Run(GetConfiguration);

    public override ConvertConfiguration GetConfiguration()
    {
      var config = GetConfigurationImplement();
      
      base.GetConfiguration();
      return null;
    }

    protected override ConvertConfiguration GetConfigurationImplement()
    {
      ValidateFileExist();
      var config = _configDataBuilder.BuildConfig();
      
      SaveJsonFile(config);
      SaveXmlFile(config);
      
      return config;
    }

    private void ValidateFileExist()
    {
      var jsonFileName = Path.GetFileNameWithoutExtension(_fileName) + ".json";
      var xmlFileName = Path.GetFileNameWithoutExtension(_fileName) + ".xml";
      if (File.Exists(jsonFileName))
      {
        throw new FileExistException($"Can't init. {jsonFileName} already exists", jsonFileName);
      }
      if (File.Exists(xmlFileName))
      {
        throw new FileExistException($"Can't init. {xmlFileName} already exists", xmlFileName);
      }
    }
    
    private void SaveXmlFile(ConvertConfiguration config)
    {
      var fileName = Path.GetFileNameWithoutExtension(_fileName) + ".xml";
      var writer = new System.Xml.Serialization.XmlSerializer(typeof(ConvertConfiguration));
      using var file = File.Create(fileName);
      writer.Serialize(file, config);  
      file.Close();  
      _logger.LogInformation($"Config xml file is created: {fileName}");
    }

    private void SaveJsonFile(ConvertConfiguration config)
    {
      var fileName = Path.GetFileNameWithoutExtension(_fileName) + ".json";
      using var file = File.CreateText(fileName);
      var serializer = new JsonSerializer();
      serializer.Serialize(file, config);
      _logger.LogInformation($"Config json file is created: {fileName}");
    }
  }
}