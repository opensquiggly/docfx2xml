using System;
using System.Threading.Tasks;

namespace Docfx2xml.Configuration.Implements
{
  public abstract class ConfigDataProviderBase : IConfigDataProvider
  {
    public ConvertConfiguration GetConfiguration()
    {
      var config = GetConfigurationImplement();
      ValidateConfig(config);
      return config;
    }

    public Task<ConvertConfiguration> GetConfigurationAsync() => Task.Run(GetConfiguration);

    protected abstract ConvertConfiguration GetConfigurationImplement();
    
    private void ValidateConfig(ConvertConfiguration config)
    {
      if (string.IsNullOrEmpty(config?.XmlOutPath))
      {
        throw new ArgumentNullException(nameof(config.XmlOutPath));
      }

      if (string.IsNullOrEmpty(config.YamlDataPath))
      {
        throw new ArgumentNullException(nameof(config.YamlDataPath));
      }
    }
  }
}