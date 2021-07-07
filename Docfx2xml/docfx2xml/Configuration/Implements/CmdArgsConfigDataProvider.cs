using System;
using Docfx2xml.CmdLine;

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
      return new ConvertConfiguration
      {
        XmlOutPath = _cmdVerbRunArgs.XmlFolderPath,
        YamlDataPath = _cmdVerbRunArgs.YamlFolderPath,
        SaveToNamespaceFolders = _cmdVerbRunArgs.SaveToNamespaceFolders,
        XsltFilePath = _cmdVerbRunArgs.XsltFilePath
      };
    }
  }
}