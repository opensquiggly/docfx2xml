using System;
using Docfx2xml.CmdLine;
using Docfx2xml.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace Docfx2xml.Configuration.Implements
{
  public class ConfigDataProviderFactory : IConfigDataProviderFactory
  {
    private readonly IServiceProvider _serviceProvider;
    
    public ConfigDataProviderFactory(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }
    
    public IConfigDataProvider GetDataProvider(ICmdVerb cmdVerb) =>
      cmdVerb switch
      {
        CmdVerbRunJson json => new JsonFileConfigDataProvider(json.FileName),
        CmdVerbRunArgs args => new CmdArgsConfigDataProvider(args),
        CmdVerbRunXml xml => new XmlFileConfigDataProvider(xml.FileName),
        CmdVerbInit init => new InitializeConfigDataProvider(init.FileName, 
          _serviceProvider.GetService<ILogger>(), _serviceProvider.GetService<IConfigInputDataBuilder>()),
        _ => null
      };
  }
}