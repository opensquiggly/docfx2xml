using System;
using System.Diagnostics;
using Docfx2xml.CmdLine;
using Docfx2xml.XmlConverter;

namespace Docfx2xml.Configuration.Implements
{
  public class CmdArgsConfigDataProvider : ConfigDataProviderBase
  {
    private readonly CmdVerbRunArgs _cmdVerbRunArgs;
    
    public CmdArgsConfigDataProvider(CmdVerbRunArgs cmdVerbRunArgs)
    {
      _cmdVerbRunArgs = cmdVerbRunArgs ?? throw new ArgumentNullException(nameof(cmdVerbRunArgs));
    }
    
    protected override ConvertConfiguration GetConfigurationImplement()
    {
      XmlConverterType xmlConverterType = _cmdVerbRunArgs.XmlConverterType switch
      {
        "d" => XmlConverterType.Default,
        "c" => XmlConverterType.Custom,
        _ => default
      };
      return new ConvertConfiguration
      {
        XmlOutPath = _cmdVerbRunArgs.XmlFolderPath,
        YamlDataPath = _cmdVerbRunArgs.YamlFolderPath,
        SaveToNamespaceFolders = _cmdVerbRunArgs.SaveToNamespaceFolders,
        XsltFilePath = _cmdVerbRunArgs.XsltFilePath,
        XmlConverterType = xmlConverterType
      };
    }
  }
}