using System;
using System.Threading.Tasks;

namespace Docfx2xml.Configuration.Implements
{
  public abstract class ConfigDataProviderBase : IConfigDataProvider
  {
    public virtual ConvertConfiguration GetConfiguration()
    {
      var config = GetConfigurationImplement();
      ValidateConfig(config);
      return config;
    }

    public virtual Task<ConvertConfiguration> GetConfigurationAsync() => Task.Run(GetConfiguration);

    protected abstract ConvertConfiguration GetConfigurationImplement();

    private static void ValidateConfig(ConvertConfiguration config)
    {
      if (string.IsNullOrEmpty(config?.YamlDataPath))
      {
        throw new ArgumentNullException(nameof(config.YamlDataPath));
      }
      
      if (string.IsNullOrEmpty(config.XmlOutPath))
      {
        config.XmlOutPath = ConfigConstants.XmlOutDefaultFolder;
      }
    }
  }
}