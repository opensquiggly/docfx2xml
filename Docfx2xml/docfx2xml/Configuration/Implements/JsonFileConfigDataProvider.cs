using System.IO;
using Newtonsoft.Json;

namespace Docfx2xml.Configuration.Implements
{
  public class JsonFileConfigDataProvider : ConfigDataProviderBase
  {
    private readonly string _fileName;

    public JsonFileConfigDataProvider(string fileName)
    {
      _fileName = fileName;
    }
    
    protected override ConvertConfiguration GetConfigurationImplement()
    {
      if (File.Exists(_fileName))
      {
        var result = JsonConvert.DeserializeObject<ConvertConfiguration>(File.ReadAllText(_fileName));
        return result;
      }
      throw new FileNotFoundException(_fileName);
    }
  }
}
