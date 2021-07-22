using System;
using System.IO;
using System.Threading.Tasks;
using Docfx2xml.Exceptions;
using Docfx2xml.Helpers;
using Docfx2xml.Logger;
using Docfx2xml.XmlConverter;
using Newtonsoft.Json;

namespace Docfx2xml.Configuration.Implements
{
  public class ConsoleInputConfigDataProvider : ConfigDataProviderBase
  {
    private readonly string _fileName;
    private readonly ILogger _logger;

    public ConsoleInputConfigDataProvider(string fileName, ILogger logger)
    {
      _fileName = fileName;
      _logger = logger;
    }

    public override Task<ConvertConfiguration> GetConfigurationAsync() => Task.Run(GetConfiguration);

    public override ConvertConfiguration GetConfiguration()
    {
      var config = GetConfigurationImplement();
      // Skip logic for building data from yml files
      return null;
    }

    protected override ConvertConfiguration GetConfigurationImplement()
    {
      ValidateFileExist();
      var config = BuildConfig();
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
    
    private ConvertConfiguration BuildConfig()
    {
      var config = new ConvertConfiguration
      {
        YamlDataPath = GetYamlDataPath(),
        XmlOutPath = GetXmlOut(),
        XsltFilePath = GetXsltFilePath(),
        SaveToNamespaceFolders = GetSaveToNamespaceFolders(),
        BuildTocLessTreeFiles = GetBuildTocLessTreeFiles(),
        XmlConverterType = GetXmlConverterType()
      };

      ConfirmOrChangeConfig(config);
      return config;
    }

    private void ConfirmOrChangeConfig(ConvertConfiguration config)
    {
      while (true)
      {
        Console.WriteLine("Select option number that you want to change, or press 'x' for save config and exit:");
        Console.WriteLine();
        Console.WriteLine($"1 - {nameof(config.YamlDataPath)}");
        Console.WriteLine($"2 - {nameof(config.XmlOutPath)}");
        Console.WriteLine($"3 - {nameof(config.XsltFilePath)}");
        Console.WriteLine($"4 - {nameof(config.SaveToNamespaceFolders)}");
        Console.WriteLine($"5 - {nameof(config.BuildTocLessTreeFiles)}");
        Console.WriteLine($"6 - {nameof(config.XmlConverterType)}");
        Console.WriteLine("X - SAVE config and exit");
        var input = Console.ReadLine();
        if(input?.ToLower() == "x")
          return;

        switch (input)
        {
          case "1":
            config.YamlDataPath = GetYamlDataPath();
            continue;
          case "2":
            config.XmlOutPath = GetXmlOut();
            break;
          case "3":
            config.XsltFilePath = GetXsltFilePath();
            break;
          case "4":
            config.SaveToNamespaceFolders = GetSaveToNamespaceFolders();
            break;
          case "5":
            config.BuildTocLessTreeFiles = GetBuildTocLessTreeFiles();
            continue;
          case "6":
            config.XmlConverterType = GetXmlConverterType();
            continue;
        }
        
        Console.WriteLine("Input value is not valid, please try again...");
      }
    }
    
    private static string GetXmlOut() => 
      DirectoryHelper.SanitizeDirPath(GetData(nameof(ConvertConfiguration.XmlOutPath), false, ConfigConstants.XmlOutDefaultFolder,
        $"default folder: {ConfigConstants.XmlOutDefaultFolder}"), false);
    
    private static string GetYamlDataPath() => 
      DirectoryHelper.SanitizeDirPath(GetData<string>(nameof(ConvertConfiguration.YamlDataPath), true, null), false);
    
    private static string GetXsltFilePath() => 
      DirectoryHelper.SanitizeDirPath(GetData<string>(nameof(ConvertConfiguration.XsltFilePath), false, null), false);
    
    private static bool GetSaveToNamespaceFolders() => 
      GetData(nameof(ConvertConfiguration.SaveToNamespaceFolders), false, true, "true or false, default value true");
    
    private static bool GetBuildTocLessTreeFiles() => 
      GetData(nameof(ConvertConfiguration.BuildTocLessTreeFiles), false, true, "true or false, default value true");
    
    private static XmlConverterType GetXmlConverterType() => GetData(nameof(ConvertConfiguration.XmlConverterType), false, XmlConverterType.CustomIgnoreNamespaces, 
    "1 (Default) , 2 (Custom), 3 (CustomIgnoreNamespaces), default value is 3");

    private static T GetData<T>(string propertyName, bool isRequired, T defaultValue, string possibleValues = null)
    {
      while (true)
      {
        if (isRequired)
        {
          Console.WriteLine(string.IsNullOrEmpty(possibleValues)
            ? $"Please enter REQUIRED {propertyName} and press enter: "
            : $"Please enter REQUIRED {propertyName} (Possible values can be: {possibleValues}) and press enter: ");
        }
        else
        {
          Console.WriteLine(string.IsNullOrEmpty(possibleValues)
            ? $"Please enter OPTIONAL {propertyName} and press enter: "
            : $"Please enter OPTIONAL {propertyName} (Possible values can be: {possibleValues}) and press enter: ");
        }
        
        var input = Console.ReadLine();
        var (isValid, data) = ParseData(input, isRequired, defaultValue);
        if (isValid)
        {
          return (T) data;
        }
        Console.WriteLine("Input data is not valid, try again...");
      }
    }

    private static (bool, object) ParseData<T>(string input, bool isRequired, T defaultValue)
    {
      if (isRequired && string.IsNullOrEmpty(input))
      {
        return (false, default);
      }

      var type = typeof(T);
      if (!string.IsNullOrEmpty(input))
      {
        if (type == typeof(string))
        {
          return string.IsNullOrEmpty(input) ? (false, default) : (true, input);
        }
        if (type == typeof(bool))
        {
          return bool.TryParse(input, out var parseResult) ? (true, parseResult) : (false, default);
        }
        if (type == typeof(XmlConverterType))
        {
          var intParse = int.TryParse(input, out var parseResult);
          if (intParse)
          {
            return Enum.IsDefined(typeof(XmlConverterType), parseResult) 
              ? ((bool, object)) (true, (XmlConverterType) parseResult) 
              : (false, defaultValue);
          }
          return (false, defaultValue);
        }
      }
      return (true, defaultValue);
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