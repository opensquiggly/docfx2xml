using Docfx2xml.CmdLine;

namespace Docfx2xml.Configuration.Implements
{
  public class ConfigDataProviderFactory : IConfigDataProviderFactory
  {
    public IConfigDataProvider GetDataProvider(ICmdVerb cmdVerb)
    {
      return cmdVerb switch
      {
        CmdVerbRunJson json => new JsonFileConfigDataProvider(json.FileName),
        CmdVerbRunArgs args => new CmdArgsConfigDataProvider(args),
        _ => null
      };
    }
  }
}