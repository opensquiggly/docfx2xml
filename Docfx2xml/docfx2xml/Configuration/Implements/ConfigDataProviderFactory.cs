using Docfx2xml.CmdLine;
using Docfx2xml.Logger;

namespace Docfx2xml.Configuration.Implements
{
  public class ConfigDataProviderFactory : IConfigDataProviderFactory
  {
    private readonly ILogger _logger;
    
    public ConfigDataProviderFactory(ILogger logger)
    {
      _logger = logger;
    }
    
    public IConfigDataProvider GetDataProvider(ICmdVerb cmdVerb) =>
      cmdVerb switch
      {
        CmdVerbRunJson json => new JsonFileConfigDataProvider(json.FileName),
        CmdVerbRunArgs args => new CmdArgsConfigDataProvider(args),
        CmdVerbRunXml xml => new XmlFileConfigDataProvider(xml.FileName),
        CmdVerbInit init => new ConsoleInputConfigDataProvider(init.FileName, _logger),
        _ => null
      };
  }
}