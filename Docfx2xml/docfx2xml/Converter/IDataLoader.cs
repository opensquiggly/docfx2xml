using System.Threading.Tasks;
using System.Xml;
using Docfx2xml.Configuration;

namespace Docfx2xml.Converter
{
  public interface IDataLoader
  {
    string UploadData(XmlDocument document, ConvertConfiguration config, string xmlFileName, string namespaceName);
    
    Task<string> UploadDataAsync(XmlDocument document, ConvertConfiguration config, string xmlFileName, string namespaceName);
  }
}
