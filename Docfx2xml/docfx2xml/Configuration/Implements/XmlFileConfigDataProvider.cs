using System.IO;
using System.Xml.Serialization;
using Docfx2xml.Exceptions;

namespace Docfx2xml.Configuration.Implements
{
  public class XmlFileConfigDataProvider : ConfigDataProviderBase
  {
    private readonly string _fileName;
    
    public XmlFileConfigDataProvider(string fileName)
    {
      _fileName = fileName;
    }
    
    protected override ConvertConfiguration GetConfigurationImplement()
    {
      if (File.Exists(_fileName))
      {
        var serializer = new XmlSerializer(typeof(ConvertConfiguration));
        var reader = new StreamReader(_fileName);
        var result = (ConvertConfiguration)serializer.Deserialize(reader);
        reader.Close();
        return result;
      }
      throw new FileNotExistException($"File {_fileName} not found(xml)", _fileName);
    }
  }
}