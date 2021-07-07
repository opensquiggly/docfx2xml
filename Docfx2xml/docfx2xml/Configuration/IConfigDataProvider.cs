using System.Threading.Tasks;

namespace Docfx2xml.Configuration
{
  public interface IConfigDataProvider
  {
    ConvertConfiguration GetConfiguration();
    
    Task<ConvertConfiguration> GetConfigurationAsync();
  }
}
