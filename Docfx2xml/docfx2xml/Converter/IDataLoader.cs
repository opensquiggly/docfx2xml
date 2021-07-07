using System.Threading.Tasks;
using System.Xml;
using Docfx2xml.Configuration;

namespace Docfx2xml.Converter
{
  public interface IDataLoader
  {
    void UploadData(XmlDocument document, ConvertConfiguration config, string xmlFileName, string namespaceName);
    
    Task UploadDataAsync(XmlDocument document, ConvertConfiguration config, string xmlFileName, string namespaceName);
  }
}
